using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Sample.BlazorUI.DTO;
using Sample.BlazorUI.EndPoint;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace Sample.BlazorUI.Middleware
{
    public class TokenExpirationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration; // Inject IConfiguration for token validation and refresh logic
        private readonly string[] _excludePaths = { "/", "/login", "/logout", "/ExternalLoginCallback" };
        private readonly string[] _staticFileExtensions = { ".css", ".js", ".png", ".jpg", ".gif", ".ico", "disconnect", "_blazor", "initializers", "negotiate" }; // Static file extensions
        private readonly ITokenHelperRepository _tokenHelper;
        public TokenExpirationMiddleware(RequestDelegate next, IConfiguration configuration, ITokenHelperRepository TokenHelperRepository)
        {
            _next = next;
            _configuration = configuration;
            _tokenHelper = TokenHelperRepository; // Instantiate TokenHelper with required dependencies

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;

            if (!_excludePaths.Any(p => path.StartsWithSegments(p)) &&
          !_staticFileExtensions.Any(ext => path.Value.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
            {
                // var tokenhelper = new TokenHelper();
                string token = context.Request.Headers["Authorization"]; // Retrieve token from request headers

                if (string.IsNullOrEmpty(token))
                {
                    //context.Response.StatusCode = 401;
                    context.Response.Redirect("/login");
                    //_navManager.NavigateTo("/");// Redirect to login page if token is not provided
                    return;
                }

                // Check token expiration and refresh logic based on your implementation (using JWT, for instance)
                bool isTokenExpired = await _tokenHelper.IsTokenExpired(token); // Implement your token expiration check logic

                if (isTokenExpired)
                {
                    try
                    {
                        var refreshTokens = context.Request.Headers["RefreshToken"];//await _tokenHelper.GetRefreshToken();
                        var dto = new TokenDto();
                        dto.RefreshToken = refreshTokens;
                        dto.AccessToken = token;
                        var response = await _tokenHelper.GenerateNewToken(dto); // Implement your token refresh logic
                                                                                 // Update the request with the new token
                        if (response != null)
                        {
                            context.Request.Headers["Authorization"] = "Bearer " + response.AccessToken;
                            context.Request.Headers["RefreshToken"] = response.RefreshToken;
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Failed to refresh token: " + ex.Message);
                        return;
                    }
                }
            }
            await _next(context); // Call the next middleware or the actual request handling logic
        }
    }
    public interface ITokenHelperRepository
    {
        Task<string> GetRefreshToken();
        Task<string> GetBearerToken();
        Task<bool> IsTokenExpired(string Token);
        Task<TokenDto> GenerateNewToken(TokenDto dto);
    }
    public class TokenHelperRepository : ITokenHelperRepository
    {
        private readonly IHttpClientFactory _httpClient;


        public TokenHelperRepository( IHttpClientFactory httpClient)
        {
     
            _httpClient = httpClient;

        }


        public async Task<string> GetRefreshToken()
        {

            var RefreshToken = "";//await _localStorageService.GetItemAsync<string>("AuthRefreshJwtToken");

            return RefreshToken; // Return the refreshed token
        }
        public async Task<string> GetBearerToken()
        {

            return "";// await _localStorageService.GetItemAsync<string>("AuthJwtToken");
        }
        public async Task<TokenDto> GenerateNewToken(TokenDto dto)
        {
            // Implement logic to call your API endpoint
            // Set token in the request header or as needed
            var tokenDto = new TokenDto();

            var request = new HttpRequestMessage(HttpMethod.Post, StaticEndPoint.AuthRefreshEndpoint);

            request.Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var client = _httpClient.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Apiresponse = JsonConvert.DeserializeObject<TokenDto>(content);
                // await _localStorageService.SetItemAsync("AuthRefreshJwtToken", Apiresponse.RefreshToken);
                return Apiresponse;
            }

            throw new Exception("Failed to fetch data from API");
        }
        // Method to check if the JWT token is expired
        public async Task<bool> IsTokenExpired(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    return true; // Token is considered expired if it cannot be read
                }

                var expiryDateUnix = jwtToken.ValidTo;
                long unixTimestamp = ((DateTimeOffset)expiryDateUnix).ToUnixTimeSeconds();
                DateTimeOffset expiryDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);

                return (expiryDateTimeOffset <= DateTimeOffset.UtcNow); // Check if the expiry time is in the past
            }
            catch (Exception)
            {
                return true; // Token is considered expired if an exception occurs during validation
            }
        }
    }
}

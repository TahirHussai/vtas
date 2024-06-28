using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Sample.BlazorServerAPP.Service;
using System.IdentityModel.Tokens.Jwt;

namespace Sample.BlazorServerAPP.Middleware
{
    public class RefreshTokenService
    {
        private readonly AuthenticationStateProvider _authProvider;
        private readonly IAuthRepository _authService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _nav;

        public RefreshTokenService(NavigationManager nav,ILocalStorageService localStorageService, AuthenticationStateProvider authProvider, IAuthRepository authService)
        {
            _authProvider = authProvider;
            _authService = authService;
            _localStorageService = localStorageService;
            _nav = nav;
        }

        public async Task<string> TryRefreshToken()
        {
            var token = await _localStorageService.GetItemAsync<string>("AuthJwtToken");
            if (token == null)
            {
                _nav.NavigateTo("/");
                return string.Empty;
            }
            // Check token expiration and refresh logic based on your implementation (using JWT, for instance)
            bool isTokenExpired = await IsTokenExpired(token); // Implement your token expiration check logic
          
            //var authState = await _authProvider.GetAuthenticationStateAsync();
            //var user = authState.User;

            //var exp = user.FindFirst(c => c.Type.Equals("exp")).Value;
            //var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

            //var timeUTC = DateTime.UtcNow;

            //var diff = expTime - timeUTC;
            //if (diff.TotalMinutes <= 2)
            if (isTokenExpired)
            {
                try
                {
                    return await _authService.RefreshToken();
                }
                catch (Exception ex)
                {
                    return "Failed to refresh token: " + ex.Message;
                }
            }
            return string.Empty;
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
                var exp = jwtToken.Payload.Exp.Value;
                var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

                var timeUTC = DateTime.UtcNow;

                var diff = expTime - timeUTC;
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

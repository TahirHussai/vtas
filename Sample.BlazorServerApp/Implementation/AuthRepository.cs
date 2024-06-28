using Blazored.LocalStorage;
using Newtonsoft.Json;
using Sample.BlazorServerAPP.AuthProvider;
using Sample.BlazorServerAPP.DTO;
using Sample.BlazorServerAPP.EndPoint;
using Sample.BlazorServerAPP.Service;
using System.Net.Http.Headers;
using System.Text;

namespace Sample.BlazorServerAPP.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationProvider _authenticationProvider;
        public AuthRepository(AuthenticationProvider authenticationProvider, ILocalStorageService localStorageService, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
            _authenticationProvider = authenticationProvider;
        }

        public async Task<bool> Login(LoginDTO dto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, StaticEndPoint.AuthLoginEndpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
            };
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            var content = await response.Content.ReadAsStringAsync();
            var Apiresponse = JsonConvert.DeserializeObject<ResponseDto>(content);
            await _localStorageService.SetItemAsync("AuthJwtToken", Apiresponse.TokenString);
            await _localStorageService.SetItemAsync("AuthRefreshJwtToken", Apiresponse.RefreshToken);
            await _localStorageService.SetItemAsync("Email", Apiresponse.Email);

            // Change auth state of app
            await ((AuthenticationProvider)_authenticationProvider).LoggedIn(Apiresponse.Email);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Apiresponse.TokenString);
            return true;

        }

        public async Task<bool> Register(UserDto dto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, StaticEndPoint.AuthRegisterEndpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
            };
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;

        }
        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("AuthJwtToken");
            await _localStorageService.RemoveItemAsync("AuthRefreshJwtToken");
            await _localStorageService.RemoveItemAsync("Email");
            await ((AuthenticationProvider)_authenticationProvider).LoggedOut();
        }
        public async Task<string> RefreshToken()
        {
            var token = await _localStorageService.GetItemAsync<string>("AuthJwtToken");
            var refreshToken = await _localStorageService.GetItemAsync<string>("AuthRefreshJwtToken");
            var dto = new TokenDto()
            {
                AccessToken = token,
                RefreshToken = refreshToken,
            };
            var request = new HttpRequestMessage(HttpMethod.Post, StaticEndPoint.AuthRefreshEndpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
            };
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Something went wrong during the refresh token action");
            var content = await response.Content.ReadAsStringAsync();
            var Apiresponse = JsonConvert.DeserializeObject<ResponseDto>(content);
            await _localStorageService.SetItemAsync("AuthJwtToken", Apiresponse.TokenString);
            await _localStorageService.SetItemAsync("AuthRefreshJwtToken", Apiresponse.RefreshToken);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Apiresponse.TokenString);

            return Apiresponse.TokenString;
        }
    }
}

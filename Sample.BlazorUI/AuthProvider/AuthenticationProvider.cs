using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Sample.BlazorUI.AuthProvider
{

    public class AuthenticationProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthenticationProvider(JwtSecurityTokenHandler jwtSecurityTokenHandler, ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usr = new ClaimsPrincipal(new ClaimsIdentity());
            var getToken = await _localStorage.GetItemAsync<string>("AuthJwtToken");
            if (getToken == null)
            {
                return new AuthenticationState(usr);
            }
            var token = _jwtSecurityTokenHandler.ReadJwtToken(getToken);
            var claims = token.Claims;
            usr = new ClaimsPrincipal(new ClaimsIdentity(claims, "Jwt"));
            return new AuthenticationState(usr);
        }
        public async Task LoggedIn(string email)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var savedToken = await _localStorage.GetItemAsync<string>("AuthJwtToken");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task LoggedOut()
        {
            await _localStorage.RemoveItemAsync("AuthJwtToken");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await _localStorage.GetItemAsync<string>("AuthJwtToken");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}


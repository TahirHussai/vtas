using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Sample.BlazorUI.Repository.Interface;

namespace Sample.BlazorUI.Middleware
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

       
        
    }
}

using Blazored.LocalStorage;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.BlazorUI.AuthProvider;
using Sample.DTOS;

using Sample.BlazorUI.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using Sample.Common.EndPoint;
using Sample.Services.Implementations;

namespace Sample.BlazorUI.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly LocalStorageService _localStorageService;
        private readonly AuthenticationProvider _authenticationProvider;
        private readonly string _baseUrl;
        public AuthRepository(AuthenticationProvider authenticationProvider, LocalStorageService localStorageService,
            IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
            _authenticationProvider = authenticationProvider;
            _baseUrl = GetBaseUrl(httpClientFactory);
        }

        public async Task<CustomResponseDto> Login(LoginDTO dto)
        {
            var ApiResponse = new CustomResponseDto();
            var role = await _localStorageService.GetItemAsync("LoginUserRole");
            if (!string.IsNullOrEmpty(role))
            {
                dto.Role = role;
            }
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + StaticEndPoint.AuthLoginEndpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
            };
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
           
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            ApiResponse = jsonObject["result"].ToObject<CustomResponseDto>();
            if (ApiResponse != null)
            {
                await SetUserData(content);
            }
         
            //await StoreTokensAndUserData(Apiresponse);

            //// Change auth state of app
            //await ((AuthenticationProvider)_authenticationProvider).LoggedIn(Apiresponse.Email);
            //client.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("bearer", Apiresponse.TokenString);
            return ApiResponse;

        }

        public async Task<bool> GetUserById(string UserId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{StaticEndPoint.GetUserByIdEndpoint}{UserId}");
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                await SetUserData(content);
            }
            return true;
        }
        public async Task<List<UserWithRoleDto>> GetUsersListWithRole()
        {
            var list = new List<UserWithRoleDto>();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{StaticEndPoint.GetUsersEndpoint}");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();
                    var usersList = JsonConvert.DeserializeObject<List<UserWithRoleDto>>(Convert.ToString(respnse.Obj));

                    if (usersList?.Any() == true)
                    {
                        list = usersList;
                    }
                }
            }
            catch (Exception)
            {
                // Optionally log the exception or handle it as needed.
            }

            return list;
        }
        public async Task<List<UserWithRoleDto>> GetCustomerUsersListWithRoles(string CustomerId)
        {
            var list = new List<UserWithRoleDto>();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{StaticEndPoint.GetCustomerUsersEndpoint}{CustomerId}");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();
                    var usersList = JsonConvert.DeserializeObject<List<UserWithRoleDto>>(Convert.ToString(respnse.Obj));
                    if (usersList?.Any() == true)
                    {
                        list = usersList;
                    }
                }
            }
            catch (Exception)
            {
                // Optionally log the exception or handle it as needed.
            }

            return list;
        }

        public async Task<List<UserWithRoleDto>> GetClientUsersWithRoles(string ClientId, string CustomerId)
        {
            var list = new List<UserWithRoleDto>();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{StaticEndPoint.GetClientUsersEndpoint}{ClientId}&&CustomerId={CustomerId}");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var usersList = jsonObject["result"].ToObject<List<UserWithRoleDto>>();

                    if (usersList?.Any() == true)
                    {
                        list = usersList;
                    }
                }
            }
            catch (Exception)
            {
                // Optionally log the exception or handle it as needed.
            }

            return list;
        }

        public async Task<List<UserWithRoleDto>> GetVendorsUsersWithRoles(string VendorId, string CustomerId)
        {
            var list = new List<UserWithRoleDto>();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{StaticEndPoint.GetClientUsersEndpoint}{VendorId}&&CustomerId={CustomerId}");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(content);
                    var usersList = jsonObject["result"].ToObject<List<UserWithRoleDto>>();

                    if (usersList?.Any() == true)
                    {
                        list = usersList;
                    }
                }
            }
            catch (Exception)
            {
                // Optionally log the exception or handle it as needed.
            }

            return list;
        }

        public Task<List<UserWithRoleDto>> GetRecruiterUsersWithRoles(string RecruiterId, string CustomerId)
        {
            throw new NotImplementedException();
        }

        private async Task SetUserData(string content)
        {
          
            var jsonObject = JObject.Parse(content);
            var Apiresponse = jsonObject["result"]["obj"].ToObject<ResponseDto>();
            await _localStorageService.SetItemAsync("CreatedById", Apiresponse.CreatedById);
            await _localStorageService.SetItemAsync("CustomerId", Apiresponse.CustomerId);
            await _localStorageService.SetItemAsync("ParentId", Apiresponse.SuperAdminId);
            await _localStorageService.SetItemAsync("LoginUserId", Apiresponse.UserId);
            await _localStorageService.SetItemAsync("Email", Apiresponse.Email);
            await _localStorageService.SetItemAsync("UserName", Apiresponse.UserName);
            await _localStorageService.SetItemAsync("Role", Apiresponse.Role);
        }

        public async Task<bool> Register(UserDto dto)
        {
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + StaticEndPoint.AuthRegisterEndpoint)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                };
                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("CustomerId");
            await _localStorageService.RemoveItemAsync("LoginUserId");
            await _localStorageService.RemoveItemAsync("ParentId");
            await _localStorageService.RemoveItemAsync("Role");
            await _localStorageService.RemoveItemAsync("UserName");
            await _localStorageService.RemoveItemAsync("CreatedById");
            //await _localStorageService.RemoveItemAsync("AuthJwtToken");
            await _localStorageService.RemoveItemAsync("Email");
            await _localStorageService.RemoveItemAsync("UserStack");
            await ((AuthenticationProvider)_authenticationProvider).LoggedOut();
        }
        public async Task<List<UsersWithRolesDto>> GetUsersWithRolesAsync()
        {

            var usersList = new List<UsersWithRolesDto>();
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}api/Account/users-with-roles");
                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return new List<UsersWithRolesDto>();

                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                usersList = jsonObject["result"]["obj"].ToObject<List<UsersWithRolesDto>>();
                //  usersList = JsonConvert.DeserializeObject<List<UsersWithRolesDto>>(content);
            }
            catch (Exception ex)
            {

                throw;
            }
            return usersList ?? new List<UsersWithRolesDto>();
        }
        private string GetBaseUrl(IHttpClientFactory httpClientFactory)
        {
            // Assuming you have a client named "LocalApi" configured with the base address
            var client = httpClientFactory.CreateClient("LocalApi");
            return client.BaseAddress.ToString();
        }

        public async Task<bool> UpdateUserRoles(UserRoleAssignmentDto dto)
        {
            bool IsSuccess = false;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + StaticEndPoint.UpdateUserRolesEndpoint)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                };
                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    IsSuccess = response.IsSuccessStatusCode;
                }

            }
            catch (Exception ex)
            {

                IsSuccess = false;
            }
            return IsSuccess;
        }



        //private async Task StoreTokensAndUserData(ResponseDto apiResponse)
        //{
        //    //await _localStorageService.SetItemAsync("AuthJwtToken", apiResponse.TokenString);
        //    await _localStorageService.SetItemAsync("Email", apiResponse.Email);

        //    var tokenClaims = ParseJwtToken(apiResponse.TokenString);

        //    await _localStorageService.SetItemAsync("CustomerId", tokenClaims.CustomerId);
        //    await _localStorageService.SetItemAsync("ParentId", tokenClaims.ParentId);
        //    await _localStorageService.SetItemAsync("LoginUserId", tokenClaims.LoginUserId);
        //}

        //private (string CustomerId, string ParentId, string LoginUserId) ParseJwtToken(string token)
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

        //    var customerId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "CustomerId")?.Value;
        //    var parentId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "ParentId")?.Value;
        //    var loginUserId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "LoginUserId")?.Value;

        //    return (customerId, parentId, loginUserId);
        //}
    }
}

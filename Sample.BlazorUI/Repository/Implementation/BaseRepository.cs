using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Sample.DTOS;
using Newtonsoft.Json.Linq;
using Azure;
using Sample.BlazorUI.Repository.Interface;

namespace Sample.BlazorUI.Repository.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService localStorageService;

        public BaseRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            this.localStorageService = localStorageService;
        }

        public async Task<CustomResponseDto> Create(string url, T entity)
        {
            var obj = new CustomResponseDto();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                if (entity == null)
                {
                    obj.Message = "Model cannot be null";
                    obj.IsSuccess = false;
                    return obj;
                }
                request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient();
                //client.DefaultRequestHeaders.Add("Authorization", await GetBearerToken());
                //client.DefaultRequestHeaders.Add("RefreshToken", await GetRefreshToken());
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetBearerToken());
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = respnse.Obj;
                }
            }
            catch (Exception ex)
            {
                obj.IsSuccess = true;
                obj.Message = ex.ToString();
                obj.Obj = null;
            }
            return obj;
        }


        public async Task<CustomResponseDto> Delete(string url, int id)
        {
            var obj = new CustomResponseDto();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, url + id);
                if (id <= 0)
                {
                    obj.Message = "Id must greater than zero";
                    return obj;
                }
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("Authorization", await GetBearerToken());
                //client.DefaultRequestHeaders.Add("RefreshToken", await GetRefreshToken());
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetBearerToken());
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = respnse.Obj;
                }
            }
            catch (Exception ex)
            {
                obj.IsSuccess = true;
                obj.Message = ex.ToString();
                obj.Obj = null;
            }
            return obj;
        }


        public async Task<CustomResponseDto> GetAll(string url)
        {
            var obj = new CustomResponseDto();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var client = _httpClientFactory.CreateClient();
                //var Token = await localStorageService.GetItemAsync<string>("AuthJwtToken");
                //if (!string.IsNullOrEmpty(Token))
                //{
                    
                //    client.DefaultRequestHeaders.Add("Authorization", await GetBearerToken());
                //    //client.DefaultRequestHeaders.Add("RefreshToken", await GetRefreshToken());
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetBearerToken());
                //}
               
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = respnse.Obj;
                }
            }
            catch (Exception ex)
            {
                obj.IsSuccess = true;
                obj.Message = ex.ToString();
                obj.Obj = null;
            }
            return obj;
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto> Update(string url, int id, T entity)
        {
            var obj = new CustomResponseDto();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                if (id <= 0)
                {
                    obj.Message = "Id must be greater than zero";
                    return obj;
                }
                request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient();
                //client.DefaultRequestHeaders.Add("Authorization", await GetBearerToken());
                //client.DefaultRequestHeaders.Add("RefreshToken", await GetRefreshToken());
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetBearerToken());
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = respnse.Obj;
                }
            }
            catch (Exception ex)
            {
                obj.IsSuccess = true;
                obj.Message = ex.ToString();
                obj.Obj = null;
            }
            return obj;
        }

        public async Task<string> GetBearerToken()
        {
            return await localStorageService.GetItemAsync<string>("AuthJwtToken");
        }
        public async Task<string> GetRefreshToken()
        {
            return await localStorageService.GetItemAsync<string>("AuthRefreshJwtToken");
        }
        public async Task<CustomResponseDto> GetById(string url, int id)
        {
            var obj = new CustomResponseDto();
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, url + id);
                var client = _httpClientFactory.CreateClient();
                //client.DefaultRequestHeaders.Add("Authorization", await GetBearerToken());
                // client.DefaultRequestHeaders.Add("RefreshToken", await GetRefreshToken());
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetBearerToken());
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = respnse.Obj;

                }
            }
            catch (Exception ex)
            {
                obj.IsSuccess = true;
                obj.Message = ex.ToString();
                obj.Obj = null;
            }
            return obj;
        }
    }
}


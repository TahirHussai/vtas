using AutoWrapper.Wrappers;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.BlazorUI.Service;
using Sample.Common.EndPoint;
using Sample.DTOS;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace Sample.BlazorUI.Implementation
{
    public class LookUpRepository : ILookUpRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService localStorageService;
        private readonly string _baseUrl;

        public LookUpRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            this.localStorageService = localStorageService;
            _baseUrl = GetBaseUrl(httpClientFactory);
        }
        public async Task<List<PrefixDto>> GetPrefix()
        {
            var list = new List<PrefixDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + StaticEndPoint.GetAllPrefixesEndpoint);
            try
            {

                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(content);
                    var ApiResponse = jsonObject["result"].ToObject<CustomResponseDto>();
                    if (ApiResponse.IsSuccess)
                    {
                        list = JsonConvert.DeserializeObject<List<PrefixDto>>(ApiResponse.Obj.ToString());
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public async Task<List<SufixDto>> GetSuffix()
        {
            var list = new List<SufixDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + StaticEndPoint.GetAllSuffixEndpoint);
            try
            {
                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(content);
                    var ApiResponse = jsonObject["result"].ToObject<CustomResponseDto>();
                    if (ApiResponse.IsSuccess)
                    {
                        list = JsonConvert.DeserializeObject<List<SufixDto>>(ApiResponse.Obj.ToString());
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public async Task<List<EmailTypeDto>> GetEmailType()
        {
            var list = new List<EmailTypeDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + StaticEndPoint.GetAllEmailTypesEndpoint);
            try
            {
                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(content);
                    var ApiResponse = jsonObject["result"].ToObject<CustomResponseDto>();
                    if (ApiResponse.IsSuccess)
                    {
                        list = JsonConvert.DeserializeObject<List<EmailTypeDto>>(ApiResponse.Obj.ToString());
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
        public async Task<List<AddressTypeDto>> GetAddressType()
        {
            var list = new List<AddressTypeDto>();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + StaticEndPoint.GetAllAddressTypesEndpoint);
            try
            {
                var client = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(content);
                    var ApiResponse = jsonObject["result"].ToObject<CustomResponseDto>();
                    if (ApiResponse.IsSuccess)
                    {
                        list = JsonConvert.DeserializeObject<List<AddressTypeDto>>(ApiResponse.Obj.ToString());
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
        private string GetBaseUrl(IHttpClientFactory httpClientFactory)
        {
            // Assuming you have a client named "LocalApi" configured with the base address
            var client = httpClientFactory.CreateClient("LocalApi");
            return client.BaseAddress.ToString();
        }

       
    }

}

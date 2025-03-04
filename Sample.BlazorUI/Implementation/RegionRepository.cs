using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.BlazorUI.Service;
using Sample.Common.EndPoint;
using Sample.DTOS;
using System.Net.Http;
using System.Text;

namespace Sample.BlazorUI.Implementation
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly string _baseUrl;
        public RegionRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
            _baseUrl = GetBaseUrl(httpClient);
        }
        public async Task<CustomResponseDto> Add(RegionDTO dto)
        {
            var obj = new CustomResponseDto();
            try
            {


                var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + StaticEndPoint.RegionCreateEndpoint)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                };
                var client = _client.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = null;
                }

            }
            catch (Exception ex)
            {
                obj.IsSuccess = false;
                obj.Message = ex.ToString();
                obj.Obj = null;

            }
            return obj;
        }
        public async Task<List<RegionDTO>> Get()
        {
            List<RegionDTO> list = new List<RegionDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , StaticEndPoint.RegionGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<RegionDTO>>(contnt);
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public async Task<RegionDTO> GetById(int id)
        {
            RegionDTO list = new RegionDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , StaticEndPoint.RegionGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RegionDTO>(contnt);
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        public async Task<CustomResponseDto> Upate(RegionDTO dto)
        {
            var obj = new CustomResponseDto();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, _baseUrl + StaticEndPoint.RegionUpdateEndpoint)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
                };
                var client = _client.CreateClient();

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(content);
                    var respnse = jsonObject["result"].ToObject<CustomResponseDto>();

                    obj.IsSuccess = true;
                    obj.Message = respnse.Message;
                    obj.Obj = null;
                }

            }
            catch (Exception ex)
            {


                obj.IsSuccess = false;
                obj.Message = ex.ToString();
                obj.Obj = null;

            }
            return obj;
        }
        private string GetBaseUrl(IHttpClientFactory httpClientFactory)
        {
            // Assuming you have a client named "LocalApi" configured with the base address
            var client = httpClientFactory.CreateClient("LocalApi");
            return client.BaseAddress.ToString();
        }
    }
}

using Blazored.LocalStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.BlazorUI.Repository.Implementation;
using Sample.BlazorUI.Services.Interface;
using Sample.Common.EndPoint;
using Sample.DTOS;
using System.Net.Http;
using System.Text;

namespace Sample.BlazorUI.Services.Implementation
{
    public class RegionService : BaseRepository<RegionDTO>, IRegionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;

        public RegionService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
            : base(httpClientFactory, localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = GetBaseUrl(httpClientFactory);
        }
        public async Task<CustomResponseDto> Add(RegionDTO dto)
        {

            return await Create(_baseUrl + StaticEndPoint.RegionCreateEndpoint, dto);

        }
        public async Task<CustomResponseDto> Get()
        {
            return await GetAll(_baseUrl + StaticEndPoint.RegionGetEndPoint);
        }

        public async Task<CustomResponseDto> GetById(int id)
        {
            return await GetById(_baseUrl + StaticEndPoint.RegionGetByIdEndPoint, id);
        }
        public async Task<CustomResponseDto> Upate(RegionDTO dto)
        {
            return await Update(_baseUrl + StaticEndPoint.RegionUpdateEndpoint, dto.RegionID, dto);
        }

        private string GetBaseUrl(IHttpClientFactory httpClientFactory)
        {
            // Assuming you have a client named "LocalApi" configured with the base address
            var client = httpClientFactory.CreateClient("LocalApi");
            return client.BaseAddress.ToString();
        }

    }
}

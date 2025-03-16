using Blazored.LocalStorage;
using Sample.BlazorUI.Repository.Implementation;
using Sample.BlazorUI.Services.Interface;
using Sample.Common.EndPoint;
using Sample.DTOS;

namespace Sample.BlazorUI.Services.Implementation
{
    public class SectorServices:BaseRepository<SectorDto>, ISectorServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;

        public SectorServices(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
            : base(httpClientFactory, localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = GetBaseUrl(httpClientFactory);
        }
        public async Task<CustomResponseDto> Add(SectorDto dto)
        {

            return await Create(_baseUrl + StaticEndPoint.SectorCreateEndpoint, dto);

        }
        public async Task<CustomResponseDto> Get()
        {
            return await GetAll(_baseUrl + StaticEndPoint.SectorGetEndPoint);
        }

        public async Task<CustomResponseDto> GetById(int id)
        {
            return await GetById(_baseUrl + StaticEndPoint.SectorGetByIdEndPoint, id);
        }
        public async Task<CustomResponseDto> Upate(SectorDto dto)
        {
            return await Update(_baseUrl + StaticEndPoint.SectorUpdateEndpoint, dto.SectorID, dto);
        }

        private string GetBaseUrl(IHttpClientFactory httpClientFactory)
        {
            // Assuming you have a client named "LocalApi" configured with the base address
            var client = httpClientFactory.CreateClient("LocalApi");
            return client.BaseAddress.ToString();
        }
    }
}

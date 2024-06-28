using Blazored.LocalStorage;
using Newtonsoft.Json;
using Sample.BlazorServerAPP.DTO;
using Sample.BlazorServerAPP.Service;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace Sample.BlazorServerAPP.Implementation
{
    public class ProductRepository : BaseRepository<ProductDTO>, IProductRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService) : base(httpClientFactory, localStorageService)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ProductCategoryCountDTO>> getProductsByCategory(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetBearerToken());
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ProductCategoryCountDTO>>(content);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

       
    }
}


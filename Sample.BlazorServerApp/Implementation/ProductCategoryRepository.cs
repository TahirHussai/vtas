using Blazored.LocalStorage;
using Sample.BlazorServerAPP.DTO;
using Sample.BlazorServerAPP.Service;

namespace Sample.BlazorServerAPP.Implementation
{

    public class ProductCategoryRepository : BaseRepository<ProductCategoriesDTO>, IProductCategoryRepository

    {
        public ProductCategoryRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService) : base(httpClientFactory, localStorageService)
        {
        }
        public IList<ProductCategoriesDTO> getProductsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }

}


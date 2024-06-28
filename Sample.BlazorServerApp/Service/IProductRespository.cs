using Sample.BlazorServerAPP.DTO;

namespace Sample.BlazorServerAPP.Service
{
    public interface IProductRepository : IBaseRepository<ProductDTO>
    {
      Task<List<ProductCategoryCountDTO>> getProductsByCategory(string url);
    }
}

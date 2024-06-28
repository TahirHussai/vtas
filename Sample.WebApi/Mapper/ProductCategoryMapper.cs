using AutoMapper;
using Sample.WebApi.DTO;
using Sample.WebApi.Migrations;

namespace Sample.WebApi.Mapper
{
    public class ProductCategoryMapper : Profile
    {
        public ProductCategoryMapper()
        {
            CreateMap<ProductCategoriesDTO, ProductCategory>().ReverseMap();
        }
    }
}

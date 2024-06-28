using AutoMapper;
using Sample.WebApi.DTO;
using Sample.WebApi.Models;

namespace Sample.WebApi.Mapper
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDTO, Products>().ReverseMap();
        }
    }
}

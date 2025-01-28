using AutoMapper;
using Sample.Data;
using Sample.DTOS;

namespace Sample.Mapper.MaperConfig
{
    public class UserPofileMapper:Profile
    {
        public UserPofileMapper() {
            CreateMap<UserDto, UserPofile>().ReverseMap();
            CreateMap<UserPofile, UserDto>().ReverseMap();
            CreateMap<UserCustomerDto, UserPofile>().ReverseMap();
            CreateMap<UserClientDto, UserPofile>().ReverseMap();
        }
    }
}

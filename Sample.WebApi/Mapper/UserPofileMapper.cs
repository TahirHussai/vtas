using AutoMapper;
using Sample.DTOS;
using Sample.WebApi.Models;

namespace Sample.WebApi.Mapper
{
    public class UserPofileMapper:Profile
    {
        public UserPofileMapper() {
            CreateMap<UserDto, UserPofile>().ReverseMap();
        }
    }
}

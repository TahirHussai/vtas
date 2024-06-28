using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sample.WebApi.DTO;

namespace Sample.WebApi.Mapper
{
    public class IdentityRoleMapper:Profile
    {
        public IdentityRoleMapper()
        {
            CreateMap<RoleDTO, IdentityRole>().ReverseMap();
        }
    }
}

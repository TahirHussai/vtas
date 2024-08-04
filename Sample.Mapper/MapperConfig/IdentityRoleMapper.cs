using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sample.DTOS;

namespace Sample.Mapper.MaperConfig
{
    public class IdentityRoleMapper:Profile
    {
        public IdentityRoleMapper()
        {
            CreateMap<RoleDTO, IdentityRole>().ReverseMap();
        }
    }
}

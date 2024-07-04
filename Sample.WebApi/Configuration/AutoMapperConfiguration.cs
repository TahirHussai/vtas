using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sample.DTOS;
using Sample.WebApi.Mapper;
using Sample.WebApi.Models;
using System.Runtime.CompilerServices;

namespace Sample.WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfigurator(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(a =>
            {
              
                a.AddProfile(new IdentityRoleMapper());
                a.AddProfile(new UserPofileMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
       
    }
}

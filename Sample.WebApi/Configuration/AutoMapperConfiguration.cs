using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sample.WebApi.DTO;
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
                a.AddProfile(new ProductMapper());
                a.AddProfile(new ScreensPermissionMapper());
                a.AddProfile(new IdentityRoleMapper());
                a.AddProfile(new ProductCategoryMapper());
                a.AddProfile(new UserPofileMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
       
    }
}

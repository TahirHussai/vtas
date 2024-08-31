
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sample.Data;
using Sample.Mapper.MaperConfig;
using Sample.Mapper.MapperConfig;
using System.Runtime.CompilerServices;

namespace Sample.Mapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfigurator(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(a =>
            {
              
                a.AddProfile(new IdentityRoleMapper());
                a.AddProfile(new UserPofileMapper());
                a.AddProfile(new OtherDetailsMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
       
    }
}

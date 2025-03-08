using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Data;
using Sample.Services.Implementations;
using Sample.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            // Add custom services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IEmailAddressService, EmailAddressService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IOtherDetailsService, OtherDetailsService>();
            services.AddScoped<IRegionService, RegionService>();

           
        }
    }
}

using Application.DTOs;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class AppInjector
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //auto mapper
            services.AddAutoMapper(
                typeof(ChannelManagerMappingProfile),
                typeof(ContentCatalogMappingProfile),
                typeof(ScheduleMappingProfile));

            //validators
            services.AddFluentValidationAutoValidation();
        }
    }
}

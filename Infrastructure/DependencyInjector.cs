using Application.Interfaces;
using Domain.Repository.Interface;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjector
    {
        public static void AddAppService(this IServiceCollection services, IConfiguration config)
        {
            //Configurations
            services.Configure<JsonStorageOptions>(settings => config.GetSection("JsonStorage"));

            //Repositories
            services.AddTransient<IContentCatalogRepository>(provider =>
            {
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
                string relatedPath = provider.GetRequiredService<IConfiguration>().GetValue<string>("JsonStorage:ContentCatalogPath")!;
                string filePath = Path.Combine(projectRoot, "Infrastructure", "Data", relatedPath);
                return new ContentCatalogRepository(filePath!);
            });
            services.AddTransient<IChannelManagerRepository>(provider =>
            {
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
                string relatedPath = provider.GetRequiredService<IConfiguration>().GetValue<string>("JsonStorage:ChannelManagerPath")!;
                string filePath = Path.Combine(projectRoot, "Infrastructure", "Data", relatedPath);
                return new ChannelManagerRepository(filePath!);
            });
            services.AddTransient<IScheduleRepository>(provider =>
            {
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
                string relatedPath = provider.GetRequiredService<IConfiguration>().GetValue<string>("JsonStorage:SchedulePath")!;
                string filePath = Path.Combine(projectRoot, "Infrastructure", "Data", relatedPath);
                return new ScheduleRepository(filePath!);
            });


            //Services
            services.AddScoped<IChannelManagerService, ChannelManagerService>();
            services.AddScoped<IContentCatalogService, ContentCatalogService>();
            services.AddScoped<IScheduleService, ScheduleService>();
        }
    }
}

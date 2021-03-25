using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Services;

namespace NetCoreCleanCode.Application
{
    public static class ApplicationDependencies
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMediatorService, MediatorService>();
        }
    }
}
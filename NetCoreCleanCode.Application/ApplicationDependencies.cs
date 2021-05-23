using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Factories;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Services;
using NetCoreCleanCode.Domain.Extensions;

namespace NetCoreCleanCode.Application
{
    public static class ApplicationDependencies
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMediatorService, MediatorService>();
            services.AddScoped<IQueryHandlerFactory, QueryHandlerFactory>();
            
            RegisterQueryHandlers(services);
        }

        private static void RegisterQueryHandlers(IServiceCollection services)
        {
            var handlerType = typeof(IQueryHandler<,>).GetGenericTypeDefinition();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            var assemblyTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .ToList();

            var queryTypes = assemblyTypes.Where(assemblyType => assemblyType.ImplementsInterface(typeof(IQuery<>)));

            foreach (var queryType in queryTypes)
            {
                var implementationType = assemblyTypes.FirstOrDefault(assemblyType =>
                    assemblyType.ImplementsGenericInterface(handlerType, queryType) != null);

                var interfaceType = implementationType.ImplementsGenericInterface(handlerType, queryType);

                if (implementationType != null)
                {
                    services.AddScoped(interfaceType, implementationType);
                }
            }
        }
    }
}
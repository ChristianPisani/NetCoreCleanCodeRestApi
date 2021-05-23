using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Factories;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Application.Services;
using NetCoreCleanCode.Domain.Extensions;
using NetCoreCleanCode.Domain.TodoList.Models;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Application
{
    public static class ApplicationDependencies
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMediatorService, MediatorService>();
            services.AddScoped<IQueryHandlerFactory, QueryHandlerFactory>();

            var serviceType = typeof(IQueryHandler<GetWeatherForecastsQuery, WeatherForecastModel>);
            var impType = typeof(GetWeatherForecastsQueryHandler);
            
            //services.AddScoped(serviceType, impType);
            //services.AddScoped<IQueryHandler<GetWeatherForecastsQuery, WeatherForecastModel>, GetWeatherForecastsQueryHandler>();
            //services.AddScoped<IQueryHandler<GetTodoListsQuery, IEnumerable<TodoListModel>>, GetTodolistsQueryHandler>();
            
            
            var handlerType = typeof(IQueryHandler<,>).GetGenericTypeDefinition();
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assemblyTypes = assemblies.SelectMany(assembly => assembly.GetTypes());

            var queryTypes = assemblyTypes?.Where(assemblyType => assemblyType.ImplementsInterface(typeof(IQuery<>)));

            foreach (var queryType in queryTypes)
            {
                var implementationType = assemblyTypes.FirstOrDefault(assemblyType =>
                    assemblyType.ImplementsGenericInterface(handlerType, queryType) != null);

                var interfaceType = implementationType.ImplementsGenericInterface(handlerType, queryType);

                if (interfaceType == serviceType && implementationType == impType)
                {
                    var s = "";
                }
                
                if (implementationType != null)
                {
                    services.AddScoped(interfaceType, implementationType);
                }

                if (implementationType == null)
                {
                    // throw new Exception("No query handler implementation found");
                }   
            }
        }
    }
}
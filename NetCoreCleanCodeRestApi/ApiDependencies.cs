using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Application.Services;
using NetCoreCleanCode.Domain.TodoList.Models;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCodeRestApi
{
    public static class ApiDependencies
    {
        public static void ConfigureApiDependencies(this IServiceCollection services)
        {
            

            //services.AddScoped(typeof(IQueryHandler<,>), typeof(GetWeatherForecastsQueryHandler));
            //services.AddScoped(typeof(IQueryHandler<>), typeof(GetWeatherForecastsQueryHandler<>));
            //services.AddScoped(typeof(IQueryHandler<>), typeof(GetTodolistsQueryHandler<>));

            services.AddSingleton<IQueryHandlerFactory, QueryHandlerFactoryService>();
            services.AddScoped<IQueryHandler<GetWeatherForecastsQuery, WeatherForecast>, GetWeatherForecastsQueryHandler>();
            services.AddScoped<IQueryHandler<GetTodoListsQuery, IEnumerable<TodoList>>, GetTodolistsQueryHandler>();
        }
    }
}
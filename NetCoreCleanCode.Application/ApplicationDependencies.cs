using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Factories;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Application.Services;
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
            
            services.AddScoped<IQueryHandler<IQuery<WeatherForecastModel>>, GetWeatherForecastsQueryHandler>();
            services.AddScoped<IQueryHandler<IQuery<IEnumerable<TodoListModel>>>, GetTodolistsQueryHandler>();
        }
    }
}
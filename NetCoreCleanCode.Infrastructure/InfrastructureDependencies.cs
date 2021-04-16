using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Domain.TodoList.Models;
using NetCoreCleanCode.Domain.WeatherForecast.Models;
using NetCoreCleanCode.Infrastructure.TodoList.Repositories;
using NetCoreCleanCode.Infrastructure.WeatherForecast.Services;

namespace NetCoreCleanCode.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static void ConfigureInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApiService<GetWeatherForecastsQuery, WeatherForecastModel>, WeatherForecastApiService>();
            services.AddScoped<IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>>, TodoListRepository>();
            //services.AddScoped<IApiService<Domain.TodoList.Models.TodoList>, TodoListService>();
        }
    }
}
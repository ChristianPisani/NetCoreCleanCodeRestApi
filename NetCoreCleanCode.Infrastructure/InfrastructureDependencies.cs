using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;
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
            services.AddScoped<IApiService<WeatherForecastModel>, WeatherForecastApiService>();
            services.AddScoped<IDataRepository<TodoListModel>, TodoListRepository>();
            services.AddScoped<IDataRepository<IEnumerable<TodoListModel>>, TodoListRepository>();
        }
    }
}
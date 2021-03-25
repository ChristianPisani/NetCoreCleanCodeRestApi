using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Infrastructure.TodoList.Repositories;
using NetCoreCleanCode.Infrastructure.WeatherForecast.Services;

namespace NetCoreCleanCode.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static void ConfigureInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IApiService<Domain.WeatherForecast.Models.WeatherForecast>, WeatherForecastApiService>();
            services.AddScoped<IDataRepository<IEnumerable<Domain.TodoList.Models.TodoList>>, TodoListRepository>();
            //services.AddScoped<IApiService<Domain.TodoList.Models.TodoList>, TodoListService>();
        }
    }
}
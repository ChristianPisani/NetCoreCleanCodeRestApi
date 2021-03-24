using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces.Repositories;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Infrastructure.WeatherForecast.Services
{
    public class WeatherForecastApiService : IExternalApiService<Domain.WeatherForecast.Models.WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        // Pretend this comes from an external api
        public async Task<IEnumerable<Domain.WeatherForecast.Models.WeatherForecast>> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Domain.WeatherForecast.Models.WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    Temperature = Temperature.FromC(rng.Next(-20, 55)),
                    Summary = Summaries[rng.Next(Summaries.Length)] // We pretend this also comes from external api
                });
        }
    }
}
﻿using System;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.Base;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Infrastructure.WeatherForecast.Services
{
    public class WeatherForecastApiService : IApiService<WeatherForecastModel>
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        // Pretend this comes from an external api
        public async Task<WeatherForecastModel> Get(IQuery<WeatherForecastModel> query)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
                {
                    Date = DateTime.Now.AddDays(index),
                    Temperature = Temperature.FromC(rng.Next(-20, 55)),
                    Summary = Summaries[rng.Next(Summaries.Length)] // We pretend this also comes from external api
                })
                .First();
        }
    }
}
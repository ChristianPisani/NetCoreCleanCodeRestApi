using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Interfaces.Repositories;

namespace NetCoreCleanCode.Application.Queries.WeatherForecast
{
    public class GetWeatherForecastsQueryHandler<T> : IQueryHandler<T>
    {
        private readonly IExternalApiService<Domain.WeatherForecast.Models.WeatherForecast> _externalApiService;
        
        public GetWeatherForecastsQueryHandler(IExternalApiService<Domain.WeatherForecast.Models.WeatherForecast> externalApiService)
        {
            _externalApiService = externalApiService;
        }
        
        public Type QueryType => typeof(GetWeatherForecastsQuery);

        public async Task<IEnumerable<TOut>> Handle<TOut>(IQuery<IEnumerable<TOut>> query)
        {
            return await _externalApiService.Get() as IEnumerable<TOut>;
        }
    }
}
using System.Collections.Generic;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Queries.WeatherForecast
{
    public class GetWeatherForecastsQuery : IQuery<IEnumerable<Domain.WeatherForecast.Models.WeatherForecast>> { }
}
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.Base;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Application.Queries.WeatherForecast
{
    public class GetWeatherForecastsQueryHandler : IQueryHandler<IQuery<WeatherForecastModel>>
     {
        private readonly IApiService<GetWeatherForecastsQuery, WeatherForecastModel> _apiService;
        
        public GetWeatherForecastsQueryHandler(IApiService<GetWeatherForecastsQuery, WeatherForecastModel> apiService)
        {
            _apiService = apiService;
        }

        public async Task<TOut> Handle<TOut>(IQuery<TOut> query) where TOut : class
        {
            return await _apiService.Get(query);
        }
     }
}
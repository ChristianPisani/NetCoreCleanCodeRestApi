using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.Base;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Application.Queries.WeatherForecast
{
    public class GetWeatherForecastsQueryHandler : QueryHandler<GetWeatherForecastsQuery, WeatherForecastModel>
     {
        private readonly IApiService<GetWeatherForecastsQuery, WeatherForecastModel> _apiService;
        
        public GetWeatherForecastsQueryHandler(IApiService<GetWeatherForecastsQuery, WeatherForecastModel> apiService)
        {
            _apiService = apiService;
        }

        public override async Task<WeatherForecastModel> Handle(GetWeatherForecastsQuery query)
        {
            return await _apiService.Get(query);
        }
     }
}
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Queries.WeatherForecast
{
    public class GetWeatherForecastsQueryHandler : QueryHandler<GetWeatherForecastsQuery, Domain.WeatherForecast.Models.WeatherForecast>
     {
        private readonly IApiService<Domain.WeatherForecast.Models.WeatherForecast> _apiService;
        
        public GetWeatherForecastsQueryHandler(IApiService<Domain.WeatherForecast.Models.WeatherForecast> apiService)
        {
            _apiService = apiService;
        }
        
        public override async Task<Domain.WeatherForecast.Models.WeatherForecast> Handle(GetWeatherForecastsQuery query)
        {
            return await _apiService.Get();
        }
    }
}
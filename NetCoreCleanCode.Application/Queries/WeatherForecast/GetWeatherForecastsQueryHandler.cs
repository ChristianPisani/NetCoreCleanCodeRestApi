using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Application.Queries.WeatherForecast
{
    public class GetWeatherForecastsQueryHandler : IQueryHandler<GetWeatherForecastsQuery, WeatherForecastModel>
     {
        private readonly IApiService<WeatherForecastModel> _apiService;
        
        public GetWeatherForecastsQueryHandler(IApiService<WeatherForecastModel> apiService)
        {
            _apiService = apiService;
        }

        public async Task<WeatherForecastModel> Handle(GetWeatherForecastsQuery query)
        {
            return await _apiService.Get(query);
        }
     }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCodeRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediatorService _mediatorService; 

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMediatorService mediatorService)
        {
            _logger = logger;
            _mediatorService = mediatorService;
        }

        [HttpGet]
        public async Task<WeatherForecastModel> Get([FromQuery]GetWeatherForecastsQuery query)
        {
            var result = await _mediatorService.Send(query);
            
            return result;
        }
    }
}
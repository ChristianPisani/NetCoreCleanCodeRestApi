using System;
using NetCoreCleanCode.Domain.Base;

namespace NetCoreCleanCode.Domain.WeatherForecast.Models
{
    public class WeatherForecastModel
    {
        public DateTime? Date { get; set; }

        public Temperature Temperature { get; set; }

        public string Summary { get; set; }
    }
}
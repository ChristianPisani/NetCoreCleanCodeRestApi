using System;

namespace NetCoreCleanCode.Domain.WeatherForecast.Models
{
    public class WeatherForecast
    {
        public DateTime? Date { get; set; }

        public Temperature Temperature { get; set; }

        public string Summary { get; set; }
    }
}
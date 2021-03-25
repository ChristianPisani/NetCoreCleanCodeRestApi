using System;
using NetCoreCleanCode.Domain.Common.Interfaces;

namespace NetCoreCleanCode.Domain.WeatherForecast.Models
{
    public class WeatherForecast : ICoreModel
    {
        public DateTime? Date { get; set; }

        public Temperature Temperature { get; set; }

        public string Summary { get; set; }
    }
}
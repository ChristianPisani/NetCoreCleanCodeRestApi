using NetCoreCleanCode.Domain.Base;

namespace NetCoreCleanCode.Domain.WeatherForecast.Models
{
    public class Temperature
    {
        public int C { get; private set; }

        public int F => 32 + (int) (C / 0.5556);

        public static Temperature FromC(int c)
        {
            return new Temperature(c);
        }
        
        private Temperature(int c)
        {
            C = c;
        }
    }
}
using System;

namespace ApiNetSandBox
{
    public class WeatherForecast
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;



namespace ApiNetSandBox.Controllers
{
    /// <summary>
    /// Controller that allows us to get weather forecast.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;

        /// <summary>
        /// Getting weather forecast for 5 days.
        /// </summary>
        /// <returns>
        /// Enumerable of weather forecast objects.
        /// </returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=45.657974&lon=25.601198&exclude=hourly,minutely&appid=0dfcffd1563d03d0c8e4d517f5dc8017");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);
        }

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int numberOfDays = 5)
        {
            var json = JObject.Parse(content);
            return Enumerable.Range(1, numberOfDays).Select(index =>
            {
                var jsonDailyForecast = json["daily"][index];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyForecast),
                    Summary = weatherSummary
                };
            })
           
            .ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyForecast)
        {
            return (int)Math.Round(jsonDailyForecast["temp"].Value<float>("day") - KELVIN_CONST);
        }
    }

    public class CurrentWeatherController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?q=London&appid=0dfcffd1563d03d0c8e4d517f5dc8017");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToCurrentWeather(response.Content);
        }

        public IEnumerable<WeatherForecast> ConvertResponseToCurrentWeather(string content)
        {
            var json = JObject.Parse(content);
            return Enumerable.Range(1, 1).Select(index =>
            {
                var longitude = json["coord"].Value<double>("lon");
                var latitude = json["coord"].Value<double>("lat");
                var unixDateTime = json.Value<long>("dt");
                var weatherSummary = json["weather"][0].Value<string>("main");
                var currentTemperature = json["main"];
                return new WeatherForecast
                {
                    Longitude = longitude,
                    Latitude = latitude,
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(currentTemperature),
                    Summary = weatherSummary
                };
            })

            .ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken curentTemperature)
        {
            return (int)Math.Round(curentTemperature.Value<float>("temp") - KELVIN_CONST);
        }
    }
}

using ApiNetSandBox;
using ApiNetSandBox.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using Xunit;

namespace ApiNetSandbox.Tests
{
    /// <summary>
    /// This is a test suite used for WeatherForecast Controller.
    /// </summary>
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();


            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);


            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(18, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForTomorrow.Date);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();


            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);


            // Assert
            var weatherForecastForAfterTomorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastForAfterTomorrow.Summary);
            Assert.Equal(20, weatherForecastForAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastForAfterTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.WeatherForecastDataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}

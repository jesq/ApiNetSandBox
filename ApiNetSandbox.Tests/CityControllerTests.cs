using ApiNetSandBox;
using ApiNetSandBox.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using Xunit;


namespace ApiNetSandbox.Tests
{
    public class CityControllerTests
    {
        [Fact]
        public void ShouldHaveLondonCoordinates()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new CurrentWeatherController();


            // Act
            var output = controller.ConvertResponseToCurrentWeather(content);


            // Assert
            var currentWeatherForecast = ((WeatherForecast[])output)[0];
            Assert.Equal(-0.1257, currentWeatherForecast.Longitude);
            Assert.Equal(51.5085, currentWeatherForecast.Latitude);
        }

        [Fact]
        public void ShouldHaveBucharestCoordinates()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new CurrentWeatherController();


            // Act
            var output = controller.ConvertResponseToCurrentWeather(content);


            // Assert
            var currentWeatherForecast = ((WeatherForecast[])output)[0];
            Assert.Equal(26.096306, currentWeatherForecast.Longitude);
            Assert.Equal(44.439663, currentWeatherForecast.Latitude);
        }

        [Fact]
        public void ShouldHaveBrasovCoordinates()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new CurrentWeatherController();


            // Act
            var output = controller.ConvertResponseToCurrentWeather(content);


            // Assert
            var currentWeatherForecast = ((WeatherForecast[])output)[0];
            Assert.Equal(25.601198, currentWeatherForecast.Longitude);
            Assert.Equal(45.657974, currentWeatherForecast.Latitude);
        }
        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.CurrentWeatherDataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}

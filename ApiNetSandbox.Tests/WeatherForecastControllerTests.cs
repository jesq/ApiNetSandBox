using ApiNetSandBox;
using ApiNetSandBox.Controllers;
using System;
using Xunit;

namespace ApiNetSandbox.Tests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = "";
            var controller = new WeatherForecastController();


            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);


            // Assert
            Assert.Equal("rainy", ((WeatherForecast[])output)[0].Summary);
        }
    }
}

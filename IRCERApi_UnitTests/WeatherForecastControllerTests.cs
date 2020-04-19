using Autofac.Extras.Moq;
using Castle.Core.Logging;
using IRCERApi.Controllers;
using System.Linq;
using Xunit;

namespace IRCERApi_UnitTests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ShouldReturnAListOfForecasts()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                mock.Mock<ILogger>();

                var sut = mock.Create<WeatherForecastController>();

                //Act

                var result = sut.Get();

                //Assert

                Assert.True(result != null);

                Assert.True(result.Count() > 3);
            }
        }
    }
}
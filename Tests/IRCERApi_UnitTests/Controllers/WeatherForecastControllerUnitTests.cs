using Autofac.Extras.Moq;
using Castle.Core.Logging;
using System.Linq;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
	public class WeatherForecastControllerUnitTests
	{
		[Fact]
		public void Get_ShouldReturnAListOfForecasts()
		{
			//Arrange

			using var mock = AutoMock.GetLoose();

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

using Autofac.Extras.Moq;
using FluentAssertions;
using IRCERApi.Library.Data;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IRCERApi.Data.UnitTests
{
	public class WeatherForecastServiceUnitTests
	{
		[Fact]
		public async Task GetForecastAsync_TestAsync()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var startDate = DateTime.Now;

				var sut = mock.Create<WeatherForecastService>();

				//Act

				var result = await sut.GetForecastAsync(startDate);

				//Assert

				sut.Should().NotBeNull();

				result.Should().NotBeNull();

				result.Length.Should().BeGreaterThan(4);
			}
		}
	}
}

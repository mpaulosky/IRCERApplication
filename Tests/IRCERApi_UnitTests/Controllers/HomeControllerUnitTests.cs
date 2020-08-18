using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
	public class HomeControllerUnitTests
	{
		[Fact()]
		public void Index_ReturnsView_Test()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var sut = mock.Create<HomeController>();

				//Act

				var result = sut.Index();

				//Assert

				Assert.IsType<ViewResult>(result);

				Assert.True(result != null);
			}
		}

		[Fact]
		public void Privacy_ReturnsView_Test()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var sut = mock.Create<HomeController>();

				//Act

				var result = sut.Privacy();

				//Assert

				Assert.IsType<ViewResult>(result);

				Assert.True(result != null);
			}
		}

		//[Fact]
		//public void Error_ReturnsView_Test()
		//{
		//    using (var mock = AutoMock.GetLoose())
		//    {
		//        //Arrange

		//        var sut = mock.Create<HomeController>();

		//        //Act

		//        Action act = () => sut.Error();

		//        //Assert

		//        //act.Should().Throw<NullReferenceException>().WithMessage("Object reference not set to an instance of an object.");

		//        Assert.IsType<ViewResult>(act);
		//    }
		//}
	}
}

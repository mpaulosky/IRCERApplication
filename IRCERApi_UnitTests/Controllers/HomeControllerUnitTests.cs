using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
    public class HomeControllerUnitTests
    {
        [Fact(DisplayName = "")]
        public void Index_ReturnsView()
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
        public void Privacy_ReturnsView()
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

        // ToDo figure out how to test this Action event
        //[Fact]
        //public void Error_ReturnsView()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        //Arrange

        //        var sut = mock.Create<HomeController>();

        //        //Act

        //        var result = sut.Error();

        //        //Assert

        //        Assert.IsType<ViewResult>(result);

        //        Assert.True(result != null);
        //    }
        //}
    }
}
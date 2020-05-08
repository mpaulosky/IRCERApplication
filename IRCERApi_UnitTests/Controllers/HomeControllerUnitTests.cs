using Autofac.Extras.Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Fact]
        public void Error_ReturnsView()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var sut = mock.Create<HomeController>();

                //Act

                Action act = () => sut.Error();

                //Assert

                act.Should().Throw<NullReferenceException>()
                    .WithMessage("Object reference not set to an instance of an object.");
            }
        }
    }
}
using Autofac.Extras.Moq;
using IRCERDataManager.Library.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using TestHelpers;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
    public class UserControllerUnitTests
    {
        [Theory]
        [InlineData("Tim.Corey@corey.org")]
        [InlineData("Charity.Corey@corey.org")]
        [InlineData("Jon.Corey@corey.org")]
        [InlineData("Chris.Corey@corey.org")]
        public void GetById_ShouldReturnTheLoggedOnUser_Test(string userName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userData = MockHelpers.GetSamplePeople().Where(a => a.Id == userName).ToList();

                mock.Mock<IUserData>()
                    .Setup(x => x.GetUserById(userName))
                    .Returns(userData);

                var sut = mock.Create<UserController>();

                SetupUser(sut, userName);

                //Act

                var result = sut.GetById();

                //Assert

                Assert.True(result != null);

                Assert.Equal(userName, sut.User.Identity.Name);

                Assert.Equal(userName, result.Id);
            }
        }

        //[Fact()]
        //public void GetAllUsers_Test()
        //{
        //    //Arrange

        //    //Act

        //    //Assert

        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void GetAllRoles_Test()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        //Arrange

        //        var user = new IdentityUser
        //        {
        //            Id = "123",
        //            UserName = "test@test.com",
        //            PasswordHash = "test",
        //            Email = "test@test.com"
        //        };

        //        var context = new Mock<ApplicationDbContext>();
        //        var logger = new Mock<ILogger<UserController>>();
        //        var userData = new Mock<IUserData>();
        //        var userManager = MockHelpers.MockUserManager<IdentityUser>();
        //        userManager.Setup(x => x.GetRolesAsync(user)).Returns(() => GetSampleIdentityRoles());

        //        var sut = new UserController(context.Object, userManager.Object, userData.Object, logger.Object);

        //        //Act

        //        //var results = sut.GetAllRoles();

        //        //Assert

        //        Assert.Equal(2, results.Count);
        //    }
        //}

        //[Fact()]
        //public void AddARole_Test()
        //{
        //    //Arrange

        //    //Act

        //    //Assert

        //    Assert.True(false, "This test needs an implementation");
        //}

        //[Fact()]
        //public void RemoveARole_Test()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        //Arrange

        //        //Act

        //        //Assert

        //        Assert.True(false, "This test needs an implementation");
        //    }
        //}

        private void SetupUser(UserController sut, string userName)
        {
            var mockContext = new Mock<HttpContext>(MockBehavior.Loose);
            mockContext.SetupGet(hc => hc.User.Identity.Name).Returns(userName);
            mockContext.SetupGet(hc => hc.User.Identity.IsAuthenticated).Returns(true);
            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
        }
    }
}
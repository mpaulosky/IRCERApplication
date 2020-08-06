using Autofac.Extras.Moq;
using FluentAssertions;
using IRCERApi.Data;
using IRCERApiDataManager.Library.DataAccess;
using IRCERApiDataManager.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using System.Threading;
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
                    .Setup(x => x.GetUserById(userData[0].Id))
                    .Returns(userData);

                var sut = mock.Create<UserController>();

                MockHelpers.SetupUser(sut, userName);

                //Act

                var result = sut.GetById();

                //Assert

                result.Should().NotBeNull();

                sut.User.Identity.Name.Should().BeEquivalentTo(userName);

                result.Id.Should().BeEquivalentTo(userName);
            }
        }

        [Fact()]
        public void GetAllUsers_ShouldReturnAllUsers_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userData = MockHelpers.GetSamplePeople();

                var userRoles = MockHelpers.GetSampleIdentityUserRoles();

                var mockUserRoles = MockHelpers.CreateDbSetMock(userRoles);

                var users = MockHelpers.GetSampleIdentityUsers();

                var mockUsers = MockHelpers.CreateDbSetMock(users);

                var roles = MockHelpers.GetIdentityRoles();

                var mockRoles = MockHelpers.CreateDbSetMock(roles);

                mock.Mock<ApplicationDbContext>().Setup(x => x.Roles).Returns(mockRoles.Object);
                mock.Mock<ApplicationDbContext>().Setup(x => x.Users).Returns(mockUsers.Object);
                mock.Mock<ApplicationDbContext>().Setup(x => x.UserRoles).Returns(mockUserRoles.Object);

                mock.Mock<IUserData>()
                    .Setup(x => x.GetUserById(userData[0].Id))
                    .Returns(userData);

                var sut = mock.Create<UserController>();

                MockHelpers.SetupUser(sut, userData[0].Id);

                //Act

                var results = sut.GetAllUsers();

                //Assert

                sut.Should().NotBeNull();

                results.Count.Should().BeGreaterOrEqualTo(4);

                results[0].Id.Should().BeEquivalentTo("Tim.Corey@corey.org");

                results[0].Email.Should().BeEquivalentTo("Tim.Corey@corey.org");

                results[0].Roles.Count.Should().BeLessOrEqualTo(3);
            }
        }

        [Fact]
        public void GetAllRoles_ShouldReturnAllRoles_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userData = MockHelpers.GetSamplePeople();

                var roles = MockHelpers.GetIdentityRoles();

                var mockRoles = MockHelpers.CreateDbSetMock(roles);

                mock.Mock<ApplicationDbContext>().Setup(x => x.Roles).Returns(mockRoles.Object);

                mock.Mock<IUserData>()
                    .Setup(x => x.GetUserById(userData[0].Id))
                    .Returns(userData);

                var sut = mock.Create<UserController>();

                MockHelpers.SetupUser(sut, userData[0].Id);

                //Act

                var results = sut.GetAllRoles();

                //Assert

                results.Count.Should().BeGreaterOrEqualTo(3);

                results.Values.Should().ContainMatch("Admin");

                results.Values.Should().ContainMatch("User");

                results.Values.Should().ContainMatch("Test");
            }
        }

        [Fact]
        public void AddARole_IsNotNullButHasError_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userName = "test@test.com";

                var paring = new UserRolePairModel { UserId = userName, RoleName = "Admin" };

                var user = MockHelpers.GetIdentityUser();

                var mockuserData = new Mock<IUserData>();
                var mockContext = new Mock<ApplicationDbContext>();
                var mockLogger = new Mock<ILogger<UserController>>();

                var store = new Mock<IUserStore<IdentityUser>>();
                store.Setup(x => x.FindByIdAsync(It.IsAny<string>(), CancellationToken.None))
                    .ReturnsAsync(user);

                var mgr = new UserManager<IdentityUser>(store.Object, null, null, null, null, null, null, null, null);

                var sut = new UserController(mockContext.Object, mgr, mockuserData.Object, mockLogger.Object);

                MockHelpers.SetupUser(sut, userName);

                //Act

                var result = sut.AddARole(paring);

                //Assert

                result.Should().NotBeNull();
            }
        }

        [Fact]
        public void RemoveARole_IsNotNullButHasError_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userName = "test@test.com";

                var paring = new UserRolePairModel { UserId = userName, RoleName = "Admin" };

                var user = MockHelpers.GetIdentityUser();

                var mockuserData = new Mock<IUserData>();
                var mockContext = new Mock<ApplicationDbContext>();
                var mockLogger = new Mock<ILogger<UserController>>();

                var store = new Mock<IUserStore<IdentityUser>>();
                store.Setup(x => x.FindByIdAsync(It.IsAny<string>(), CancellationToken.None))
                    .ReturnsAsync(user);

                var mgr = new UserManager<IdentityUser>(store.Object, null, null, null, null, null, null, null, null);

                var sut = new UserController(mockContext.Object, mgr, mockuserData.Object, mockLogger.Object);

                MockHelpers.SetupUser(sut, userName);

                //Act

                var result = sut.RemoveARole(paring);

                //Assert

                result.Should().NotBeNull();
            }
        }
    }
}
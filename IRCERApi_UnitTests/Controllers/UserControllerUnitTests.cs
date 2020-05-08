using Autofac.Extras.Moq;
using FluentAssertions;
using IRCERApi.Data;
using IRCERDataManager.Library.DataAccess;
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

        //[Fact()]
        //public async void AddARole_Test()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        //Arrange
        //        var userId = "123";

        //        var roleName = "Test";

        //        var data = new UserRolePairModel { UserId = userId, RoleName = roleName };

        //        var userData = MockHelpers.GetSamplePeople();

        //        var user = MockHelpers.GetIdentityUser();

        //        var users = MockHelpers.GetSampleIdentityUsers();

        //        var mockUsers = MockHelpers.CreateDbSetMock(users);

        //        var userRoles = MockHelpers.GetSampleIdentityUserRoles();

        //        var mockUserRoles = MockHelpers.CreateDbSetMock(userRoles);

        //        var roles = MockHelpers.GetIdentityRoles();

        //        var mockRoles = MockHelpers.CreateDbSetMock(roles);

        //        var mockContext = new Mock<ApplicationDbContext>();
        //        mockContext.Setup(x => x.Roles).Returns(mockRoles.Object);
        //        mockContext.Setup(x => x.Users).Returns(mockUsers.Object);
        //        mockContext.Setup(x => x.UserRoles).Returns(mockUserRoles.Object);
        //        var mockLogger = new Mock<ILogger<UserController>>();

        //        var store = new Mock<IUserRoleStore<IdentityUser>>();
        //        store.Setup(s => s.FindByIdAsync(It.IsAny<string>(), CancellationToken.None)).Returns(Task.FromResult(user)).Verifiable();
        //        store.Setup(s => s.AddToRoleAsync(user, roleName, CancellationToken.None)).Returns(Task.FromResult(0)).Verifiable();

        //        var userManager = MockHelpers.TestUserManager<IdentityUser>(store.Object);

        //        var mockUserData = new Mock<IUserData>();
        //        mockUserData.Setup(x => x.GetUserById(userData[0].Id)).Returns(userData);

        //        var sut = new UserController(mockContext.Object, userManager, mockUserData.Object, mockLogger.Object);

        //        MockHelpers.SetupUser(sut, userData[0].Id);

        //        //Act

        //        await sut.AddARole(data);

        //        //Assert

        //        store.VerifyAll();
        //        store.Verify(s => s.AddToRoleAsync(user, roleName, CancellationToken.None), Times.Once());
        //    }
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
    }
}
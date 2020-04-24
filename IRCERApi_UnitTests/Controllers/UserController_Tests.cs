using Autofac.Extras.Moq;
using IRCERApi.Data;
using IRCERDataManager.Library.DataAccess;
using IRCERDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
    public class UserController_Tests
    {
        public DbContextOptions DummyOptions { get; } = new DbContextOptions<ApplicationDbContext>();

        [Fact()]
        public void GetById_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userId = Guid.NewGuid().ToString();
                var userName = "test@email.com";
                var identity = new GenericIdentity(userName, "");

                List<UserModel> userData = new List<UserModel> { new UserModel { Id = userName, FirstName = "John", LastName = "Doe" } };

                mock.Mock<IUserData>().Setup(x => x.GetUserById(It.IsAny<string>())).Returns(userData);

                var mockPrincipal = new Mock<ClaimsPrincipal>();
                mockPrincipal.Setup(x => x.Identity).Returns(identity);
                mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

                var mockHttpContext = new Mock<HttpContext>();
                mockHttpContext.Setup(m => m.User).Returns(mockPrincipal.Object);

                //mock.Mock<IUserStore<IdentityUser>>().Setup(x => x.FindByIdAsync(userId, new CancellationToken()))
                //    .ReturnsAsync(new IdentityUser() { Id = userName });

                var sut = mock.Create<UserController>();

                //Act

                var result = sut.GetById();

                //Assert

                Assert.True(result != null);
            }
        }

        [Fact()]
        public void GetAllUsers_Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetAllRoles_Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void AddARole_Test()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void RemoveARole_Test()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }

    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
        {
        }
    }

    public class TestIdentity : ClaimsIdentity
    {
        public TestIdentity(params Claim[] claims) : base(claims)
        {
        }
    }
}
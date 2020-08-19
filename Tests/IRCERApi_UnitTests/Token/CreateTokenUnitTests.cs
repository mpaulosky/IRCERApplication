using Autofac.Extras.Moq;
using FluentAssertions;
using IRCERApiDataManager.Library.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using TestHelpers;
using Xunit;

namespace IRCERApi.Token.UnitTests
{
	public class CreateTokenUnitTests
	{
		[Fact]
		public void CreateToken_Test()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				//Act

				var sut = mock.Create<CreateToken>();

				//Assert

				sut.Should().NotBeNull();
			}
		}

		[Fact]
		public async void GenerateToken_TestAsync()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var secretsKey = "MySecretKeyIsSecretSoDoNotTell";

				var user = MockHelpers.GetIdentityUser();

				var userRoles = MockHelpers.GetSampleIdentityUserRoles();

				var mockUserRoles = MockHelpers.CreateDbSetMock(userRoles);

				var users = MockHelpers.GetSampleIdentityUsers();

				var mockUsers = MockHelpers.CreateDbSetMock(users);

				var roles = MockHelpers.GetIdentityRoles();

				var mockRoles = MockHelpers.CreateDbSetMock(roles);

				var appMock = new Mock<ApplicationDbContext>();
				appMock.Setup(x => x.Roles).Returns(mockRoles.Object);
				appMock.Setup(x => x.Users).Returns(mockUsers.Object);
				appMock.Setup(x => x.UserRoles).Returns(mockUserRoles.Object);

				var userManager = MockHelpers.MockUserManager<IdentityUser>();
				userManager.Setup(s => s.FindByNameAsync(user.UserName)).ReturnsAsync(() => user);

				var secMock = new Mock<IConfigurationSection>();
				secMock.Setup(x => x.Value).Returns(secretsKey);

				var configuration = new Mock<IConfiguration>();
				configuration.Setup(c => c.GetSection(It.IsAny<string>()))
				.Returns(secMock.Object);

				var sut = new CreateToken(appMock.Object, userManager.Object, configuration.Object);

				//Act

				var result = await sut.GenerateToken(user.Email);

				//Assert

				sut.Should().NotBeNull();

				Assert.NotNull(result);
			}
		}
	}
}

using Autofac.Extras.Moq;
using IdentityHelpers;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace IRCERApi.Data.UnitTests
{
    public class ValidateUserUnitTests
    {
        [Theory]
        [InlineData("test", true)]
        public async Task IsValidUsernameAndPassword_TestAsync(string password, bool expected)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var user = new IdentityUser
                {
                    Id = "123",
                    UserName = "test@test.com",
                    PasswordHash = "test",
                    Email = "test@test.com"
                };

                var userManager = MockHelpers.MockUserManager<IdentityUser>();
                userManager.Setup(s => s.FindByEmailAsync(user.Email)).ReturnsAsync(() => user);
                userManager.Setup(s => s.CheckPasswordAsync(user, password)).ReturnsAsync(() => true).Verifiable();

                var sut = new ValidateUser(userManager.Object);

                //Act

                var result = await sut.IsValidUsernameAndPassword(user.UserName, password);

                //Assert

                Assert.Equal(expected, result);
            }
        }

        [Theory]
        [InlineData("t", false)]
        public async Task IsValidUsernameAndPassword_InvalidPassword_TestAsync(string password, bool expected)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var user = new IdentityUser
                {
                    Id = "123",
                    UserName = "test@test.com",
                    PasswordHash = "test",
                    Email = "test@test.com"
                };

                var userManager = MockHelpers.MockUserManager<IdentityUser>();
                userManager.Setup(s => s.FindByEmailAsync(user.Email)).ReturnsAsync(() => user);
                userManager.Setup(s => s.CheckPasswordAsync(user, password)).ReturnsAsync(() => false).Verifiable();

                var sut = new ValidateUser(userManager.Object);

                //Act

                var result = await sut.IsValidUsernameAndPassword(user.UserName, password);

                //Assert

                Assert.Equal(expected, result);
            }
        }
    }
}
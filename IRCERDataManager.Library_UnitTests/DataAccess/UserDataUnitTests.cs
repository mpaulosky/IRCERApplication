using Autofac.Extras.Moq;
using FluentAssertions;
using IRCERApiDataManager.Library.Internal.DataAccess;
using IRCERApiDataManager.Library.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IRCERApiDataManager.Library.DataAccess.UnitTests
{
    public class UserDataUnitTests
    {
        [Fact()]
        public void GetUserById_WithValidId_ShouldReturnUser_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userID = "test@email.com";

                var userData = new List<UserModel> { new UserModel { Id = userID, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@test.com", CreatedDate = DateTime.Now } };

                mock.Mock<ISqlDataAccess>().Setup(x => x.LoadData<UserModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>())).Returns(() => userData);

                var sut = mock.Create<UserData>();

                //Act

                var result = sut.GetUserById(userID);

                //Assert

                result.Should().NotBeNull();

                result[0].Id.Should().BeEquivalentTo(userID);
            }
        }

        [Fact()]
        public void GetUserById_WithEmptyId_ShouldReturnAnArgumentException_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userID = "";

                mock.Mock<ISqlDataAccess>();

                var sut = mock.Create<UserData>();

                //Assert

                var ex = Assert.Throws<ArgumentException>(() => sut.GetUserById(userID));

                ex.Message.Should().BeEquivalentTo("message (Parameter 'Id')");
            }
        }

        [Fact]
        public void GetAll_ReturnsAListOfUsers()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userID = "test@email.com";

                var userData = new List<UserModel> { new UserModel { Id = userID, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@test.com", CreatedDate = DateTime.Now } };

                mock.Mock<ISqlDataAccess>().Setup(x => x.LoadData<UserModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>())).Returns(() => userData);

                var sut = mock.Create<UserData>();

                //Act

                var result = sut.GetAllUsers();

                //Assert

                Assert.NotNull(result);

                Assert.Equal(userID, result[0].Id);
            }
        }
    }
}
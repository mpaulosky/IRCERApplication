using Autofac.Extras.Moq;
using IRCERDataManager.Library.Internal.DataAccess;
using IRCERDataManager.Library.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IRCERDataManager.Library.DataAccess.UnitTests
{
    public class UserData_Tests
    {
        [Fact()]
        public void GetUserById_WithValidId_ShouldReturnUser_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userID = "test@email.com";

                var userData = new List<UserModel> { new UserModel { Id = userID, FirstName = "John", LastName = "Doe" } };

                mock.Mock<ISqlDataAccess>().Setup(x => x.LoadData<UserModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>())).Returns(() => userData);

                var sut = mock.Create<UserData>();

                //Act

                var result = sut.GetUserById(userID);

                //Assert

                Assert.NotNull(result);

                Assert.Equal(userID, result[0].Id);
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

                Assert.Equal("message (Parameter 'Id')", ex.Message);
            }
        }
    }
}
using Autofac.Extras.Moq;
using FluentAssertions;
using IRCERDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IRCERDataManager.Library.Internal.DataAccess.UnitTests
{
    public class SqlDataAccessUnitTests
    {
        [Fact()]
        public void SqlDataAccess_ShouldNotReturnNull_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IConfiguration>();
                mock.Mock<ILogger>();

                var sut = mock.Create<SqlDataAccess>();

                sut.Should().NotBeNull();
            }
        }

        [Theory]
        [InlineData("DefaultConnection", "Test1")]
        [InlineData("IRCERData", "Test2")]
        public void GetConnectionString__Test(string connStrName, string expected)
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var mockConfigSection = new Mock<IConfigurationSection>();
                mockConfigSection.SetupGet(m => m[It.Is<string>(s => s == connStrName)]).Returns(expected);

                mock.Mock<IConfiguration>()
                    .Setup(x => x.GetSection(It.Is<string>(s => s == "ConnectionStrings")))
                    .Returns(mockConfigSection.Object);

                mock.Mock<ILogger<SqlDataAccess>>();

                var sut = mock.Create<SqlDataAccess>();

                //Act

                var result = sut.GetConnectionString(connStrName);

                //Assert

                sut.Should().NotBeNull();

                result.Should().NotBeNull();

                result.Should().BeEquivalentTo(expected);
            }
        }

        [Fact()]
        public void LoadData_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                var userID = "test@email.com";

                var userData = new List<UserModel> { new UserModel { Id = userID, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@test.com", CreatedDate = DateTime.Now } };

                mock.Mock<ISqlDataAccess>().Setup(x => x.LoadData<UserModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>())).Returns(() => userData);

                var sut = mock.Create<ISqlDataAccess>();

                //Act

                var result = sut.LoadData<UserModel, dynamic>("dbo.spUserLookup", new { userID }, "IRCERData");

                //Assert

                sut.Should().NotBeNull();

                result.Should().NotBeNull();

                Assert.Equal(userID, result[0].Id);
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void SaveData_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void StartTransaction_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void LoadDataInTransaction_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void SaveDataInTransaction_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void CommitTransaction_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void RollbackTransaction_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }

        [Fact(Skip = "Unable to mock the Dapper Calls")]
        public void Dispose_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange

                //Act

                //Assert

                Assert.True(false, "This test needs an implementation");
            }
        }
    }
}
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

				var userID = "john.doe@test.com";

				var userData = MockUserData.User();

				mock.Mock<ISqlDataAccess>().Setup(x => x.LoadData<UserModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>())).Returns(() => userData);

				var sut = mock.Create<UserData>();

				//Act

				var result = sut.GetUserById(userID);

				//Assert

				result.Should().NotBeNull();
				result.Should().HaveCount(1);
				result[0].Id.Should().BeEquivalentTo(userID);
			}
		}

		[Theory]
		[InlineData("")]
		[InlineData(null)]
		public void GetUserById_WithEmptyId_ShouldReturnAnArgumentException_Test(string userID)
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				mock.Mock<ISqlDataAccess>();

				var sut = mock.Create<UserData>();

				//Assert

				var ex = Assert.Throws<ArgumentException>(() => sut.GetUserById(userID));

				ex.Message.Should().BeEquivalentTo("message (Parameter 'Id')");
			}
		}

		[Theory]
		[InlineData("john.doe@test.com", 0)]
		[InlineData("jane.doe@test.com", 1)]
		public void GetAll_ReturnsAListOfUsers(string userID, int index)
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange

				var userData = MockUserData.Users();

				mock.Mock<ISqlDataAccess>().Setup(x => x.LoadData<UserModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>())).Returns(() => userData);

				var sut = mock.Create<UserData>();

				//Act

				var result = sut.GetAllUsers();

				//Assert

				result.Should().NotBeNull();
				result.Should().HaveCount(2);
				result[index].Id.Should().BeEquivalentTo(userID);
			}
		}
	}
}

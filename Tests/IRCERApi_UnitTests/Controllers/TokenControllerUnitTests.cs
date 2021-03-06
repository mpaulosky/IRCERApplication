﻿using Autofac.Extras.Moq;
using IRCERApi.Data;
using IRCERApi.Token;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace IRCERApi.Controllers.UnitTests
{
	public class TokenControllerUnitTests
	{
		[Fact]
		public async Task Create_WithValidUser_ShouldReturnToken()
		{
			//Arrange

			using var mock = AutoMock.GetLoose();

			var userName = "Test";
			var token = "token";
			var password = "test";

			mock.Mock<IValidateUser>()
					.Setup(x => x.IsValidUsernameAndPassword(userName, It.IsAny<string>())).ReturnsAsync(true);

			mock.Mock<ICreateToken>()
					.Setup(x => x.GenerateToken(It.IsAny<string>()))
					.ReturnsAsync(() => new { token, userName });

			var sut = mock.Create<TokenController>();

			//Act

			var result = await sut.Create(userName, password, "test");

			//Assert

			Assert.IsType<ObjectResult>(result);

			Assert.True(result != null);
		}

		[Fact]
		public async Task Create_WithInValidUser_ShouldReturnBadRequest()
		{
			//Arrange

			using var mock = AutoMock.GetLoose();

			var userName = "Test";
			var password = "test";

			mock.Mock<IValidateUser>();

			mock.Mock<ICreateToken>();

			var sut = mock.Create<TokenController>();

			//Act

			var result = await sut.Create(userName, password, "test");

			//Assert

			Assert.IsType<BadRequestResult>(result);

			Assert.True(result != null);
		}
	}
}

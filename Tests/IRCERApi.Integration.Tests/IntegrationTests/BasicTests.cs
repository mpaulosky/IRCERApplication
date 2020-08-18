using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace IRCERApi.Integration.Tests
{
	public class BasicTests
<<<<<<< HEAD
				: IClassFixture<WebApplicationFactory<Startup>>
=======
			: IClassFixture<WebApplicationFactory<Startup>>
>>>>>>> develop
	{
		private readonly WebApplicationFactory<Startup> _factory;

		public BasicTests(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("/", "text/html; charset=utf-8")]
		[InlineData("/Home/Index", "text/html; charset=utf-8")]
		[InlineData("/Home/Privacy", "text/html; charset=utf-8")]
		[InlineData("/Identity/Account/Login", "text/html; charset=utf-8")]
		[InlineData("/Identity/Account/Register", "text/html; charset=utf-8")]
		public async Task Get_Endpoints_UsingSharedLayout_ReturnSuccessAndCorrectContentType(string url, string expected)
		{
			// Arrange

<<<<<<< HEAD
			System.Net.Http.HttpClient client = _factory.CreateClient();

			// Act

			System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);

=======
			var client = _factory.CreateClient();

			// Act

			var response = await client.GetAsync(url);
>>>>>>> develop
			// Assert

			response.EnsureSuccessStatusCode(); // Status Code 200-299

<<<<<<< HEAD
			response.Content.Headers.ContentType.ToString()
					.Should().BeEquivalentTo(expected);
=======
			response.Content.Headers.ContentType.ToString().Should().BeEquivalentTo(expected);
>>>>>>> develop
		}

		[Theory]
		[InlineData("/", "Home Page")]
		[InlineData("/Home/Index", "Home Page")]
		[InlineData("/Home/Index", "Welcome")]
		[InlineData("/Home/Privacy", "Use this page to detail your site's privacy policy.")]
		[InlineData("/Home/Privacy", "Privacy Policy")]
		[InlineData("/Identity/Account/Login", "Log in")]
		[InlineData("/Identity/Account/Register", "Register")]
		public async Task Get_Endpoints_ReturnSuccessAndCorrectPageText(string url, string expected)
		{
			// Arrange

<<<<<<< HEAD
			System.Net.Http.HttpClient client = _factory.CreateClient();

			// Act

			System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);

=======
			var client = _factory.CreateClient();

			// Act

			var response = await client.GetAsync(url);
>>>>>>> develop
			// Assert

			response.EnsureSuccessStatusCode(); // Status Code 200-299

<<<<<<< HEAD
			string responseString = await response.Content.ReadAsStringAsync();

=======
			var responseString = await response.Content.ReadAsStringAsync();
>>>>>>> develop
			responseString.Should().Contain(expected);
		}
	}
<<<<<<< HEAD
}
=======
}
>>>>>>> develop

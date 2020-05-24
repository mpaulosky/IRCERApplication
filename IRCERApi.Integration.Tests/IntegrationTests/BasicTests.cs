using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace IRCERApi.Integration.Tests
{
    public class BasicTests
        : IClassFixture<WebApplicationFactory<Startup>>
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
        [InlineData("/Home/Error", "text/html; charset=utf-8")]
        public async Task Get_Endpoints_ReturnSuccessAndCorrectContentType(string url, string expected)
        {
            // Arrange

            var client = _factory.CreateClient();

            // Act

            var response = await client.GetAsync(url);

            // Assert

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            response.Content.Headers.ContentType.ToString()
                .Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("/", "Home Page")]
        [InlineData("/Home/Index", "Home Page")]
        [InlineData("/Home/Index", "Welcome")]
        [InlineData("/Home/Privacy", "Use this page to detail your site's privacy policy.")]
        [InlineData("/Home/Privacy", "Privacy Policy")]
        [InlineData("/Home/Error", "Error")]
        [InlineData("/Identity/Account/Login", "Log in")]
        [InlineData("/Identity/Account/Register", "Register")]
        public async Task Get_Endpoints_ReturnSuccessAndCorrectPageText(string url, string expected)
        {
            // Arrange

            var client = _factory.CreateClient();

            // Act

            var response = await client.GetAsync(url);

            // Assert

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain(expected);
        }
    }
}
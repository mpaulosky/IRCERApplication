using Bunit;
using FluentAssertions;
using Xunit;

namespace IRCERUI.Pages.UnitTests
{
	public class CounterComponetUnitTests : ComponentTestFixture
	{
		[Fact]
		public void CounterComponet_RendersCorrectly()
		{
			var cut = RenderComponent<Counter>();

			var expectedHtml = @"<h1>Counter</h1>

															<p>Current count: 0</p>

															<button class='btn btn-primary'>Click me</button>";

			cut.MarkupMatches(expectedHtml);
		}

		[Fact]
		public void Counter_ClickingButtonIncreasesCountStrict()
		{
			var cut = RenderComponent<Counter>();

			cut.Find("button").Click();

			cut.GetChangesSinceFirstRender()
					.ShouldHaveSingleTextChange(expectedChange: "Current count: 1");
		}

		[Fact]
		public void Counter_ClickingButtonIncreasesCountTargeted()
		{
			// Arrange - renders the Counter component
			var cut = RenderComponent<Counter>();

			// Act
			cut.Find("button").Click();

			// Assert
			cut.Find("p").TextContent.Trim().Should().BeEquivalentTo("Current count: 1");

			// Repeat the above steps to ensure that counter works for multiple clicks
			cut.Find("button").Click();

			cut.Find("p").TextContent.Trim().Should().BeEquivalentTo("Current count: 2");
		}
	}
}

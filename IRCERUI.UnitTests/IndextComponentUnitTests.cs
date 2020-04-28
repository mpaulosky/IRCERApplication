using Bunit;
using Xunit;

namespace IRCERUI.UnitTests
{
    public class IndextComponentUnitTests : ComponentTestFixture
    {
        [Fact]
        public void Component1RendersCorrectly()
        {
            var cut = RenderComponent<Pages.Index>();

            var expectedHtml = @"<h1>Hello, world!</h1>
                                Welcome to your new app.
                                <div class='alert alert-secondary mt-4' role='alert'>
                                    <span class='oi oi-pencil mr-2' aria-hidden='true'></span>
                                  <strong>How is Blazor working for you?</strong>
                                  <span class='text-nowrap'>
                                    Please take our
                                    <a target='_blank' class='font-weight-bold' href='https://go.microsoft.com/fwlink/?linkid=2112271'>brief survey</a>
                                  </span>
                                  and tell us what you think.
                                </div>";

            cut.MarkupMatches(expectedHtml);
        }
    }
}
﻿using Bunit;
using IRCERUI.Pages;
using Xunit;

namespace IRCERUI.UnitTests
{
    public class ErrorComponentUnitTests : ComponentTestFixture
    {
        [Fact]
        public void Component1RendersCorrectly()
        {
            var cut = RenderComponent<Error>();

            var expectedHtml = @"<h1 class='text-danger'>Error.</h1>
                                <h2 class='text-danger'>An error occurred while processing your request.</h2>

                                <h3>Development Mode</h3>
                                <p>
                                    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
                                </p>
                                <p>
                                    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
                                    It can result in displaying sensitive information from exceptions to end users.
                                    For local debugging, enable the <strong>Development</strong> environment by setting the<strong> ASPNETCORE_ENVIRONMENT</strong> environment variable to<strong> Development</strong>
                                    and restarting the app.
                                </p>";

            cut.MarkupMatches(expectedHtml);
        }
    }
}
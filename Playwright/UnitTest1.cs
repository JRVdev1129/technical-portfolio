namespace Playwright;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [Test]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev");
        var getStartedLink = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Click the get started link.
        await getStartedLink.ClickAsync();

        var installationButton = Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" });

        // Expects page to have a heading with the name of Installation.
        await Expect(installationButton).ToBeVisibleAsync();
    }
}
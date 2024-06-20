namespace Playwright;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using HomePage.model;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        HomePage homePage = new HomePage(await Browser.NewPageAsync());
        await homePage.GotoAsync();



        // Expect a title "to contain" a substring.
        await Expect(homePage._page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [Test]
    public async Task GetStartedLink()
    {
        HomePage homePage = new HomePage(await Browser.NewPageAsync());
        await homePage.GotoAsync();

        // Click the get started link.
        await homePage.ClickStartedLinkNetworkEvent();
        var isExist = await homePage.CheckInstallationButton();

        // Expects page to have a heading with the name of Installation.
        Assert.IsTrue(isExist);

        // await Expect(homePage.installationButton()).ToBeVisibleAsync();
    }
}
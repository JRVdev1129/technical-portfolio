namespace Playwright;
using FluentAssertions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using HomePage.model;
using System.Security.Cryptography;

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
        isExist.Should().BeTrue();

        // await Expect(homePage.installationButton()).ToBeVisibleAsync();
    }

    [Test]
    public async Task noImages()
    {
        HomePage homePage = new HomePage(await Browser.NewPageAsync());
        homePage._page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
        await homePage._page.RouteAsync("**/*", async route =>
        {
            if (route.Request.ResourceType == "image")
            {
                await route.AbortAsync();
            }
            else
            {
                await route.ContinueAsync();
            }

        });
        await homePage.GotoAsync();


    }
}
namespace Playwright;
using FluentAssertions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using AbTesting.model;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class abTest : PageTest
{
    [Test]
    public async Task NavigateToABTestingPage()
    {
        AbTesting abTesting = new AbTesting(await Browser.NewPageAsync());
        await abTesting.GotoAsync();

        await abTesting.ClickABTestingLink();



        // Expect a title "to contain" a substring.
        await Expect(abTesting.abTestingDescription()).ToContainTextAsync("Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).");
    }

    // [Test]
    // public async Task GetStartedLink()
    // {
    //     abTesting abTesting = new abTesting(await Browser.NewPageAsync());
    //     await abTesting.GotoAsync();

    //     // Click the get started link.
    //     await abTesting.ClickStartedLinkNetworkEvent();
    //     var isExist = await abTesting.CheckInstallationButton();

    //     // Expects page to have a heading with the name of Installation.
    //     Assert.IsTrue(isExist);
    //     isExist.Should().BeTrue();

    //     // await Expect(abTesting.installationButton()).ToBeVisibleAsync();
    // }

    // [Test]
    // public async Task noImages()
    // {
    //     abTesting abTesting = new abTesting(await Browser.NewPageAsync());
    //     abTesting._page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
    //     await abTesting._page.RouteAsync("**/*", async route =>
    //     {
    //         if (route.Request.ResourceType == "image")
    //         {
    //             await route.AbortAsync();
    //         }
    //         else
    //         {
    //             await route.ContinueAsync();
    //         }

    //     });
    //     await abTesting.GotoAsync();


    // }
}
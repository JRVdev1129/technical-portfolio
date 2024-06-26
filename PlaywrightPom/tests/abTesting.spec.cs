using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using sauceDemo.Base;
using sauceDemo.Pages;

namespace sauceDemo.Tests;

[Parallelizable]
public class abTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected InternetPageModel internetPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        internetPage = new InternetPageModel(_page);
        internetPage.AddName(TestContext.CurrentContext.Test.Name);
        await internetPage.GotoAsync();

    }
    [Test]
    public async Task NavigateToABTestingPage()
    {
        // AbTesting abTesting = new AbTesting(await Browser.NewPageAsync());
        // await abTesting.GotoAsync();

        await internetPage.ClickABTestingLink();



        // Expect a title "to contain" a substring.
        // await Expect(internetPage.abTestingDescription()).ToContainTextAsync("Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).");
    }

    [TearDown]
    public async Task BaseTearDownAsync()
    {
        string tracePath = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "trace.zip");
        // Stop tracing and export it into a zip archive.
        await _context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = tracePath
        });
        TestContext.AddTestAttachment(tracePath);
        //To open the tracing
        //playwright show-trace trace.zip
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
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using sauceDemo.Base;
using sauceDemo.Pages;

namespace sauceDemo.Tests;

[Parallelizable]
public class abTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected ABTestingPageModel abTestingPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        abTestingPage = new ABTestingPageModel(_page);
        abTestingPage.AddName(TestContext.CurrentContext.Test.Name);
        await abTestingPage.GotoAsync();

    }
    [Test, Category("AB Testing")]
    [TestCase(TestName = "Cliking AB Testing Link should redirect the to A/B testing page")]
    public async Task NavigateToABTestingPage()
    {
        await abTestingPage.ClickABTestingLink();

        var text = await abTestingPage.getABTestingDescription();
        text.Should().Contain("  Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).");

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
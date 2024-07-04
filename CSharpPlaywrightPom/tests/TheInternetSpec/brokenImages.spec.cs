using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using internet.Base;
using internet.Pages;
using NUnit.Framework;

namespace internet.Tests;

[TestFixture]
[Parallelizable]
public class BrokenImagesTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected BrokenImagesPageModel brokenImagesPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        brokenImagesPage = new BrokenImagesPageModel(_page);
        brokenImagesPage.AddName(TestContext.CurrentContext.Test.Name);
        await brokenImagesPage.GotoAsync();

    }
    [Test, Category("Broken Images")]
    [TestCase(TestName = "Cliking Broken Images Link should redirect the to Broken Images page")]
    public async Task NavigateToABTestingPage()
    {

        await brokenImagesPage.clickBrokenImagesLink();

        var count = await brokenImagesPage.imageCount();
        count.Should().Be(3);




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

}
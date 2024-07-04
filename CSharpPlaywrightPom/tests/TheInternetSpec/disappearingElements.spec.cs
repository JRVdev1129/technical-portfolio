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
public class disappearingElementsTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected DisappearingElementsPageModel disappearingElementsPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        disappearingElementsPage = new DisappearingElementsPageModel(_page);
        disappearingElementsPage.AddName(TestContext.CurrentContext.Test.Name);
        await disappearingElementsPage.GotoAsync();

    }
    [Test, Category("disappearing elements")]
    [TestCase(TestName = "Cliking disappearing Elements Link should redirect the to disappearing elements page")]
    public async Task NavigateToABTestingPage()
    {

        await disappearingElementsPage.clickDisappearingelementsLink();

        var count = await disappearingElementsPage.elementCount();
        count.Should().Be(5);
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
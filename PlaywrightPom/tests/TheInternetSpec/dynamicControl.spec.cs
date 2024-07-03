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
public class DynamicControlTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected DynamicControlPageModel dynamicControlPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        dynamicControlPage = new DynamicControlPageModel(_page);
        dynamicControlPage.AddName(TestContext.CurrentContext.Test.Name);
        await dynamicControlPage.GotoAsync();

    }
    [Test, Category("Dynamic Control")]
    [TestCase(TestName = "Cliking Dynamic control Link should redirect the to Dynamic control page")]
    public async Task NavigateToABTestingPage()
    {

        await dynamicControlPage.clickDynamicControlsLink();
        await Assertions.Expect(dynamicControlPage.checkbox()).ToBeVisibleAsync();

        await dynamicControlPage.clickRemoveButton();
        await Assertions.Expect(dynamicControlPage.loadingText()).ToBeVisibleAsync();

        await dynamicControlPage.loadingText().WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Hidden,
            Timeout = 10000 // 10 seconds
        });

        await Assertions.Expect(dynamicControlPage.checkbox()).ToHaveCountAsync(0);


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
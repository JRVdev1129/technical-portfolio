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
public class CheckboxesTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected CheckboxesPageModel checkboxes;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitializePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        checkboxes = new CheckboxesPageModel(_page);
        checkboxes.AddName(TestContext.CurrentContext.Test.Name);
        await checkboxes.GotoAsync();

    }
    [Test, Category("Checkbox")]
    [TestCase(TestName = "Clicking checkboxes link should redirect the to checkboxes page")]
    public async Task NavigateToABTestingPage()
    {

        await checkboxes.clickCheckboxesLink();

        await checkboxes.checkbox().ClickAsync();

        await Assertions.Expect(checkboxes.checkbox()).ToBeCheckedAsync();
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
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
public class DropDownTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected DropdownPageModel dropdownPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitializePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        dropdownPage = new DropdownPageModel(_page);
        dropdownPage.AddName(TestContext.CurrentContext.Test.Name);
        await dropdownPage.GotoAsync();

    }
    [Test, Category("Dropdown")]
    [TestCase(TestName = "Clicking dropdown Link should redirect the to dropdown page")]
    public async Task NavigateToABTestingPage()
    {

        await dropdownPage.clickDropdownLink();

        await dropdownPage.dropdownElement().SelectOptionAsync("Option 1");
        var option = await dropdownPage.optionOne().GetAttributeAsync("selected");
        option.Should().Contain("selected");
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
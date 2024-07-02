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


[Parallelizable]
public class ContextMenuTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected ContextMenuPageModel contextMenu;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        contextMenu = new ContextMenuPageModel(_page);
        contextMenu.AddName(TestContext.CurrentContext.Test.Name);
        await contextMenu.GotoAsync();

    }
    [Test, Category("Checkbox")]
    [TestCase(TestName = "Cliking context Menu link should redirect the to context Menu page")]
    public async Task NavigateToABTestingPage()
    {

        await contextMenu.clickContextMenuLink();

        var message = await contextMenu.triggersDialog();

        message.Should().Be(("You selected a context menu"));
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
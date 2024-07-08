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
public class DragAndDropTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected DragAndDropPageModel dragAndDropPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitializePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        dragAndDropPage = new DragAndDropPageModel(_page);
        dragAndDropPage.AddName(TestContext.CurrentContext.Test.Name);
        await dragAndDropPage.GotoAsync();

    }
    [Test, Category("Drag And Drop")]
    [TestCase(TestName = "Clicking drag and drop Link should redirect the to  drag and drop page")]
    public async Task NavigateToABTestingPage()
    {

        await dragAndDropPage.clickDragAndDropLink();

        await dragAndDropPage.dragAndDropColumnAToB();
        var columnA = await dragAndDropPage.columnAText().TextContentAsync();
        columnA.Should().Be("B");
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
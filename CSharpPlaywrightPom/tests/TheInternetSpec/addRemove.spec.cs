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
public class AddRemoveTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected AddRemovePageModel addRemovePage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitializePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        addRemovePage = new AddRemovePageModel(_page);
        addRemovePage.AddName(TestContext.CurrentContext.Test.Name);
        await addRemovePage.GotoAsync();

    }
    [Test, Category("Add Remove Elements")]
    [TestCase(TestName = "Clicking Add/Remove Link should redirect the to Add/Remove page")]
    public async Task NavigateToABTestingPage()
    {

        await addRemovePage.clickAddRemoveLink();

        var text = await addRemovePage.getTitleText();
        text.Should().Contain("Add/Remove Elements");

    }

    [Test, Category("Add Remove Elements")]
    [TestCase(TestName = "Cliking Add Element Button Should add the Delete Button")]
    public async Task addElement()
    {

        await addRemovePage.clickAddRemoveLink();

        await addRemovePage.clickAddElementButton();

        var text = await addRemovePage.deleteElementButton().TextContentAsync();
        text.Should().Contain("Delete");

    }

    [Test, Category("Add Remove Elements")]
    [TestCase(TestName = "Cliking Delete Element Button Should delete the Delete Button")]
    public async Task deleteElement()
    {

        await addRemovePage.clickAddRemoveLink();

        await addRemovePage.clickAddElementButton();

        var text = await addRemovePage.deleteElementButton().TextContentAsync();
        text.Should().Contain("Delete");

        await addRemovePage.clickdeleteElementButton();

        var deleteButtonCOunt = await addRemovePage.deleteElementButton().CountAsync();
        deleteButtonCOunt.Should().Be(0);
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
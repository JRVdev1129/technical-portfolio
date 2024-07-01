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
public class AuthTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected AuthPageModel authPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        authPage = new AuthPageModel(_page);
        authPage.AddName(TestContext.CurrentContext.Test.Name);
        await authPage.GotoAsync();

    }
    [Test, Category("Add Remove Elements")]
    [TestCase(TestName = "Cliking Auth Link when the correct credentials are set should redirect the to Auth page")]
    public async Task NavigateToABTestingPage()
    {

        await authPage.clickAuthLink();

        var text = await authPage.getAuthDescription();
        text.Should().Contain("Congratulations! You must have the proper credentials");
        await _page.WaitForTimeoutAsync(5000);




    }

    //     [Test, Category("Add Remove Elements")]
    //     [TestCase(TestName = "Cliking Add Element Button Should add the Delete Button")]
    //     public async Task addElement()
    //     {

    //         await addRemovePage.clickAddRemoveLink();

    //         await addRemovePage.clickAddElementButton();

    //         var text = await addRemovePage.deleteElementButton().TextContentAsync();
    //         text.Should().Contain("Delete");

    // }


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
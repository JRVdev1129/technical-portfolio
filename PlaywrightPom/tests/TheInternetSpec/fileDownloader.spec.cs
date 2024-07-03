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
public class FileDownloaderTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected FileDownloaderPageModel fileDownloaderPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitalizePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        fileDownloaderPage = new FileDownloaderPageModel(_page);
        fileDownloaderPage.AddName(TestContext.CurrentContext.Test.Name);
        await fileDownloaderPage.GotoAsync();

    }
    [Test, Category("File Downloader")]
    [TestCase(TestName = "Cliking File Downloader Link should redirect the to File Downloader page")]
    public async Task NavigateToABTestingPage()
    {
        await fileDownloaderPage.clickFileDownloaderLink();

        var file = await fileDownloaderPage.clickBladeHeroImg();
        Assert.IsTrue(File.Exists(file), $"File was not downloaded: {file}");
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
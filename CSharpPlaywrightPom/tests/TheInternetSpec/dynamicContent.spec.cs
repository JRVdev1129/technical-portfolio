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
public class DynamicContentTest
{

    private IPage _page;
    private IBrowserContext _context;
    protected DynamicContentPageModel dynamicContentPage;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        _page = await playwrightDriver.InitializePlaywrightTracingAsync();
        _context = playwrightDriver.Context;
        dynamicContentPage = new DynamicContentPageModel(_page);
        dynamicContentPage.AddName(TestContext.CurrentContext.Test.Name);
        await dynamicContentPage.GotoAsync();

    }
    [Test, Category("Dynamic Content")]
    [TestCase(TestName = "Clicking Dynamic Content Link should redirect the to Dynamic Content page")]
    public async Task NavigateToABTestingPage()
    {

        await dynamicContentPage.clickDynamicContentLink();
        await Assertions.Expect(dynamicContentPage.images().Last).ToBeVisibleAsync();

        var previousImageSources = await dynamicContentPage.getAllImagesSource();
        var PreviousParagraphsContent = await dynamicContentPage.getAllParagraphsContent();

        await _page.ReloadAsync();
        await Assertions.Expect(dynamicContentPage.images().Last).ToBeVisibleAsync();


        var currentImageSources = await dynamicContentPage.getAllImagesSource();
        var CurrentParagraphsContent = await dynamicContentPage.getAllParagraphsContent();


        int numberOfImagesThatChangeOnPageRefresh = 0;
        int numberOfParagraphsThatChangeOnPageRefresh = 0;

        for (int element = 0; element < previousImageSources.Count; element++)
        {
            if (previousImageSources[element] != currentImageSources[element]) numberOfImagesThatChangeOnPageRefresh++;
            if (PreviousParagraphsContent[element] != CurrentParagraphsContent[element]) numberOfParagraphsThatChangeOnPageRefresh++;


            // previousImageSources[element].Should().NotBe(currentImageSources[element]);
            // PreviousParagraphsContent[element].Should().NotBe(CurrentParagraphsContent[element]);
        }
        numberOfImagesThatChangeOnPageRefresh.Should().BeGreaterThan(0, $"Test failed because none of the images in the page changed. Before: {string.Join(", ", previousImageSources)} After: {string.Join(", ", currentImageSources)}");
        numberOfParagraphsThatChangeOnPageRefresh.Should().BeGreaterThan(0, $"Test failed because none of the paragraphs in the page changed. Before: {string.Join(", ", PreviousParagraphsContent)} After: {string.Join(", ", CurrentParagraphsContent)}");
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
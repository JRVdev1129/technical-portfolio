using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using internet.Base;

namespace internet;

/// <summary>
/// Base Page with common functions to all pages
/// </summary>
public class BasePage
{
    protected IPage Page;

    private IReporter _reporter;
    protected AnnotationHelper annotationHelper;

    public BasePage(IPage page)
    {
        this.Page = page;
        _reporter = new ConsoleReporter();
        annotationHelper = new AnnotationHelper(_reporter);
    }

    /// <summary>
    /// Take screenshot
    /// </summary>
    /// <param name="name">Name of the image to save</param>
    /// <remarks>Can be optional for some oncloud </remarks>
    /// <returns></returns>
    public async Task TakeScreenShootAsync(string name)
    {
        var screenImage = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, name + "-" + Guid.NewGuid().ToString() + ".png");
        var imageBytes = await Page.ScreenshotAsync(new PageScreenshotOptions { FullPage = true });
        File.WriteAllBytes(screenImage, imageBytes);
        TestContext.AddTestAttachment(screenImage);
    }



    public async Task GotoPageAsync(string page)
    {
        this.annotationHelper.AddAnnotation(AnnotationType.Step, "Go to the page: '" + page + "'");
        await Page.GotoAsync(page);
    }

    public void AssertEqual(object expected, object actual, string errorMessage)
    {
        this.annotationHelper.AddAnnotation(AnnotationType.Assert, errorMessage);
        Assert.That(expected, Is.EqualTo(actual), errorMessage);
    }

    public List<Annotation> GetAnnotations()
    {
        return this.annotationHelper.GetAnnotations();
    }

    public void AddDescription(string description)
    {
        this.annotationHelper.AddAnnotation(AnnotationType.Description, description);
    }

    public void AddName(string description)
    {
        this.annotationHelper.AddAnnotation(AnnotationType.Name, description);
    }

}
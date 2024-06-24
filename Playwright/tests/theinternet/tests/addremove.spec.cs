namespace Playwright;
using FluentAssertions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using AddRemove.model;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class addremoveTest : PageTest
{
    [Test]
    public async Task NavigateToAddRemovePage()
    {
        AddRemove addRemove = new AddRemove(await Browser.NewPageAsync());
        await addRemove.GotoAsync();

        await addRemove.clickAddRemoveLink();



        // Expect a title "to contain" a substring.
        // await Expect(abTesting.abTestingDescription()).ToContainTextAsync("Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).");
    }

    // [Test]
    // public async Task addElement()
    // {
    //     await AddRemove
    // }

    // [Test]
    // public async Task noImages()
    // {
    //     abTesting abTesting = new abTesting(await Browser.NewPageAsync());
    //     abTesting._page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
    //     await abTesting._page.RouteAsync("**/*", async route =>
    //     {
    //         if (route.Request.ResourceType == "image")
    //         {
    //             await route.AbortAsync();
    //         }
    //         else
    //         {
    //             await route.ContinueAsync();
    //         }

    //     });
    //     await abTesting.GotoAsync();


    // }
}
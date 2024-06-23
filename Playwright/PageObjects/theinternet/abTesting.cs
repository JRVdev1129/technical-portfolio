using Microsoft.Playwright;
using TheinternetPage;

namespace AbTesting.model;


// There is no argument given that corresponds to 
// the required parameter 'page' of 'InternetPageModel.InternetPageModel(IPage)'CS7036
public class AbTesting : InternetPageModel
{
    public AbTesting(IPage page) : base(page)
    {
    }

    public ILocator abTestingDescription()
    {
        return _page.Locator(".example p");
    }



    public async Task ClickStartedLink() => await abTestingDescription().TextContentAsync();
    // public async Task ClickStartedLinkNetworkEvent()
    // {

    //     // Waits for the next response with the specified url.
    //     var getResponse = await _page.RunAndWaitForResponseAsync(async () =>
    //     {
    //         await getStartedLink().ClickAsync();
    //     }, x => x.Url.Contains("playwright"));
    //     await _page.WaitForURLAsync("https://playwright.dev/docs/intro");
    // }

    // public async Task ClickStartedLinkWaitForResponse()
    // {
    //     // await getStartedLink().ClickAsync();
    //     // await _page.WaitForURLAsync("https://playwright.dev/docs/intro");

    //     // Waits for the next response with the specified url.
    //     //     await _page.RunAndWaitForResponseAsync(async () =>
    //     //    {
    //     //        await getStartedLink().ClickAsync();
    //     //    }, "https://playwright.dev/docs/intro");

    //     // Alternative way with a predicate.
    //     var x = await _page.RunAndWaitForResponseAsync(async () =>
    //      {
    //          await getStartedLink().ClickAsync();
    //      }, response => response.Status == 200);
    //     // response url is dynamic, can't log body
    //     // response.Url == "https://playwright.dev/docs/intro" 
    // }

    // public async Task<Boolean> CheckInstallationButton() => await installationButton().IsVisibleAsync();


}
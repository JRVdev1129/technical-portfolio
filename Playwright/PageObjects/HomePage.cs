using Microsoft.Playwright;

namespace HomePage.model;


public class HomePage
{
    public IPage _page;
    public HomePage(IPage page) => _page = page;

    private ILocator getStartedLink()
    {
        return _page.Locator("text=Get started");
    }

    private ILocator installationButton()
    {
        return _page.Locator("header h1");
    }


    public async Task GotoAsync()
    {
        await _page.GotoAsync("https://playwright.dev");
    }

    public async Task ClickStartedLink() => await getStartedLink().ClickAsync();
    public async Task ClickStartedLinkNetworkEvent()
    {

        // Waits for the next response with the specified url.
        var getResponse = await _page.RunAndWaitForResponseAsync(async () =>
        {
            await getStartedLink().ClickAsync();
        }, x => x.Url.Contains("playwright"));
        await _page.WaitForURLAsync("https://playwright.dev/docs/intro");
    }

    public async Task ClickStartedLinkWaitForResponse()
    {
        // await getStartedLink().ClickAsync();
        // await _page.WaitForURLAsync("https://playwright.dev/docs/intro");

        // Waits for the next response with the specified url.
        //     await _page.RunAndWaitForResponseAsync(async () =>
        //    {
        //        await getStartedLink().ClickAsync();
        //    }, "https://playwright.dev/docs/intro");

        // Alternative way with a predicate.
        var x = await _page.RunAndWaitForResponseAsync(async () =>
         {
             await getStartedLink().ClickAsync();
         }, response => response.Status == 200);
        // response url is dynamic, can't log body
        // response.Url == "https://playwright.dev/docs/intro" 
    }

    public async Task<Boolean> CheckInstallationButton() => await installationButton().IsVisibleAsync();


}
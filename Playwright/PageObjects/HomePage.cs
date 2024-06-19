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
    public async Task<Boolean> CheckInstallationButton() => await installationButton().IsVisibleAsync();


}
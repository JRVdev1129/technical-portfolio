using Microsoft.Playwright;


namespace TheinternetPage
{
    public class InternetPageModel
    {


        public IPage _page;
        public InternetPageModel(IPage page) => _page = page;


        private ILocator abTestingLink()
        {
            return _page.Locator("#content  ul li:nth-child(1) a");
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync("https://the-internet.herokuapp.com/");
        }


        public async Task ClickABTestingLink()
        {

            await _page.RunAndWaitForResponseAsync(async () =>
            {
                await abTestingLink().ClickAsync();
            }, response => response.Url.Contains("abtest") && response.Status == 200);

            await _page.WaitForURLAsync("https://the-internet.herokuapp.com/abtest");
        }


    }
}
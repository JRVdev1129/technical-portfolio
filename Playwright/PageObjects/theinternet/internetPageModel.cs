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

        private ILocator addRemoveLink()
        {
            return _page.Locator("#content  ul li:nth-child(2) a");
        }

        private ILocator basicAuthLink()
        {
            return _page.Locator("#content  ul li:nth-child(3) a");
        }

        private ILocator brokenImagesLink()
        {
            return _page.Locator("#content  ul li:nth-child(4) a");
        }

        private ILocator challengingDOMLink()
        {
            return _page.Locator("#content  ul li:nth-child(5) a");
        }

        private ILocator checkboxesLink()
        {
            return _page.Locator("#content  ul li:nth-child(6) a");
        }

        private ILocator contextMenuLink()
        {
            return _page.Locator("#content  ul li:nth-child(7) a");
        }

        private ILocator digestAuthenticationLink()
        {
            return _page.Locator("#content  ul li:nth-child(8) a");
        }

        private ILocator disappearingElementsLink()
        {
            return _page.Locator("#content  ul li:nth-child(9) a");
        }

        private ILocator dragAndDropLinkLink()
        {
            return _page.Locator("#content  ul li:nth-child(10) a");
        }

        private ILocator dropdownLink()
        {
            return _page.Locator("#content  ul li:nth-child(11) a");
        }

        private ILocator dynamicContentLink()
        {
            return _page.Locator("#content  ul li:nth-child(12) a");
        }

        private ILocator dynamicControlsLink()
        {
            return _page.Locator("#content  ul li:nth-child(13) a");
        }

        private ILocator dynamicLoadingLink()
        {
            return _page.Locator("#content  ul li:nth-child(14) a");
        }

        private ILocator entryAdLink()
        {
            return _page.Locator("#content  ul li:nth-child(15) a");
        }

        private ILocator exitIntentLink()
        {
            return _page.Locator("#content  ul li:nth-child(16) a");
        }

        private ILocator fileDownloadLink()
        {
            return _page.Locator("#content  ul li:nth-child(17) a");
        }

        private ILocator fileUploadLink()
        {
            return _page.Locator("#content  ul li:nth-child(18) a");
        }

        private ILocator floatingMenu()
        {
            return _page.Locator("#content  ul li:nth-child(19) a");
        }

        private ILocator forgotPasswordLink()
        {
            return _page.Locator("#content  ul li:nth-child(20) a");
        }

        private ILocator formAuthenticationLink()
        {
            return _page.Locator("#content  ul li:nth-child(21) a");
        }

        private ILocator framesLink()
        {
            return _page.Locator("#content  ul li:nth-child(22) a");
        }

        private ILocator geolocationLink()
        {
            return _page.Locator("#content  ul li:nth-child(23) a");
        }

        private ILocator horizontalSliderLink()
        {
            return _page.Locator("#content  ul li:nth-child(24) a");
        }

        private ILocator hoversLink()
        {
            return _page.Locator("#content  ul li:nth-child(25) a");
        }

        private ILocator infiniteScrollLink()
        {
            return _page.Locator("#content  ul li:nth-child(26) a");
        }

        private ILocator inputsLink()
        {
            return _page.Locator("#content  ul li:nth-child(27) a");
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


        public async Task clickAddRemoveLink()
        {

            await _page.RunAndWaitForResponseAsync(async () =>
            {
                await addRemoveLink().ClickAsync();
            }, response => response.Url.Contains("add_remove_elements") && response.Status == 200);

            await _page.WaitForURLAsync("https://the-internet.herokuapp.com/add_remove_elements/");
        }



    }
}
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class DynamicControlPageModel : InternetPageModel
    {



        public DynamicControlPageModel(IPage page) : base(page)
        {


        }


        private ILocator dynamicControlsLink()
        {

            return this.Page.Locator("#content  ul li:nth-child(13) a");
        }



        public ILocator checkbox()
        {
            return this.Page.Locator("#checkbox input");
        }

        public ILocator removeAddButton()
        {
            return this.Page.Locator("#checkbox-example > button");
        }

        public ILocator loadingText()
        {
            return this.Page.GetByText("Wait for it...");
        }

        public ILocator removeAddText()
        {
            return this.Page.Locator("#checkbox-example #message");
        }

        public ILocator input()
        {
            return this.Page.Locator("#input-example > input");
        }

        public ILocator enableDisableButton()
        {
            return this.Page.Locator("#input-example > button");
        }


        public async Task clickRemoveButton() => await removeAddButton().ClickAsync();

        public async Task clickDynamicControlsLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to dynamic controls page");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await dynamicControlsLink().ClickAsync();
            }, response => response.Url.Contains("dynamic_controls") && response.Status == 200);


        }

    }
}
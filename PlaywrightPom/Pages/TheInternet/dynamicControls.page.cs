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

            // await Expect(page.GetByText("A checkbox")).ToBeVisibleAsync();
            // await page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
            // await Expect(page.GetByText("Wait for it...")).ToBeVisibleAsync();
            // await Expect(page.GetByText("It's gone!")).ToBeVisibleAsync();
            // await Expect(page.GetByRole(AriaRole.Button, new() { Name = "Add" })).ToBeVisibleAsync();
            // await page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            // await Expect(page.GetByText("Wait for it...").First).ToBeVisibleAsync();
            // await Expect(page.GetByText("It's back!")).ToBeVisibleAsync();
            // await Expect(page.GetByText("A checkbox")).ToBeVisibleAsync();

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
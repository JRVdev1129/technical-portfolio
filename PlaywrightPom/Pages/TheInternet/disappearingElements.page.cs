using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class DisappearingElementsPageModel : InternetPageModel
    {



        public DisappearingElementsPageModel(IPage page) : base(page)
        {


        }


        private ILocator disappearingElementsLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(9) a");
        }

        public ILocator element()
        {
            return this.Page.Locator(".example li:first-child");
        }


        public ILocator elements()
        {
            return this.Page.Locator(".example li");
        }

        public async Task<int> elementCount()
        {
            await element().WaitForAsync();
            return await elements().CountAsync();
        }

        public async Task clickCheckBox() => await elements().CheckAsync();




        public async Task clickDisappearingelementsLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to disappearing elements pages");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await disappearingElementsLink().ClickAsync();
            }, response => response.Url.Contains("disappearing_elements") && response.Status == 200);


        }

    }
}
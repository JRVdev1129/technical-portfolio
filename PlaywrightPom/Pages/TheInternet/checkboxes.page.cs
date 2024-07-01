using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class CheckboxesPageModel : InternetPageModel
    {



        public CheckboxesPageModel(IPage page) : base(page)
        {


        }

        private ILocator checkboxesLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(6) a");
        }

        public ILocator checkbox()
        {
            return this.Page.Locator("#checkboxes input:first-child");
        }

        public async Task clickCheckBox() => await checkbox().CheckAsync();




        public async Task clickCheckboxesLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to checkbox pages");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await checkboxesLink().ClickAsync();
            }, response => response.Url.Contains("checkboxes") && response.Status == 200);


        }




    }
}
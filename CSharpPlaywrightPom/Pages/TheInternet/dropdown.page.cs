using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class DropdownPageModel : InternetPageModel
    {



        public DropdownPageModel(IPage page) : base(page)
        {


        }



        private ILocator dropdownLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(11) a");
        }



        public ILocator dropdownElement()
        {
            return this.Page.Locator("select#dropdown");
        }


        public ILocator optionOne()
        {
            return this.Page.Locator("select#dropdown option[value=\"1\"]");
        }

        public async Task clickDropdownLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to dropdown page");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await dropdownLink().ClickAsync();
            }, response => response.Url.Contains("dropdown") && response.Status == 200);


        }

    }
}
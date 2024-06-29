using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class AddRemovePageModel : InternetPageModel
    {



        public AddRemovePageModel(IPage page) : base(page)
        {


        }



        private ILocator addRemoveLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(2) a");
        }


        public ILocator addElementButton()
        {
            return this.Page.Locator("div.example > button");
        }

        public ILocator deleteElementButton()
        {
            return this.Page.Locator("#elements .added-manually");
        }

        private ILocator addRemoveTitle()
        {
            return this.Page.Locator("#content h3");
        }


        /// <summary>
        /// Gets the description of the ab testing page
        /// </summary>
        /// <returns>string</returns>
        public async Task clickAddElementButton() => await addElementButton().ClickAsync();



        public async Task clickdeleteElementButton() => await deleteElementButton().ClickAsync();


        public async Task<string> getTitleText() => await addRemoveTitle().TextContentAsync();

        public async Task clickAddRemoveLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to Add/Remove Elements");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await addRemoveLink().ClickAsync();
            }, response => response.Url.Contains("add_remove_elements") && response.Status == 200);

            await this.Page.WaitForURLAsync("https://the-internet.herokuapp.com/add_remove_elements/");
        }





    }
}
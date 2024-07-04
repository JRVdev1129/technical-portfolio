using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class AuthPageModel : InternetPageModel
    {



        public AuthPageModel(IPage page) : base(page)
        {


        }

        private ILocator basicAuthLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(3) a");
        }

        public ILocator authPageMessage()
        {
            return this.Page.Locator("#content p");
        }

        public async Task clickAuthLink() => await basicAuthLink().ClickAsync();
        public async Task<string> getAuthDescription() => await authPageMessage().TextContentAsync();




        public async Task clickAddRemoveLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to Add/Remove Elements");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await basicAuthLink().ClickAsync();
            }, response => response.Url.Contains("add_remove_elements") && response.Status == 200);

            await this.Page.WaitForURLAsync("https://the-internet.herokuapp.com/add_remove_elements/");
        }

        public async Task interactWithDialog()
        {

            this.Page.Dialog += async (_, dialog) =>
             {

                 Console.WriteLine(dialog.Type);
             };
        }



    }
}
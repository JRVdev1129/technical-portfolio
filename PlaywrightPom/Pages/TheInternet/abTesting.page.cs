using System.Threading.Tasks;
using Microsoft.Playwright;
using sauceDemo.Base;


namespace sauceDemo.Pages
{
    public class ABTestingPageModel : InternetPageModel
    {



        public ABTestingPageModel(IPage page) : base(page)
        {


        }



        // public void AddAnotation(string desc)
        // {
        //     this.annotationHelper.AddAnnotation(AnnotationType.Description, desc);
        // }

        public ILocator abTestingDescription()
        {
            return this.Page.Locator(".example p");
        }

        /// <summary>
        /// Gets the description of the ab testing page
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> getABTestingDescription() => await abTestingDescription().TextContentAsync();



        private ILocator abTestingLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(1) a");
        }

        /// <summary>
        /// Clicks ab testing link in the homepage
        /// </summary>
        /// <returns></returns>
        public async Task ClickABTestingLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to AB testing");

            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await abTestingLink().ClickAsync();
            }, response => response.Url.Contains("abtest") && response.Status == 200);

            await this.Page.WaitForURLAsync("https://the-internet.herokuapp.com/abtest");
        }



    }
}
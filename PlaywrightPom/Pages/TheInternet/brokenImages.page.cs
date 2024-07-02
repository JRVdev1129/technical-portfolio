using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class BrokenImagesPageModel : InternetPageModel
    {



        public BrokenImagesPageModel(IPage page) : base(page)
        {


        }

        private ILocator brokenImagesLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(4) a");
        }

        public ILocator brokenImages()
        {
            return this.Page.Locator(".example img");
        }

        public async Task<int> imageCount()
        {
            return await brokenImages().CountAsync();
        }

        // public async Task<string> getAuthDescription() => await authPageMessage().TextContentAsync();




        public async Task clickBrokenImagesLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to Broken Images Elements");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await brokenImagesLink().ClickAsync();
            }, response => response.Url.Contains("broken_images") && response.Status == 200);

            await this.Page.WaitForURLAsync("https://the-internet.herokuapp.com/broken_images");
        }

    }
}
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class DynamicContentPageModel : InternetPageModel
    {



        public DynamicContentPageModel(IPage page) : base(page)
        {


        }


        private ILocator dynamicContentLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(12) a");
        }


        public ILocator images()
        {
            return this.Page.Locator("#content #content .row img");
        }

        public ILocator paragraphs()
        {
            return this.Page.Locator("#content #content .row > .large-10");
        }

        public async Task<IReadOnlyList<string>> getAllParagraphsContent()
        {
            var paragraphsContent = await paragraphs().AllTextContentsAsync();
            return paragraphsContent;


        }

        public async Task<List<string>> getAllImagesSource()
        {
            List<string> listOfSources = new List<string>();
            foreach (var image in await images().AllAsync())
                listOfSources.Add(await image.GetAttributeAsync("src"));

            return listOfSources;


        }

        public async Task clickDynamicContentLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to dynamic content page");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await dynamicContentLink().ClickAsync();
            }, response => response.Url.Contains("dynamic_content") && response.Status == 200);


        }

    }
}
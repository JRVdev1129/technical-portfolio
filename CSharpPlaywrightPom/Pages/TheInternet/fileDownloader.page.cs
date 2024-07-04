using System.Threading.Tasks;
using System.Linq;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class FileDownloaderPageModel : InternetPageModel
    {



        public FileDownloaderPageModel(IPage page) : base(page)
        {


        }


        private ILocator fileDownloadLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(17) a");
        }


        public ILocator bladeHeroImg()
        {
            return this.Page.Locator(".example > a:nth-child(2)");
        }

        public async Task<string> clickBladeHeroImg()
        {

            await Assertions.Expect(bladeHeroImg()).ToBeVisibleAsync();
            var download = await this.Page.RunAndWaitForDownloadAsync(async () =>
            {
                await this.Page.GetByRole(AriaRole.Link, new() { Name = "some-file.txt" }).ClickAsync();
            });
            var downloadPath = "../../assets/downloads/" + download.SuggestedFilename;
            await download.SaveAsAsync(downloadPath);
            return downloadPath;
        }

        public async Task clickFileDownloaderLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to File Downloader page");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await fileDownloadLink().ClickAsync();
            }, response => response.Url.Contains("download") && response.Status == 200);


        }

    }
}
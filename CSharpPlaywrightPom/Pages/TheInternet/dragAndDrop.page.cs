using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class DragAndDropPageModel : InternetPageModel
    {



        public DragAndDropPageModel(IPage page) : base(page)
        {


        }


        private ILocator dragAndDropLinkLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(10) a");
        }


        public ILocator columnA()
        {
            return this.Page.Locator("#column-a");
        }


        public ILocator columnB()
        {
            return this.Page.Locator("#column-b");
        }

        public ILocator columnAText()
        {
            return this.Page.Locator("#column-a header");
        }

        public ILocator columnBText()
        {
            return this.Page.Locator("#column-b header");
        }

        public async Task dragAndDropColumnAToB()
        {
            await columnA().DragToAsync(columnBText());
        }



        public async Task clickDragAndDropLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to Drag And Drop page");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await dragAndDropLinkLink().ClickAsync();
            }, response => response.Url.Contains("drag_and_drop") && response.Status == 200);


        }

    }
}
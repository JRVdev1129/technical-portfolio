using System.Threading.Tasks;
using Microsoft.Playwright;
using internet.Base;


namespace internet.Pages
{
    public class ContextMenuPageModel : InternetPageModel
    {



        public ContextMenuPageModel(IPage page) : base(page)
        {


        }


        private ILocator contextMenuLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(7) a");
        }

        private ILocator checkboxesLink()
        {
            return this.Page.Locator("#content  ul li:nth-child(6) a");
        }

        public ILocator item()
        {
            return this.Page.Locator("#hot-spot");
        }

        public async Task<string> triggersDialog()
        {

            String? message = null;
            var setMessage = new TaskCompletionSource<string>();



            void getContextMenuDialog(object sender, IDialog dialog)
            {
                // Console.WriteLine($"Dialog message: {dialog.Message} lol {dialog.Type}");
                dialog.DismissAsync();
                this.Page.Dialog -= getContextMenuDialog;
                setMessage.SetResult(dialog.Message);
            }
            this.Page.Dialog += getContextMenuDialog;
            await item().ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            message = await setMessage.Task;

            return message;

        }


        public async Task getDialogMessage()
        {
            Page.Dialog += async (_, dialog) =>
                {
                    System.Console.WriteLine(dialog.Message);
                    await dialog.DismissAsync();
                };

            await this.Page.EvaluateAsync("alert('1');");
        }

        public async Task clickContextMenuLink()
        {
            this.annotationHelper.AddAnnotation(AnnotationType.Step, "Navigates to context menu page");


            await this.Page.RunAndWaitForResponseAsync(async () =>
            {
                await contextMenuLink().ClickAsync();
            }, response => response.Url.Contains("context") && response.Status == 200);


        }




    }
}
using Microsoft.Playwright;
using TheinternetPage;

namespace AddRemove.model;

public class AddRemove : InternetPageModel
{
    public AddRemove(IPage page) : base(page)
    {
    }

    private ILocator addElementButton()
    {
        return _page.Locator("div.example > button");
    }

    public ILocator deleteElementButton()
    {
        return _page.Locator("#elements .added-manually");
    }

    public async Task clickAddElementButton() => await addElementButton().ClickAsync();
    public async Task clickdeleteElementButton() => await deleteElementButton().ClickAsync();


}
import { $ } from '@wdio/globals';
import Page from './page.js';

class ContextMenuPage extends Page {
    public get contextMenuLink()
    {
        return $("#content  ul li:nth-child(7) a");
    }


    public get item()
    {
        return $("#hot-spot");
    }


  public open() {
    return super.open();
  }
}

export default new ContextMenuPage();

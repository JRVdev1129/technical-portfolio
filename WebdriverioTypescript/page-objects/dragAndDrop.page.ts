import { $ } from '@wdio/globals';
import Page from './page.js';

class DragAndDropPage extends Page {
    public get dragAndDropLink()
    {
        return $("#content  ul li:nth-child(10) a");
    }


    public get columnA()
    {
        return $("#column-a");
    }


    public get columnB()
    {
        return $("#column-b");
    }

    public get columnAText()
    {
        return $("#column-a header");
    }

    public get columnBText()
    {
        return $("#column-b header");
    }


  public open() {
    return super.open();
  }
}

export default new DragAndDropPage();

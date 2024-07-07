import { $ } from '@wdio/globals';
import Page from './page.js';

class DropDownPage extends Page {
    public get dropdownLink()
    {
        return $("#content  ul li:nth-child(11) a");
    }



    public get dropdownElement()
    {
        return $("select#dropdown");
    }


    public get optionOne()
    {
        return $("select#dropdown option[value=\"1\"]");
    }

  public open() {
    return super.open();
  }
}

export default new DropDownPage();

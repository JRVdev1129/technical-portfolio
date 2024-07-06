import { $ } from "@wdio/globals";
import Page from "./page.js";

/**
 * sub page containing specific selectors and methods for a specific page
 */
class LoginPage extends Page {
  public get abTestingDescription() {
    return $(".example p");
  }



  public get abTestingLink() {
    return $("#content  ul li:nth-child(1) a");
  }


  /**
   * overwrite specific options to adapt it to page object
   */
  public open() {
    return super.open();
  }
}

export default new LoginPage();

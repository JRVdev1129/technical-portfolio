import { $ } from '@wdio/globals';
import Page from './page.js';

/**
 * sub page containing specific selectors and methods for a specific page
 */
class BrokenImagesPage extends Page {
  public get brokenImagesLink() {
    return $('#content  ul li:nth-child(4) a');
  }

  public get brokenImage() {
    return $('.example img');
  }
  public get brokenImages() {
    return $$('.example img');
  }

  /**
   * overwrite specific options to adapt it to page object
   */
  public open() {
    return super.open();
  }
}

export default new BrokenImagesPage();

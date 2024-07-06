import { $ } from '@wdio/globals';
import Page from './page.js';

/**
 * sub page containing specific selectors and methods for a specific page
 */
class CheckboxesPage extends Page {
  public get checkboxesLink() {
    return $('#content  ul li:nth-child(6) a');
  }

  public get checkbox() {
    return $('#checkboxes input:first-child');
  }

  /**
   * overwrite specific options to adapt it to page object
   */
  public open() {
    return super.open();
  }
}

export default new CheckboxesPage();

import { $ } from '@wdio/globals';
import Page from './page.js';

class DisappearingElementsPage extends Page {
  public get disappearingElementsLink() {
    return $('#content  ul li:nth-child(9) a');
  }

  public get element() {
    return $('.example li:first-child');
  }

  public get elements() {
    return $$('.example li');
  }

  public open() {
    return super.open();
  }
}

export default new DisappearingElementsPage();

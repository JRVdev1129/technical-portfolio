import { $ } from '@wdio/globals';
import Page from './page.js';

class DynamicControlsPage extends Page {
  public get dynamicControlsLink() {
    return $('#content  ul li:nth-child(13) a');
  }

  public get checkbox() {
    return $('#checkbox input');
  }

  public get removeAddButton() {
    return $('#checkbox-example > button');
  }

  public get loadingText() {
    return $('#loading');
  }

  public get removeAddText() {
    return $('#checkbox-example #message');
  }

  public get input() {
    return $('#input-example > input');
  }

  public get enableDisableButton() {
    return $('#input-example > button');
  }
  public open() {
    return super.open();
  }
}

export default new DynamicControlsPage();

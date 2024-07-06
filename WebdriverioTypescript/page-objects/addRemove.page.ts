import { $ } from '@wdio/globals';
import Page from './page.js';

class AddRemovePage extends Page {
  public get addRemoveLink() {
    return $('#content  ul li:nth-child(2) a');
  }

  public get addElementButton() {
    return $('div.example > button');
  }

  public get deleteElementButton() {
    return $('#elements .added-manually');
  }

  public get addRemoveTitle() {
    return $('#content h3');
  }

  public open() {
    return super.open();
  }
}

export default new AddRemovePage();

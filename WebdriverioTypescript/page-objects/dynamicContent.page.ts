import { $ } from '@wdio/globals';
import Page from './page.js';

class DropDownPage extends Page {
  public get dynamicContentLink() {
    return $('#content  ul li:nth-child(12) a');
  }

  public get image() {
    return $('#content #content .row img');
  }

  public get images() {
    return $$('#content #content .row img');
  }

  public get paragraphs() {
    return $$('#content #content .row > .large-10');
  }

  public async getAllImagesSource() {
    let imageSources = this.images.map(async (image) => await image.getAttribute('src'));
    return imageSources;
  }

  public async getAllParagraphTexts() {
    let imageSources = this.paragraphs.map(async (image) => await image.getText());
    return imageSources;
  }

  public open() {
    return super.open();
  }
}

export default new DropDownPage();

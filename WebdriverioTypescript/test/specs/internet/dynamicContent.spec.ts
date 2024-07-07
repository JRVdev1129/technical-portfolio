import { expect } from '@wdio/globals';
import { expect as mochaExpect } from 'chai';

import dynamicContentPage from '../../../page-objects/dynamicContent.page.js';

describe('Scenario: internet heroku', function () {
  describe('Feature: dynamicContent', function () {
    before(async function () {
      await dynamicContentPage.open();
      (await dynamicContentPage.dynamicContentLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function () {
      describe('When: User clicks dynamic content link', function () {
        it('Then: User should be redirected to dynamic content page', async function () {
          await dynamicContentPage.dynamicContentLink.click();
          await dynamicContentPage.image.waitForExist();
          await expect(await dynamicContentPage.image).toBeDisplayed();
        });
      });

      describe('When: User refreshes the dynamic content page', function () {
        it('Then: At least one Element should change', async function () {
          const previousImageSources = await dynamicContentPage.getAllImagesSource();
          const previousParagraphsSources = await dynamicContentPage.getAllParagraphTexts();
          await browser.refresh();
          await browser.pause(1000);

          const currentImageSources = await dynamicContentPage.getAllImagesSource();
          const currentParagraphsSources = await dynamicContentPage.getAllParagraphTexts();
          mochaExpect(previousImageSources).to.not.equal(currentImageSources);
          mochaExpect(previousParagraphsSources).to.not.equal(currentParagraphsSources);

        });
      });
    });
  });
});

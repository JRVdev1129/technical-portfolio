import { expect } from '@wdio/globals';
import brokenImagesPage from '../../../page-objects/brokenImages.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: ab Testing', function() {
    before(async function () {
      await brokenImagesPage.open();
      (await brokenImagesPage.brokenImagesLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function() {
      describe('When: user clicks broken images link', function() {
        it('Then: User should be redirected to broken images page', async function() {
          await brokenImagesPage.brokenImagesLink.click();
          await brokenImagesPage.brokenImage.waitForExist();
          await expect(await brokenImagesPage.brokenImage).toBeDisplayed();
        });

 
          it('Then: 3 images should be displayed', async function() {
            await expect(await brokenImagesPage.brokenImages.length).toBeGreaterThanOrEqual(3);
          });
    

      });
    });
  });
});

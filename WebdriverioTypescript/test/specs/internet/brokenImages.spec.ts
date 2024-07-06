import { expect } from '@wdio/globals';
import brokenImages from '../../../page-objects/brokenImages.page.js';

describe('Scenario: internet heroku', () => {
  describe('Feature: ab Testing', () => {
    before(async function () {
      await brokenImages.open();
      (await brokenImages.brokenImagesLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', () => {
      describe('When: user clicks broken images link', () => {
        it('Then: User should be redirected to broken images page', async () => {
          await brokenImages.brokenImagesLink.click();
          await brokenImages.brokenImage.waitForExist();
          await expect(await brokenImages.brokenImage).toBeDisplayed();
        });

 
          it('Then: 3 images should be displayed', async () => {
            await expect(await brokenImages.brokenImages.length).toBeGreaterThanOrEqual(3);
          });
    

      });
    });
  });
});

import { expect } from '@wdio/globals';

import dynamicControlPage from '../../../page-objects/dynamicControls.page.js';

describe('Scenario: internet heroku', function () {
  describe('Feature: dynamic controls', function () {
    before(async function () {
      await dynamicControlPage.open();
      (await dynamicControlPage.dynamicControlsLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function () {
      describe('When: User clicks dynamic controls link', function () {
        it('Then: User should be redirected to dynamic controls page', async function () {
          await dynamicControlPage.dynamicControlsLink.click();
          await dynamicControlPage.checkbox.waitForExist();
          await expect(await dynamicControlPage.checkbox).toBeDisplayed();
        });
      });

      describe('When: Clicks the remove button', function () {
        it('Then: Checkbox element should be deleted from the page', async function () {
          await dynamicControlPage.removeAddButton.click();
          await expect(await dynamicControlPage.loadingText).toBeDisplayed();
          await dynamicControlPage.loadingText.waitForDisplayed({ reverse: true });
          await expect(await dynamicControlPage.checkbox.isDisplayed()).toBeFalsy;
        });
      });
    });
  });
});

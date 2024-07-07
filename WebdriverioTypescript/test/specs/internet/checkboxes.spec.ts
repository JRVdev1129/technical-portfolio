import { expect } from '@wdio/globals';
import checkboxes from '../../../page-objects/checkboxes.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: checkboxes', function() {
    before(async function () {
      await checkboxes.open();
      (await checkboxes.checkboxesLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function() {
      describe('When: user clicks checkboxes link', function() {
        it('Then: User should be redirected to checkboxes page', async function() {
          await checkboxes.checkboxesLink.click();
          await checkboxes.checkbox.waitForExist();
          await expect(await checkboxes.checkbox).toBeDisplayed();
        });
      });

      describe('When: user clicks checkbox', function() {
        it('Then: checkbox should be enabled', async function() {
          await checkboxes.checkbox.click();
          await expect(await checkboxes.checkbox).toBeSelected();
        });
      });
    });
  });
});

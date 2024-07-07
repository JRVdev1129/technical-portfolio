import { expect } from '@wdio/globals';
import checkboxesPage from '../../../page-objects/checkboxes.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: checkboxes', function() {
    before(async function () {
      await checkboxesPage.open();
      (await checkboxesPage.checkboxesLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function() {
      describe('When: user clicks checkboxes link', function() {
        it('Then: User should be redirected to checkboxes page', async function() {
          await checkboxesPage.checkboxesLink.click();
          await checkboxesPage.checkbox.waitForExist();
          await expect(await checkboxesPage.checkbox).toBeDisplayed();
        });
      });

      describe('When: user clicks checkbox', function() {
        it('Then: checkbox should be enabled', async function() {
          await checkboxesPage.checkbox.click();
          await expect(await checkboxesPage.checkbox).toBeSelected();
        });
      });
    });
  });
});

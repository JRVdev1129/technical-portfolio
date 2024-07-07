import { expect } from '@wdio/globals';
import dropdownPage from '../../../page-objects/dropdown.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: dropdown', function() {
    before(async function () {
      await dropdownPage.open();
      (await dropdownPage.dropdownLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function() {
      describe('When: User clicks dropdown link', function() {
        it('Then: User should be redirected to dropdown page', async function() {
          await dropdownPage.dropdownLink.click();
          await dropdownPage.dropdownElement.waitForExist();
          await expect(await dropdownPage.dropdownElement).toBeDisplayed();          
        });
      });

      describe('When: User clicks on the dropdown element', function() {
        it('Then: User should be able to select an option', async function() {
            await dropdownPage.dropdownElement.selectByAttribute('value', '1');
            await expect(await dropdownPage.dropdownElement.getValue()).toContain("1");
        });
      });
    });
  });
});

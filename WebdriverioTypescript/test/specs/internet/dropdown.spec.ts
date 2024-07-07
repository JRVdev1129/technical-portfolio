import { expect } from '@wdio/globals';
import dropdown from '../../../page-objects/dropdown.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: dropdown', function() {
    before(async function () {
      await dropdown.open();
      (await dropdown.dropdownLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function() {
      describe('When: User clicks dropdown link', function() {
        it('Then: User should be redirected to dropdown page', async function() {
          await dropdown.dropdownLink.click();
          await dropdown.dropdownElement.waitForExist();
          await expect(await dropdown.dropdownElement).toBeDisplayed();          
        });
      });

      describe('When: User clicks on the dropdown element', function() {
        it('Then: User should be able to select an option', async function() {
            await dropdown.dropdownElement.selectByAttribute('value', '1');
            await expect(await dropdown.dropdownElement.getValue()).toContain("1");
        });
      });
    });
  });
});

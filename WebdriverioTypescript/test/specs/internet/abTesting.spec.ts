import { expect } from '@wdio/globals';
import abTestingPage from '../../../page-objects/abTesting.page.js';

describe('Scenario: internet heroku', function()  {
  describe('Feature: ab Testing', function()  {
    before(async function () {
      await abTestingPage.open();
      (await abTestingPage.abTestingLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function()  {
      describe('When: user clicks ab testing link', function()  {
        it('Then: User should be redirected to ab testing page', async function()  {
          await abTestingPage.abTestingLink.click();
          await abTestingPage.abTestingDescription.waitForExist();
          await expect(await abTestingPage.abTestingDescription).toBeDisplayed();
        });

        it('Then: ab testing description should be displayed', async function()  {
          await expect(await abTestingPage.abTestingDescription.getText()).toContain(
            'Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).',
          );
        });
      });
    });
  });
});

import { expect } from '@wdio/globals';
import abTesting from '../../../page-objects/abTesting.page.js';

describe('Scenario: internet heroku', () => {
  describe('Feature: ab Testing', () => {
    before(async function () {
      await abTesting.open();
      (await abTesting.abTestingLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', () => {
      describe('When: user clicks ab testing link', () => {
        it('Then: User should be redirected to ab testing page', async () => {
          await abTesting.abTestingLink.click();
          await abTesting.abTestingDescription.waitForExist();
          await expect(await abTesting.abTestingDescription).toBeDisplayed();
        });

        it('Then: ab testing description should be displayed', async () => {
          await expect(await abTesting.abTestingDescription.getText()).toContain(
            'Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).',
          );
        });
      });
    });
  });
});

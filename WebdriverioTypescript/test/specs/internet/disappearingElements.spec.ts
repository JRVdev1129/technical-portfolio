import { expect } from '@wdio/globals';
import disappearingElementsPage from '../../../page-objects/disappearingElements.js';

describe('Scenario: internet heroku', function () {
  describe('Feature: disappearing Elements', function () {
    before(async function () {
      await disappearingElementsPage.open();
      (await disappearingElementsPage.disappearingElementsLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function () {
      describe('When: user clicks disappearing Elements link', function () {
        it('Then: User should be redirected to disappearing Elements page', async function () {
          await disappearingElementsPage.disappearingElementsLink.click();
          await disappearingElementsPage.element.waitForExist();
          await expect(await disappearingElementsPage.element).toBeDisplayed();
        });

        it('Then: page should have 5 elements displayed', async function () {
          await expect(await disappearingElementsPage.elements.length).toBeGreaterThanOrEqual(5);
        });
      });
    });
  });
});

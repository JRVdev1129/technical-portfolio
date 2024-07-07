import { expect } from '@wdio/globals';
import disappearingElements from '../../../page-objects/disappearingElements.js';

describe('Scenario: internet heroku', function () {
  describe('Feature: disappearing Elements', function () {
    before(async function () {
      await disappearingElements.open();
      (await disappearingElements.disappearingElementsLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function () {
      describe('When: user clicks disappearing Elements link', function () {
        it('Then: User should be redirected to disappearing Elements page', async function () {
          await disappearingElements.disappearingElementsLink.click();
          await disappearingElements.element.waitForExist();
          await expect(await disappearingElements.element).toBeDisplayed();
        });

        it('Then: page should have 5 elements displayed', async function () {
          await expect(await disappearingElements.elements.length).toBeGreaterThanOrEqual(5);
        });
      });
    });
  });
});

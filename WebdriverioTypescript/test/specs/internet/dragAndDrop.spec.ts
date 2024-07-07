import { expect } from '@wdio/globals';
import dragAndDropPage from '../../../page-objects/dragAndDrop.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: dragAndDrop', function() {
    before(async function () {
      await dragAndDropPage.open();
      (await dragAndDropPage.dragAndDropLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function() {
      describe('When: User clicks drag and drop link', function() {
        it('Then: User should be redirected to drag and drop page', async function() {
          await dragAndDropPage.dragAndDropLink.click();
          await dragAndDropPage.columnA.waitForExist();
          await expect(await dragAndDropPage.columnA).toBeDisplayed();          
        });
      });

      describe('When: User drags and drops col A to col B', function() {
        it('Then: columns should change spaces', async function() {
            await dragAndDropPage.columnA.dragAndDrop(await dragAndDropPage.columnB);
            await expect(await dragAndDropPage.columnA.getText()).toContain("B");
        });
      });
    });
  });
});

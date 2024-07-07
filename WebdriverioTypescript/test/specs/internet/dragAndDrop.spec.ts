import { expect } from '@wdio/globals';
import dragAndDrop from '../../../page-objects/dragAndDrop.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: dragAndDrop', function() {
    before(async function () {
      await dragAndDrop.open();
      (await dragAndDrop.dragAndDropLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function() {
      describe('When: User clicks drag and drop link', function() {
        it('Then: User should be redirected to drag and drop page', async function() {
          await dragAndDrop.dragAndDropLink.click();
          await dragAndDrop.columnA.waitForExist();
          await expect(await dragAndDrop.columnA).toBeDisplayed();          
        });
      });

      describe('When: User drags and drops col A to col B', function() {
        it('Then: columns should change spaces', async function() {
            await dragAndDrop.columnA.dragAndDrop(await dragAndDrop.columnB);
            await expect(await dragAndDrop.columnA.getText()).toContain("B");
        });
      });
    });
  });
});

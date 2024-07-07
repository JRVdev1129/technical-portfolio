import { expect } from '@wdio/globals';
import contextMenu from '../../../page-objects/contextMenu.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: contextMenu', function() {
    before(async function () {
      await contextMenu.open();
      (await contextMenu.contextMenuLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function() {
      describe('When: User clicks contextMenu link', function() {
        it('Then: User should be redirected to contextMenu page', async function() {
          await contextMenu.contextMenuLink.click();
          await contextMenu.item.waitForExist();
          await expect(await contextMenu.item).toBeDisplayed();
        });
      });

      describe('When: User right clicks the box', function() {
        it('Then: A js alert should display', async function() {
          // skip test because of an issue with webdriverio method .click when using option skipRelease
            this.skip();
        });
      });
    });
  });
});

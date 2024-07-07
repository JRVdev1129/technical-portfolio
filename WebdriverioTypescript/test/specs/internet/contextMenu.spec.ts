import { expect } from '@wdio/globals';
import contextMenuPage from '../../../page-objects/contextMenu.page.js';

describe('Scenario: internet heroku', function() {
  describe('Feature: contextMenu', function() {
    before(async function () {
      await contextMenuPage.open();
      (await contextMenuPage.contextMenuLink).waitForDisplayed();
    });

    describe('Given: User navigates to the internet heroku page', function() {
      describe('When: User clicks contextMenu link', function() {
        it('Then: User should be redirected to contextMenu page', async function() {
          await contextMenuPage.contextMenuLink.click();
          await contextMenuPage.item.waitForExist();
          await expect(await contextMenuPage.item).toBeDisplayed();
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

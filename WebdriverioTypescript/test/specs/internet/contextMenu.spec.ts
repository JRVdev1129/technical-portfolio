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
          await contextMenuPage.item.click({ button: 'right', x: 0, y: 0, skipRelease: true });
          await expect(await browser.isAlertOpen()).toBeTruthy();
          await expect(await browser.getAlertText()).toContain('You selected a context menu');
        });
      });
    });
  });
});

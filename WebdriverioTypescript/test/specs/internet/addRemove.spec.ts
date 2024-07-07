import { expect } from '@wdio/globals';
import { expect as mochaExpect } from 'chai';
import addRemovePage from '../../../page-objects/addRemove.page.js';

describe('Scenario: internet heroku', function()  {
  describe('Feature: ab Testing', function()  {
    before(async function () {
      await addRemovePage.open();
      (await addRemovePage.addRemoveLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', function()  {
      describe('When: user clicks add/remove link', function()  {
        it('Then: User should be redirected to add/remove page', async function()  {
          await addRemovePage.addRemoveLink.click();
          await addRemovePage.addRemoveTitle.waitForExist();
          await expect(await addRemovePage.addRemoveTitle).toBeDisplayed();
        });

        describe('When: User clicks Add element button', async function()  {
          it('Then: Delete Button Should be added to the Page', async function()  {
            await addRemovePage.addElementButton.waitForDisplayed();
            await addRemovePage.addElementButton.click();
            await addRemovePage.deleteElementButton.waitForExist();
            await expect(await addRemovePage.deleteElementButton).toBeDisplayed();
          });
        });

        describe('When: User clicks Delete element button', async function()  {
          it('Then: Delete Button Should be removed from the Page', async function()  {
            await addRemovePage.deleteElementButton.click();
            await addRemovePage.deleteElementButton.waitForExist({ reverse: true });
            await mochaExpect(await addRemovePage.deleteElementButton.isDisplayedInViewport()).to.be
              .false;
          });
        });
      });
    });
  });
});

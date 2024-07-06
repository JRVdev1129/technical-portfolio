import { expect } from '@wdio/globals';
import { expect as mochaExpect } from 'chai';
import addRemove from '../../../page-objects/addRemove.page.js';

describe('Scenario: internet heroku', () => {
  describe('Feature: ab Testing', () => {
    before(async function () {
      await addRemove.open();
      (await addRemove.addRemoveLink).waitForDisplayed();
    });

    describe('Given: user navigates to the internet heroku page', () => {
      describe('When: user clicks add/remove link', () => {
        it('Then: User should be redirected to add/remove page', async () => {
          await addRemove.addRemoveLink.click();
          await addRemove.addRemoveTitle.waitForExist();
          await expect(await addRemove.addRemoveTitle).toBeDisplayed();
        });

        describe('When: User clicks Add element button', async () => {
          it('Then: Delete Button Should be added to the Page', async () => {
            await addRemove.addElementButton.waitForDisplayed();
            await addRemove.addElementButton.click();
            await addRemove.deleteElementButton.waitForExist();
            await expect(await addRemove.deleteElementButton).toBeDisplayed();
          });
        });

        describe('When: User clicks Delete element button', async () => {
          it('Then: Delete Button Should be removed from the Page', async () => {
            await addRemove.deleteElementButton.click();
            await addRemove.deleteElementButton.waitForExist({ reverse: true });
            await mochaExpect(await addRemove.deleteElementButton.isDisplayedInViewport()).to.be
              .false;
          });
        });
      });
    });
  });
});

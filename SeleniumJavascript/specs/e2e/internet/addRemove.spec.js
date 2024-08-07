const addRemovePage = require("../../../page-objects/internet/addRemove.page.js");
const { expect } = require("chai");

describe("Scenario: internet heroku", function () {
  describe("Feature: add remove", function () {
    beforeEach(async function () {
      await addRemovePage.open();
      await addRemovePage.clickAddRemoveLink();
      await addRemovePage.waitForElementsByCss("div.example > button", 10000);
    });

    describe("Given: user navigates to the internet heroku page", function () {
      describe("When: user clicks add/remove link", function () {
        it("Then: User should be redirected to add/remove page", async function () {
          await expect(await addRemovePage.getUrl()).to.equal(
            "https://the-internet.herokuapp.com/add_remove_elements/"
          );
        });

        context("When: User clicks Add element button", function () {
          it("Then: Delete Button Should be added to the Page", async function () {
            await addRemovePage.clickAddElementButton();
            const verify = await addRemovePage.verifyDeleteButton();

            await expect(verify).to.be.true;
          });
        });

        context("When: User clicks Delete element button", function () {
          it("Then: Delete Button Should be removed from the Page", async function () {
            // this.skip();
            await addRemovePage.clickAddElementButton();
            await expect(await addRemovePage.verifyDeleteButton()).to.be.true;
            await addRemovePage.clickDeleteElementButton();

            await expect(await addRemovePage.verifyDeleteButton()).to.be.false;
          });
        });
      });
    });
    after(async function () {
      await addRemovePage.closeBrowser();
    });
  });
});

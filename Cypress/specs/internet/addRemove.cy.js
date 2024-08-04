import addRemovePage from "../../page-objects/internet/addRemovePage.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: ab Testing", function () {
    beforeEach(function () {
      addRemovePage.visit();
      addRemovePage.clickAddRemoveLink();
    });

    describe("Given: user navigates to the internet heroku page", function () {
      describe("When: user clicks add/remove link", function () {
        it("Then: User should be redirected to add/remove page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/add_remove_elements/"
            );
          });
        });

        context("When: User clicks Add element button", function () {
          it("Then: Delete Button Should be added to the Page", function () {
            addRemovePage.clickAddElementButton();
            addRemovePage.verifyDeleteButton();
          });
        });

        context("When: User clicks Delete element button", function () {
          it("Then: Delete Button Should be removed from the Page", function () {
            addRemovePage.clickAddElementButton();
            addRemovePage.verifyDeleteButton();
            addRemovePage.clickDeleteElementButton();

            addRemovePage.verifyDeleteElementButtonNotDisplayed();
          });
        });
      });
    });
  });
});

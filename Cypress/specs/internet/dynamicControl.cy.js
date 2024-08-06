import dynamicControlPage from "../../page-objects/internet/dynamicControl.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: dynamic controls", function () {
    beforeEach(function () {
      dynamicControlPage.navigate();
      dynamicControlPage.clickDynamicControlLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks dynamic controls link", function () {
        it("Then: User should be redirected to dynamic controls page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/dynamic_controls"
            );
          });
        });
      });

      context("When: Clicks the remove button", function () {
        it("Then: Checkbox element should be deleted from the page", function () {
          dynamicControlPage.clickRemoveAddButton();
          dynamicControlPage.waitForLoadingText();

          dynamicControlPage.validateElementRemoved();
        });
      });
    });
  });
});

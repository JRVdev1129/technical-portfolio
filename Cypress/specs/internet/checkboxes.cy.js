import checkboxesPage from "../../page-objects/internet/checkboxes.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: checkboxes", function () {
    beforeEach(function () {
      checkboxesPage.navigate();
      checkboxesPage.clickCheckboxesLink();
    });

    context("Given: user navigates to the internet heroku page", function () {
      context("When: user clicks checkboxes link", function () {
        it("Then: User should be redirected to checkboxes page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/checkboxes"
            );
          });
        });
      });

      context("When: user clicks checkbox", function () {
        it("Then: checkbox should be enabled", function () {
          checkboxesPage.clickCheckbox();
          checkboxesPage.verifyCheckboxEnable();
        });
      });
    });
  });
});

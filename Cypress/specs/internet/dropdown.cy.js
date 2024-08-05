import dropdownPage from "../../page-objects/internet/dropdown.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: dropdown", function () {
    beforeEach(function () {
      dropdownPage.navigate();

      dropdownPage.clickDropDownLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks dropdown link", function () {
        it("Then: User should be redirected to dropdown page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/dropdown"
            );
          });
        });
      });

      context("When: User clicks on the dropdown element", function () {
        it("Then: User should be able to select an option", function () {
          dropdownPage.selectValue();
          dropdownPage.validateValue();
        });
      });
    });
  });
});

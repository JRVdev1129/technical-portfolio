import disappearingElementsPage from "../../page-objects/internet/disappearingElements.page";

describe("Scenario: internet heroku", function () {
  describe("Feature: disappearing Elements", function () {
    beforeEach(function () {
      disappearingElementsPage.navigate();
      disappearingElementsPage.clickDisappearingElementsLink();
    });

    context("Given: user navigates to the internet heroku page", function () {
      context("When: user clicks disappearing Elements link", function () {
        it("Then: User should be redirected to disappearing Elements page", function () {
          it("Then: User should be redirected to contextMenu page", function () {
            cy.location().should((location) => {
              expect(location.href).to.eq(
                "https://the-internet.herokuapp.com/disappearing_elements"
              );
            });
          });
        });

        it("Then: page should have 5 elements displayed", function () {
          disappearingElementsPage.verifyElementNumber();
        });
      });
    });
  });
});

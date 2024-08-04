import abTestingPage from "../../page-objects/internet/abTesting.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: ab Testing", function () {
    beforeEach(function () {
      abTestingPage.visit();
    });

    describe("Given: user navigates to the internet heroku page", function () {
      describe("When: user clicks ab testing link", function () {
        it("Then: User should be redirected to ab testing page", function () {
          abTestingPage.clickABTestingLink();
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/abtest"
            );
          });
        });

        it("Then: ab testing description should be displayed", function () {
          abTestingPage.clickABTestingLink();
          abTestingPage.verifyAbTestingDescription();
        });
      });
    });
  });
});

import brokenImagesPage from "../../page-objects/internet/brokenImages.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: Auth", function () {
    beforeEach(function () {
      brokenImagesPage.navigate();

      brokenImagesPage.clickAuthLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks Broken Images link", function () {
        it("Then: User should be redirected to Broken Images page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/broken_images"
            );
          });
        });
      });

      context("When: Navigates to Auth Page", function () {
        it("Then: Authentication successful text should be displayed", function () {
          brokenImagesPage.validateImages();
        });
      });
    });
  });
});

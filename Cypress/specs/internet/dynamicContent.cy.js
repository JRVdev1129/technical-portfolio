import dynamicContentPage from "../../page-objects/internet/dynamicContent.page.js";
import { expect as mochaExpect } from "chai";

describe("Scenario: internet heroku", function () {
  describe("Feature: dynamicContent", function () {
    beforeEach(function () {
      dynamicContentPage.navigate();
      dynamicContentPage.clickDynamicContentLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks dynamic content link", function () {
        it("Then: User should be redirected to dynamic content page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/dynamic_content"
            );
          });
        });
      });

      context("When: User refreshes the dynamic content page", function () {
        it("Then: At least one Element should change", function () {
          dynamicContentPage.getAllImagesSource();
          const previousImageSources = dynamicContentPage.getAllImagesSource();
          cy.reload(true);
          const currentImageSources = dynamicContentPage.getAllImagesSource();

          mochaExpect(previousImageSources).to.not.equal(currentImageSources);
        });
      });
    });
  });
});

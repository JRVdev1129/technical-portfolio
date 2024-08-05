import dragAndDropPage from "../../page-objects/internet/dragAndDrop.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: dragAndDrop", function () {
    beforeEach(function () {
      dragAndDropPage.navigate();
      dragAndDropPage.clickDragAndDropLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks drag and drop link", function () {
        it("Then: User should be redirected to drag and drop page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/drag_and_drop"
            );
          });
        });
      });

      context("When: User drags and drops col A to col B", function () {
        it("Then: columns should change spaces", function () {
          dragAndDropPage.dragAndDrop();
          dragAndDropPage.validateDrop();
        });
      });
    });
  });
});

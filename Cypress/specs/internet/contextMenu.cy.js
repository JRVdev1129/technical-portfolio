import contextMenuPage from "../../page-objects/internet/contextMenu.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: contextMenu", function () {
    beforeEach(function () {
      contextMenuPage.navigate();
      contextMenuPage.clickContextMenuLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks contextMenu link", function () {
        it("Then: User should be redirected to contextMenu page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/context_menu"
            );
          });
        });
      });

      context("When: User right clicks the box", function () {
        it("Then: A js alert should display", function () {
          contextMenuPage.rightClickContextMenu();
          cy.on("window:alert", (str) => {
            expect(str).to.equal(`You selected a context menu`);
          });
        });
      });
    });
  });
});

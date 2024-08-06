import authPage from "../../page-objects/internet/auth.page.js";

describe("Scenario: internet heroku", function () {
  describe("Feature: Auth", function () {
    beforeEach(function () {
      authPage.navigate();
      const username = "admin";
      const password = "admin";

      const token = Buffer.from(`${username}:${password}`).toString("base64");

      cy.intercept("**/basic_auth", (req) => {
        req.headers["authorization"] = `Basic ${token}`;
      });
      authPage.clickAuthLink();
    });

    context("Given: User navigates to the internet heroku page", function () {
      context("When: User clicks Auth link", function () {
        it("Then: User should be redirected to Auth page", function () {
          cy.location().should((location) => {
            expect(location.href).to.eq(
              "https://the-internet.herokuapp.com/basic_auth"
            );
          });
        });
      });

      context("When: Navigates to Auth Page", function () {
        it("Then: Authentication successful text should be displayed", function () {
          cy.get("#content p").should(
            "contain.text",
            "Congratulations! You must have the proper credentials"
          );
        });
      });
    });
  });
});

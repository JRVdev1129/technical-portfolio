const abTestingPage = require("../../../page-objects/internet/abTesting.page.js");
const { expect } = require("chai");
describe("Scenario: internet heroku", function () {
  describe("Feature: ab Testing", function () {
    beforeEach(async function () {
      await abTestingPage.open();
      await abTestingPage.clickABTestingLink();
      await abTestingPage.waitForParagraph();
    });

    describe("Given: user navigates to the internet heroku page", function () {
      describe("When: user clicks ab testing link", function () {
        it("Then: User should be redirected to ab testing page", async function () {
          await expect(await abTestingPage.getUrl()).to.equal(
            "https://the-internet.herokuapp.com/abtest"
          );
        });

        it("Then: ab testing description should be displayed", async function () {
          const description = await abTestingPage.getParagraph();
          await expect(description).to.include(
            "Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through)."
          );
        });
      });
    });

    after(async function () {
      await abTestingPage.closeBrowser();
    });
  });
});

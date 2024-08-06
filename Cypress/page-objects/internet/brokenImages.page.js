class BrokenImagesPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickAuthLink() {
    return cy.get("#content  ul li:nth-child(4) a").click();
  }

  validateImages() {
    cy.get("img").each(($img) => {
      const src = $img.attr("src");

      cy.request({
        url: src,
        failOnStatusCode: false, // Don't fail the test on non-200 status codes
      }).then((response) => {
        expect(
          response.status,
          `Image at ${src} returned status ${response.status}`
        ).to.eq(200);
      });
    });
  }
}

export default new BrokenImagesPage();

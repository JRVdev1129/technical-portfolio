class ABTestingPage {
  visit() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickABTestingLink() {
    return cy.get("#content  ul li:nth-child(1) a").click();
  }

  verifyAbTestingDescription() {
    return cy
      .get(".example p")
      .first()
      .should(
        "include.text",
        "Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through)."
      );
  }
}

export default new ABTestingPage();

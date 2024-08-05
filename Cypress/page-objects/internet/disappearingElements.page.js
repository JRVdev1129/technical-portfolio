class ContextMenuPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickDisappearingElementsLink() {
    return cy.get("#content  ul li:nth-child(9) a").click();
  }

  verifyElementNumber() {
    return cy.get(".example li").should("have.length", 5);
  }
}

export default new ContextMenuPage();

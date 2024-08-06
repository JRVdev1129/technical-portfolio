class DynamicControlPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickDynamicControlLink() {
    return cy.get("#content  ul li:nth-child(13) a").click();
  }

  clickRemoveAddButton() {
    return cy.get("#checkbox-example > button").click();
  }

  validateElementRemoved() {
    cy.get("#checkbox input").should("not.exist");
  }

  waitForLoadingText() {
    cy.get("#loading").should("be.visible");
    cy.get("#loading", { timeout: 10000 }).should("be.visible");
  }
}

export default new DynamicControlPage();

class AddRemovePage {
  visit() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickAddRemoveLink() {
    return cy.get("#content  ul li:nth-child(2) a").click();
  }

  clickAddElementButton() {
    return cy.get("div.example > button").click();
  }

  verifyDeleteButton() {
    return cy.get("#elements .added-manually").should("exist");
  }

  clickDeleteElementButton() {
    return cy.get("#elements .added-manually").click();
  }

  verifyDeleteElementButtonNotDisplayed() {
    return cy.get("#elements .added-manually").should("not.exist");
  }
}

export default new AddRemovePage();

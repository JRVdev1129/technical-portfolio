class CheckboxesPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickCheckboxesLink() {
    return cy.get("#content  ul li:nth-child(6) a").click();
  }

  clickCheckbox() {
    return cy.get("#checkboxes input:first-child").check();
  }

  verifyCheckboxEnable() {
    return cy.get("#checkboxes input:first-child").should("be.enabled");
  }
}

export default new CheckboxesPage();

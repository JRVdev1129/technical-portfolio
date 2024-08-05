class DropDownPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickDropDownLink() {
    return cy.get("#content  ul li:nth-child(11) a").click();
  }

  selectValue() {
    return cy.get("select#dropdown").select("Option 1");
  }

  validateValue() {
    cy.get("select#dropdown").should("have.value", "1");
  }
}

export default new DropDownPage();

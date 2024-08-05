class ContextMenuPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickContextMenuLink() {
    return cy.get("#content  ul li:nth-child(7) a").click();
  }

  rightClickContextMenu() {
    return cy.get("#hot-spot").rightclick();
  }

  verifyCheckboxEnable() {
    return cy.get("#checkboxes input:first-child").should("be.enabled");
  }
}

export default new ContextMenuPage();

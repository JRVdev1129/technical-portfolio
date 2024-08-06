class DynamicContentPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickDynamicContentLink() {
    return cy.get("#content  ul li:nth-child(12) a").click();
  }

  selectValue() {
    return cy.get("select#dropdown").select("Option 1");
  }

  validateValue() {
    cy.get("select#dropdown").should("have.value", "1");
  }
  getAllImagesSource() {
    let imageSrcList = [];
    cy.get("#content #content .row img").each(($el) => {
      imageSrcList.push($el.attr("src"));
    });

    return imageSrcList;
  }
}

export default new DynamicContentPage();

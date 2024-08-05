import "@4tw/cypress-drag-drop";

class DragAndDropPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickDragAndDropLink() {
    return cy.get("#content  ul li:nth-child(10) a").click();
  }

  dragAndDrop() {
    const dataTransfer = new DataTransfer();

    cy.contains("A").trigger("dragstart", { dataTransfer });
    cy.contains("B").trigger("drop", { dataTransfer });

    // cy.get("#column-a").move({ deltaX: 500, deltaY: 100 });
    // drag("#column-b", {
    //   source: { x: 500, y: 0 }, // applies to the element being dragged
    //   target: { position: "left" }, // applies to the drop target
    //   force: true, // applied to both the source and target element
    // });
  }

  validateDrop() {
    cy.get("#column-a header").should("contain.text", "B");
  }
}

export default new DragAndDropPage();

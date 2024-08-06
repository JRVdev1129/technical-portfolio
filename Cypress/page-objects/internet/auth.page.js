class AuthPage {
  navigate() {
    cy.visit("https://the-internet.herokuapp.com/");
  }

  clickAuthLink() {
    return cy.get("#content  ul li:nth-child(3) a").click();
  }

  authenticate() {
    //   cy.request({
    //     method: "GET",
    //     url: "https://the-internet.herokuapp.com/basic_auth",
    //     auth: {
    //       username: username,
    //       password: password,
    //     },
    //   }).then((response) => {
    //     // Your code to handle the response
    //   });
  }
}

export default new AuthPage();

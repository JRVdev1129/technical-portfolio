const { Key } = require("selenium-webdriver");
var BasePage = require("./basepage.js");

class HomePage extends BasePage {
  async open() {
    await this.go_to_url("https://the-internet.herokuapp.com/");
  }

  async clickABTestingLink() {
    await this.clickSelector("#content  ul li:nth-child(1) a");
  }

  async waitForParagraph() {
    await this.waitForElementsByCss(".example p", 10000);
  }

  async getParagraph() {
    const searchField = ".example p";
    return await this.text(searchField);
  }
}
module.exports = new HomePage();

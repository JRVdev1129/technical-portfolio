const { Key } = require("selenium-webdriver");
var BasePage = require("./basepage.js");

class AddRemovePage extends BasePage {
  async open() {
    await this.go_to_url("https://the-internet.herokuapp.com/");
  }

  async clickAddRemoveLink() {
    await this.waitForElementsByCss("#content  ul li:nth-child(2) a", 10000);
    await this.clickSelector("#content  ul li:nth-child(2) a");
  }

  async clickAddElementButton() {
    await this.waitForElementsByCss("div.example > button", 10000);
    await this.clickSelector("div.example > button");
  }

  verifyDeleteButton() {
    return this.isVisible("#elements .added-manually", 500);
  }

  async clickDeleteElementButton() {
    await this.clickSelector("#elements .added-manually");
  }
}
module.exports = new AddRemovePage();

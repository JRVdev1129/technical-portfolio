var webdriver = require("selenium-webdriver");
const { By, until } = require("selenium-webdriver");
var driver = new webdriver.Builder().forBrowser("chrome").build();
driver.manage().setTimeouts({ implicit: 10000 });

class BasePage {
  constructor() {
    global.driver = driver;
  }
  async go_to_url(theURL) {
    await driver.get(theURL);
  }
  async enterTextByCss(css, searchText) {
    await driver.findElement(By.css(css)).sendKeys(searchText);
  }
  async clickById(id) {
    await driver.findElement(By.id(id)).click();
  }

  async clickSelector(css) {
    await driver.findElement(By.css(css)).click();
  }

  async text(css) {
    return await driver.findElement(By.css(css)).getText();
  }

  async getUrl() {
    return await driver.getCurrentUrl();
  }

  async waitForElementsByCss(css, waitTimeout = 10000) {
    await driver.wait(
      until.elementIsVisible(driver.findElement(By.css(css))),
      waitTimeout
    );
  }

  async closeBrowser() {
    await driver.quit();
  }
}

module.exports = BasePage;

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class ProductsPage
    {


        private IWebDriver driver;

        // By locators for card title and add to cart button
        private By cardTitle = By.CssSelector(".card-title a");
        private By addToCart = By.CssSelector(".card-footer button");

        // Private IWebElement lists and single elements
        private IList<IWebElement> cards;
        private IWebElement checkoutButton;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;

            // Initialize elements manually using FindElements for the list and FindElement for the button
            cards = driver.FindElements(By.TagName("app-card"));
            checkoutButton = driver.FindElement(By.PartialLinkText("Checkout"));
        }

        // [FindsBy(How = How.TagName, Using = "app-card")]
        // private IList<IWebElement> cards;

        // [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        // private IWebElement checkoutButton;


        public void waitForPageDisplay()

        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {

            return cards;
        }

        public By getCardTitle()
        {

            return cardTitle;
        }

        public CheckoutPage checkout()
        {

            checkoutButton.Click();
            return new CheckoutPage(driver);
        }

        public By addToCartButton()
        {

            return addToCart;
        }


    }
}

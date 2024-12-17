using System;
using System.Collections.Generic;
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class CheckoutPage
    {

        private IWebDriver driver;

        // Declare IWebElement variables
        private IList<IWebElement> checkoutCards;
        private IWebElement checkoutButton;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;

            // Initialize elements manually using FindElements for the list and FindElement for the button
            checkoutCards = driver.FindElements(By.CssSelector("h4 a"));
            checkoutButton = driver.FindElement(By.CssSelector(".btn-success"));
        }

        //By.CssSelector(".btn-success")
        // [FindsBy(How = How.CssSelector, Using = "h4 a")]
        // private IList<IWebElement> checkoutCards;

        // [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        // private IWebElement checkoutButton;


        public IList<IWebElement> getCards()

        {

            return checkoutCards;
        }

        public void checkOut()
        {
            checkoutButton.Click();
            //object of next page


        }
    }
}

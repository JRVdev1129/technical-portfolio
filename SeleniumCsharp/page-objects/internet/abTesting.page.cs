using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class ABTestingPage
    {
        //driver.FindElement(By.Id("username"))
        //By.Id("username")

        //driver.FindElement(By.Name("password")).SendKeys("learning");
        //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
        IWebDriver driver;


        public ABTestingPage(IWebDriver driver)
        {
            this.driver = driver;



        }




        // public ProductsPage validLogin(string user, string pass)

        // {
        //     username.SendKeys(user);
        //     password.SendKeys(pass);
        //     checkBox.Click();
        //     signInButton.Click();
        //     return new ProductsPage(driver);





        // }




        public IWebElement getABTestingLink()

        {
            return driver.FindElement(By.CssSelector("#content  ul li:nth-child(1) a" ));
        }

        public IWebElement getABTestingDescription()

        {
            return driver.FindElement(By.CssSelector(".example p"));;
        }

        public string getTextDescription()
        {
            return getABTestingDescription().Text;
        }




























    }
}

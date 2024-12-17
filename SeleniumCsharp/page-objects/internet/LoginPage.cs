using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class LoginPage
    {
        //driver.FindElement(By.Id("username"))
        //By.Id("username")

        //driver.FindElement(By.Name("password")).SendKeys("learning");
        //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
        private IWebDriver driver;

        // Declare IWebElement variables
        private IWebElement username;
        private IWebElement password;
        private IWebElement checkBox;
        private IWebElement signInButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            // Initialize the elements manually using FindElement
            username = driver.FindElement(By.Id("username"));
            password = driver.FindElement(By.Name("password"));
            checkBox = driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input"));
            signInButton = driver.FindElement(By.CssSelector("input[value='Sign In']"));
        }


        //Pageobject factory

        // [FindsBy(How = How.Id, Using = "username")]
        // public required IWebElement username;

        // [FindsBy(How = How.Name, Using = "password")]
        // public required IWebElement password;

        // [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        // public required IWebElement checkBox;

        // [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        // public required IWebElement signInButton;



        public ProductsPage validLogin(string user, string pass)

        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
            return new ProductsPage(driver);





        }




        public IWebElement getUserName()

        {
            return username;
        }

























    }
}

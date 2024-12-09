using OpenQA.Selenium;

namespace SeleniumCSharp.PageObjects
{
    public class GoogleHomePage
    {
        private readonly IWebDriver _driver;

        // Constructor
        public GoogleHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Define the search box element
        private IWebElement SearchBox => _driver.FindElement(By.Name("q"));

        // Define the search button element
        private IWebElement SearchButton => _driver.FindElement(By.Name("btnK"));

        // Method to perform a search
        public void Search(string query)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(query);
            SearchBox.SendKeys(Keys.Enter);
        }
    }
}

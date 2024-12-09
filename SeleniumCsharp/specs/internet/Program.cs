
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using SeleniumCSharp.PageObjects;

namespace SeleniumCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Chrome options to run headless with necessary flags for Docker
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Run Chrome in headless mode
            options.AddArgument("--no-sandbox"); // Bypass OS security model
            options.AddArgument("--disable-dev-shm-usage"); // Overcome limited resource problems
            options.AddArgument("--disable-gpu"); // Applicable to Docker environment, even if GPU is not available
            options.AddArgument("--window-size=1920,1080");
            // Set screen size (optional)
            // Bind to 0.0.0.0 for Docker compatibility
            // options.AddArgument("--remote-debugging-address=0.0.0.0");
            options.AddArgument("--remote-debugging-port=9222");
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--log-level=ALL"); // Set Chrome's log level to all
            options.AddArgument("--verbose"); // Enable verbose logging



            // Initialize the ChromeDriver
            using IWebDriver driver = new ChromeDriver(options);

            // Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Page Title: " + driver.Title);


            // Initialize the GoogleHomePage object
            var googleHomePage = new GoogleHomePage(driver);

            // Perform a search using the page object
            googleHomePage.Search("Selenium WebDriver");

            // Close the browser after some delay
            System.Threading.Thread.Sleep(5000);
            driver.Quit();
        }
    }
}



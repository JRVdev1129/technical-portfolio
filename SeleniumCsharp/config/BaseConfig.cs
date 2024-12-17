

using System;
using System.Configuration;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.utilities
{
    public class Base
    {
        public required ExtentReports extent;
        public required ExtentTest test;
        string? browserName;
        //report file
        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string? projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;

            if (projectDirectory == null)
            {
                throw new InvalidOperationException("Unable to determine the project directory.");
            }
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Jakoc");

        }


        // public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]

        public void StartBrowser()

        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Configuration
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {

                browserName = ConfigurationManager.AppSettings["browser"];
            }
            browserName ??= "Chrome";
            InitBrowser(browserName);



            driver.Value!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";


        }

        public IWebDriver getDriver()

        {

            if (driver.Value == null)
            {
                throw new InvalidOperationException("WebDriver has not been initialized.");
            }
            return driver.Value;
        }


        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;


                case "Edge":

                    driver.Value = new EdgeDriver();
                    break;

            }


        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver.Value!;
                var screenshot = ts.GetScreenshot().AsBase64EncodedString;

                test.Fail("Test failed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, fileName).Build());
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();
            driver.Value!.Quit();
        }

        // public MediaEntityModelProvider captureScreenShot(IWebDriver driver,String screenShotName)

        // {
        //     ITakesScreenshot ts= (ITakesScreenshot)driver;
        //    var screenshot= ts.GetScreenshot().AsBase64EncodedString;

        //    return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();




        // }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSelFramework.pageObjects;
using CSharpSelFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    [Parallelizable(ParallelScope.Self)]
    [Category("Feature: AB Testing Page")]
    public class ABTesting : Base
    {

        [Test, Description("This test validates the addition of two numbers."), Category("test")]
        //[TestCase("rahulshettyacademy", "learning")]
        //[TestCase("rahulshetty", "learning")]

        // run all data sets of Test method in parallel  - Done
        // run all test methods in one class parallel   - Done
        // run all test files in project parallel   - Done

        //dotnet test pathto.csproj ( ALl tests)
        //dotnet test pathto.csproj --filter TestCategory=Smoke

        // dotnet test CSharpSelFramework.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter\(name=\"browserName\",value=\"Chrome\"\)

        [Parallelizable(ParallelScope.Self)]
        public void ABTestingDescription( )

        {
            // Create the ExtentTest entry for this test
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name, "Validating A/B Testing page description");

            // Log additional information in the ExtentReport
            test.Info("Starting test to validate the description on the A/B Testing page.");

            String expectedDescription = "Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).";
            ABTestingPage abTestingPage = new ABTestingPage(getDriver());
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("A/B Testing")));

            abTestingPage.getABTestingLink().Click();
            string description =  abTestingPage.getABTestingDescription().Text;
            Assert.That(expectedDescription,Is.EqualTo(description));


           





        }



        // [Test,Category("Smoke")]
        // public void LocatorsIdentification()

        // {

        //     driver.Value.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
        //     driver.Value.FindElement(By.Id("username")).Clear();
        //     driver.Value.FindElement(By.Id("username")).SendKeys("rahulshetty");
        //     driver.Value.FindElement(By.Name("password")).SendKeys("123456");
        //     //css selector & xpath
        //     //  tagname[attribute ='value']
        //     //    #id  #terms  - class name -> css .classname
        //     //    driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();

        //     //    //tagName[@attribute = 'value']

        //     // CSS - .text-info span:nth-child(1) input
        //     //xpath - //label[@class='text-info']/span/input

        //     driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

        //     driver.Value.FindElement(By.XPath("//input[@value='Sign In']")).Click();

        //     WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
        //     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
        //    .TextToBePresentInElementValue(driver.Value.FindElement(By.Id("signInBtn")), "Sign In"));

        //     String errorMessage = driver.Value.FindElement(By.ClassName("alert-danger")).Text;
        //     TestContext.Progress.WriteLine(errorMessage);


        // }




        // public static IEnumerable<TestCaseData> AddTestDataConfig()

        // {

        //   yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
        //     yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractDataArray("products"));
        //     yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"), getDataParser().extractDataArray("products"));
        // }
    }

}


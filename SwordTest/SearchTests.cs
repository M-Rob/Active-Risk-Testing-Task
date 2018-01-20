using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Linq;

namespace UnitTestActiveRisk
{
    [TestClass]
    public class MyTest
    {
        IWebDriver driverFF;

        
        /// <summary>
        /// this test will search for the term Snappit via the search in the top right hand side
        /// it will then search for the first appropriate link on the page and make sure the page from
        /// that link will succesfully load.
        /// </summary>
        

        [TestMethod]
        public void CheckThatSearchReturnsLinkToSnappit()
        {
            var element = driverFF.FindElement(By.Id("s"));

            element.SendKeys("snappit");

            var elementid = driverFF.FindElement(By.Id("searchsubmit"));

            elementid.Click();

            var anchors = driverFF.FindElements(By.TagName("a"));

            var readMoreAnchor = anchors.FirstOrDefault(a => a.GetAttribute("href") == "http://www.sword-activerisk.com/products/active-risk-manager-arm/arm-snappit/"
                && a.Displayed == true); // Check that its displayed as there are other links to the same page that are hidden.

            Assert.IsNotNull(readMoreAnchor);

            readMoreAnchor.Click();

            string title = driverFF.Title;

            Assert.AreEqual("ARM SNAPPit", title);

        }

        [TestInitialize]
        public void TestMethod1()
        {
            driverFF = new FirefoxDriver();
            driverFF.Navigate().GoToUrl("http://www.sword-activerisk.com/");
        }


        [TestCleanup]
        public void TestCleanUp()
        {
            driverFF.Quit();
        }
    }
}

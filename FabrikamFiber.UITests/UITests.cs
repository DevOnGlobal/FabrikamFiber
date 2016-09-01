using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace FabrikamFiber.UITests
{
    [TestClass]
    public class UITests
    {
        public TestContext TestContext
        {
            get; set;
        }

        [TestMethod]
        public void TestHomepage()
        {
            IWebDriver driver;
            if (!string.IsNullOrEmpty(TestContext.Properties["SELENIUM_GRID_URL"] as string)) {
                driver = new OpenQA.Selenium.Remote.RemoteWebDriver(new Uri(TestContext.Properties["SELENIUM_GRID_URL"] as string), DesiredCapabilities.Chrome());
            } else
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            }

            try { 
                driver.Navigate().GoToUrl(TestContext.Properties["APP_URL"] as string);
                Assert.IsTrue(driver.PageSource.Contains("Dashboard"));
            } finally { 
                driver.Quit();
            }
        }
    }
}

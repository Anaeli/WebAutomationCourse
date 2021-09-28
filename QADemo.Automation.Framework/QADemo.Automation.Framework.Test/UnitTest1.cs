using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace QADemo.Automation.Framework.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "HellowWorld")]
        [Trait("Category", "Smoke")]
        public void HellowWorldExample()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string appURL = "https://www.google.com/ncr";
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl(appURL);
                driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
                wait.Until(webDriver => webDriver.FindElement(By.Id("rso")).Displayed);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
                Assert.Equal("cheese - Google Search", driver.Title);
            }
        }

        [Fact(DisplayName = "MapElements")]
        [Trait("Category", "Smoke")]
        public void MapElementsFromDemoQA()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                string appURL = "https://demoqa.com/text-box";
                IWebElement FullNameTextBox;
                IWebElement EmailTextBox;
                driver.Navigate().GoToUrl(appURL);
                FullNameTextBox = driver.FindElement(By.Id("userName"));
                EmailTextBox = driver.FindElement(By.Id("userEmail"));
            }
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace DemoQA.Automation.Framework.Wrappers
{
    class MCTextBoxWrapper
    {
        private IWebDriver driver;

        public MCTextBoxWrapper()
        {
            driver = new ChromeDriver();
        }

        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public void GoToPage()
        {
            string appURL = "https://demoqa.com/text-box";
            driver.Navigate().GoToUrl(appURL);
        }
    }
}

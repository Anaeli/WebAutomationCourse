using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoQA.Automation.Framework.Wrappers.Students
{
    public class JMPFPracticeTextBoxWrapper
    {
        private IWebDriver driver;

        public JMPFPracticeTextBoxWrapper()
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

        public void QuitDriver()
        {
            Console.Write("Quiting current driver...");
            driver.Quit();
            driver.Dispose();
            driver = null;
        }
    }
}

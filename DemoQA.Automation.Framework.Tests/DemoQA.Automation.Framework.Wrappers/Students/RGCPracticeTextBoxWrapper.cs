using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;

namespace DemoQA.Automation.Framework.Wrappers.Students
{
    public class RGCPracticeTextBoxWrapper
    {

        //private IWebDriver driver;
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public RGCPracticeTextBoxWrapper()
        {
            //driver = new ChromeDriver();
        }

        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EMailTextBox => driver.FindElement(By.Id("userEmail"));

        public IWebElement CurrentAddressTextBox => driver.FindElement(By.Id("currentAddress"));

        public IWebElement PermanentAddressTextBox => driver.FindElement(By.Id("permanentAddress"));

        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        public IWebElement OutputFullName => driver.FindElement(By.Id("name"));

        public IWebElement OutputEmail => driver.FindElement(By.Id("email"));

        public IWebElement OutputCurrentAddress => driver.FindElement(By.CssSelector("p[id='currentAddress']"));

        public IWebElement OutputPermanentAddress => driver.FindElement(By.CssSelector("p[id='permanentAddress']"));

        public IWebElement adsElement => driver.FindElement(By.Id("close-fixedban"));


        public void GoToPage()
        {
            string appURL = "https://demoqa.com/text-box";
            driver.Navigate().GoToUrl(appURL);
        }
    }
}

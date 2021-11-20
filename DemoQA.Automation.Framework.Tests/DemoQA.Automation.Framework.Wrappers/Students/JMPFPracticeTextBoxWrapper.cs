namespace DemoQA.Automation.Framework.Wrappers.Students
{
    using DemoQA.Automation.Core.Wrappers;
    using DemoQA.Automation.Core.Wrappers.Components;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;
    using System;

    public class JMPFPracticeTextBoxWrapper 
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public IWebElement AddressTextBox => driver.FindElement(By.Id("currentAddress"));

        public IWebElement PermanentAddressTextBox => driver.FindElement(By.Id("permanentAddress"));

        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        public IWebElement OutputCurrentAddress => driver.FindElement(By.CssSelector("p[id='currentAddress']"));

        public IWebElement OutputPermanentAddress => driver.FindElement(By.CssSelector("p[id='permanentAddress']"));

        public IWebElement EmailLabelTextBox => driver.FindElement(By.CssSelector(".field-error"));

    }
}

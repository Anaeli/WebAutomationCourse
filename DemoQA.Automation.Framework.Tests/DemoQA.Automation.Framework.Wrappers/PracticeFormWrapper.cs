using DemoQA.Automation.Core.Wrappers;
using DemoQA.Automation.Core.Wrappers.Components;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace DemoQA.Automation.Framework.Wrappers
{
    public class PracticeFormWrapper : ContentScreenWrapper
    {
        private IWebDriver driver = AutomationClient.Instance.Driver;

        protected PracticeFormWrapper(IWebElement container, AutomationClient client) : base(container, client)
        {
            this.NameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("firstName");
        }

        public TextBoxComponentWrapper NameTextBox { get; set; }

      

        public IWebElement LastNameTextBox => driver.FindElement(By.Id("lastName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));
        public IWebElement FemaleRadioButton => driver.FindElement(By.Id("gender-radio-2"));
        public IWebElement OtherGenderRadioButton => driver.FindElement(By.Id("gender-radio-3"));

        public IWebElement MobileNumberTextBox => driver.FindElement(By.Id("userNumber"));

        public IWebElement StateTextBox => driver.FindElement(By.Id("state"));

        public IWebElement CityTextBox => driver.FindElement(By.Id("city"));

        public ButtonComponentWrapper SubmitButton => this.WaitForWrapper<ButtonComponentWrapper>("submit");




        public void SelectGender(string gender)
        {
            if(gender == "Male")
            {
                PerformAction(MaleRadioButton, driver);
            }else if(gender == "Female")
            {
                PerformAction(FemaleRadioButton, driver);
            }
            else
            {
                PerformAction(OtherGenderRadioButton, driver);
            }
        }

        public void SelectState(string state)
        {
            StateTextBox.Click();
            driver.FindElement(By.XPath($"//div[text()='{state}']")).Click();
        }
        public void SelectCity(string city)
        {
            CityTextBox.Click();
            driver.FindElement(By.XPath($"//div[text()='{city}']")).Click();
        }

        public void GoToPage()
        {
            string appURL = "https://demoqa.com/automation-practice-form";
            driver.Navigate().GoToUrl(appURL);
        }

        public void PerformAction(IWebElement element, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.Click(element);
            builder.Build().Perform();
        }

        public void ClickUsingJS(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public void QuitDriver()
        {
            try
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                driver?.Close();
            }
            catch (WebDriverException e)
            {
                Console.WriteLine("Error closing the driver: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Quiting current driver...");
                driver?.Quit();
                driver?.Dispose();
                driver = null;
            }
        }
    }
}
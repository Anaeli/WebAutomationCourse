using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace DemoQA.Automation.Framework.Wrappers
{
    public class PracticeFormWrapper
    {
        private IWebDriver driver = AutomationClient.Instance.Driver;

        public PracticeFormWrapper()
        {
           
        }

        public IWebElement NameTextBox => driver.FindElement(By.Id("firstName"));

        public IWebElement LastNameTextBox => driver.FindElement(By.Id("lastName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));

        public IWebElement MaleLabelRadioButton => driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
        public IWebElement FemaleRadioButton => driver.FindElement(By.Id("gender-radio-2"));

        public IWebElement OtherRadioButton => driver.FindElement(By.Id("gender-radio-3"));

        public IWebElement MobileNumberTextBox => driver.FindElement(By.Id("userNumber"));

        public IWebElement DateOfBirth => driver.FindElement(By.Id("dateOfBirthInput"));

        public IWebElement ChooseFileButton => driver.FindElement(By.Id("uploadPicture"));       

        public IWebElement StateDropDown => driver.FindElement(By.Id("state"));

        public IWebElement NCRStateDropDown => driver.FindElement(By.Id("react-select-3-option-0"));
        public IWebElement UttarPradeshStateDropDown => driver.FindElement(By.Id("react-select-3-option-1"));

        public IWebElement CityDropDown => driver.FindElement(By.Id("city"));

        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        private void SelectStateByName(string state)
        {
            switch (state.ToLower())
            {
                case "ncr":
                    PerformAction(NCRStateDropDown, driver);
                    break;
                case "uttar pradesh":
                    PerformAction(UttarPradeshStateDropDown, driver);
                    break;
            }
        }


        public void SelectChooseFile()
        {
            PerformAction(ChooseFileButton, driver);
        }

        public void SelectGenderRadioButton(string gender)
        {
            switch (gender.ToLower())
            {
                case "female":
                    PerformAction(FemaleRadioButton, driver);
                    break;
                case "male":
                    PerformAction(MaleRadioButton, driver);
                    break;
                case "Other":
                    PerformAction(OtherRadioButton, driver);
                    break;
            }
        }


        public void SelectState(string state)
        {
            AutomationClient.Instance.ScrollIntoView(StateDropDown);
            PerformAction(StateDropDown, driver);
            SelectStateByName(state);

        }


        public void ClickSubmitButton()
        {
            AutomationClient.Instance.ScrollIntoView(SubmitButton);
            // PerformAction(SubmitButton, driver);
            ClickUsingJS(SubmitButton);
        }

        public void ClickUsingJS(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public void SelectCity(string city)
        {
            CityDropDown.Click();
            driver.FindElement(By.XPath($"//div[text()='{city}']")).Click();
        }

        public void FillDateOfBirth(string date)
        {
            DateOfBirth.SendKeys(Keys.Control + "a");
            DateOfBirth.SendKeys(date);
            DateOfBirth.SendKeys(Keys.Enter);
        }

        public void PerformAction(IWebElement element, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.Click(element);
            builder.Build().Perform(); 
        }       
    }
}

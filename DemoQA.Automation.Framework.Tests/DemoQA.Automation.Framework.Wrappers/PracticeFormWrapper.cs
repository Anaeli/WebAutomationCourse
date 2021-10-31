namespace DemoQA.Automation.Framework.Wrappers
{
    using DemoQA.Automation.Core.Wrappers;
    using DemoQA.Automation.Core.Wrappers.Components;
    using DemoQA.Automation.Core.Wrappers.Components.Button;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class PracticeFormWrapper : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        protected PracticeFormWrapper(IWebElement container, AutomationClient client)
            : base(container, client)
        {
            this.NameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("firstName");
        }

        public TextBoxComponentWrapper NameTextBox { get; set; }
        //public TextBoxComponentWrapper NameTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("firstName");

        // public IWebElement NameTextBox => driver.FindElement(By.Id("firstName"));

        public TextBoxComponentWrapper LastNameTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("lastName");

        public TextBoxComponentWrapper EmailTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("userEmail");

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));

        public IWebElement MaleLabelRadioButton => driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
        public IWebElement FemaleRadioButton => driver.FindElement(By.Id("gender-radio-2"));

        public IWebElement OtherRadioButton => driver.FindElement(By.Id("gender-radio-3"));

        public TextBoxComponentWrapper MobileNumberTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("userNumber");

        public IWebElement DateOfBirth => driver.FindElement(By.Id("dateOfBirthInput"));

        public IWebElement ChooseFileButton => driver.FindElement(By.Id("uploadPicture"));       

        public IWebElement StateDropDown => driver.FindElement(By.Id("state"));

        public IWebElement NCRStateDropDown => driver.FindElement(By.Id("react-select-3-option-0"));
        public IWebElement UttarPradeshStateDropDown => driver.FindElement(By.Id("react-select-3-option-1"));

        public IWebElement CityDropDown => driver.FindElement(By.Id("city"));

        public ButtonComponentWrapper SubmitButton => this.WaitForWrapper<ButtonComponentWrapper>("submit");

        public IWebElement SubmitButton1 => driver.FindElement(By.Id("submit"));

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
            AutomationClient.Instance.ScrollIntoView(SubmitButton1);
            ClickUsingJS(SubmitButton1);
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

namespace DemoQA.Automation.Framework.Wrappers
{
    using DemoQA.Automation.Core.Wrappers;
    using DemoQA.Automation.Core.Wrappers.Components;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class HGRBookStoreWrapper : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        protected HGRBookStoreWrapper(IWebElement container, AutomationClient client)
            : base(container, client)
        {
            this.UserNameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("userName");
        }

        public TextBoxComponentWrapper UserNameTextBox { get; set; }

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));

        public TextBoxComponentWrapper PasswordTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("password");

        public ButtonComponentWrapper LoginButton => this.WaitForWrapper<ButtonComponentWrapper>("login");

        // public ButtonComponentWrapper ProfileMenu => this.WaitForWrapper<ButtonComponentWrapper>("//span[contains(.,'Profile')]");
        public IWebElement ProfileMenu => this.driver.FindElement(By.XPath("//span[contains(.,'Profile')]"));

        public ButtonComponentWrapper GotoStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("gotoStore");

        // public ButtonComponentWrapper GotoNewBookStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("addNewRecordButton");
        public IWebElement GitPocketBook => this.driver.FindElement(By.XPath("//a[contains(.,'Git Pocket Guide')]"));

        public IWebElement JsDesignBook => this.driver.FindElement(By.XPath("//a[contains(.,'Learning JavaScript Design Patterns')]"));

        public IWebElement WebApisBook => this.driver.FindElement(By.XPath("//a[contains(.,'Designing Evolvable Web APIs with ASP.NET')]"));

        // public ButtonComponentWrapper AddBookToCollectionButton => this.WaitForWrapper<ButtonComponentWrapper>("addNewRecordButton");
        public IWebElement AddBookToCollectionButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));

        public IWebElement GotoNewBookStoreButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));
    }
}
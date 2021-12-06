namespace DemoQA.Automation.Framework.Wrappers
{
    using DemoQA.Automation.Core.Wrappers;
    using DemoQA.Automation.Core.Wrappers.Components;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class MCBookStoreWrapper : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        protected MCBookStoreWrapper(IWebElement container, AutomationClient client)
            : base(container, client)
        {
            this.UserNameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("userName");
        }

        public TextBoxComponentWrapper UserNameTextBox { get; set; }

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));

        public IWebElement UserNameValue => driver.FindElement(By.Id("userName-value"));

        public TextBoxComponentWrapper PasswordTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("password");

        public ButtonComponentWrapper LoginButton => this.WaitForWrapper<ButtonComponentWrapper>("login");
        public ButtonComponentWrapper DeleteAccountButton => this.WaitForWrapper<ButtonComponentWrapper>("submit");
        public IWebElement DeleteAccountButtonX => this.driver.FindElement(By.XPath("//button[contains(.,'Delete Account')]"));

        public IWebElement DeleteAllBooksButtonX => this.driver.FindElement(By.XPath("//button[contains(.,'Delete All Books')]"));

        public IWebElement CloseSmallModalButton => this.driver.FindElement(By.Id("closeSmallModal-ok"));

        public IWebElement ProfileMenuButton => this.driver.FindElement(By.XPath("//span[contains(.,'Profile')]"));

        public ButtonComponentWrapper GoToBookStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("gotoStore");

        public IWebElement GoToBookStoreButtonX => this.driver.FindElement(By.XPath("//button[contains(.,'Go To Book Store')]"));

        public ButtonComponentWrapper BackToBookStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("addNewRecordButton");

        public IWebElement BackToBookStoreButtonX => this.driver.FindElement(By.XPath("//button[contains(.,'Back To Book Store')]"));

        public IWebElement GitPocketGuideBook => this.driver.FindElement(By.XPath("//a[contains(.,'Git Pocket Guide')]"));

        public IWebElement JavaScriptDesignPatternsBook => this.driver.FindElement(By.XPath("//a[contains(.,'Learning JavaScript Design Patterns')]"));

        public IWebElement DesigningEvolvableWebAPIsBook => this.driver.FindElement(By.XPath("//a[contains(.,'Designing Evolvable Web APIs with ASP.NET')]"));

        public IWebElement DeleteJavaScriptDesignBookButton => this.driver.FindElement(By.XPath("//span[@id='see-book-Learning JavaScript Design Patterns']//parent::div//parent::div//following-sibling::div[3]/div/span"));

        public IWebElement AddBookToCollectionButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));

        public IWebElement GotoNewBookStoreButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));

        public IWebElement NoRowsFoundTableText => this.driver.FindElement(By.XPath("//div[contains(text(), 'No rows found')]"));
    }
}


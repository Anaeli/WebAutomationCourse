namespace DemoQA.Automation.Framework.Wrappers
{
    using DemoQA.Automation.Core.Wrappers;
    using DemoQA.Automation.Core.Wrappers.Components;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class RGCBookStoreWrapper : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        protected RGCBookStoreWrapper(IWebElement container, AutomationClient client)
            : base(container, client)
        {
            this.UserNameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("userName");
        }

        public TextBoxComponentWrapper UserNameTextBox { get; set; }

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));

        public TextBoxComponentWrapper PasswordTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("password");

        public ButtonComponentWrapper LoginButton => this.WaitForWrapper<ButtonComponentWrapper>("login");

        public IWebElement LoginValidaton => this.driver.FindElement(By.Id("name"));

        public IWebElement ProfileButtonMenu => this.driver.FindElement(By.XPath("//span[contains(.,'Profile')]"));

        public ButtonComponentWrapper MenuGotoStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("gotoStore");

        public IWebElement GitPocketGuideBook => this.driver.FindElement(By.XPath("//a[contains(.,'Git Pocket Guide')]"));

        public IWebElement JsDesignBook => this.driver.FindElement(By.XPath("//a[contains(.,'Learning JavaScript Design Patterns')]"));

        public IWebElement WebApisBook => this.driver.FindElement(By.XPath("//a[contains(.,'Designing Evolvable Web APIs with ASP.NET')]"));

         public IWebElement AddBookToCollectionButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));
        
        public IWebElement GoToBookStoreButton => this.driver.FindElement(By.Id("gotoStore"));


        public IWebElement ProfileButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Profile')]"));

        public IWebElement DeleteAccountButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Delete Account')]"));

        public IWebElement DeleteAllBooksButton => this.driver.FindElement(By.XPath("//button[text()='Delete All Books']"));
        //public IWebElement DeleteAllBooksButton => this.driver.FindElement(By.Id("submit"));
        public IWebElement PageSize => this.driver.FindElement(By.XPath("//span[contains(.,'pageSizeOptions')]"));

        public IWebElement CloseSmallModal => this.driver.FindElement(By.Id("closeSmallModal-ok"));

        //public IWebElement NoRowsMessage => this.driver.FindElement(By.XPath("//div[text()='No rows found']"));
        //public IWebElement NoRowsMessage => this.driver.FindElement(By.XPath("//a[contains(.,'No rows found')]"));
        //public IWebElement NoRowsMessage => this.driver.FindElement(By.ClassName("rt-noData"));
        public IWebElement noRowsMessage => this.driver.FindElement(By.XPath("//div[contains(text(), 'No rows found')]"));

        public IWebElement backToStoreButton => this.driver.FindElement(By.Id("addNewRecordButton"));

        public IWebElement PageSizeDropDown => this.driver.FindElement(By.XPath("//select[@aria-label='rows per page']"));

        public IWebElement PageSizeRows => this.driver.FindElement(By.XPath("//option[@value='10']"));
        public IWebElement SearchField => this.driver.FindElement(By.Id("searchBox"));

        //public IWebElement AddBookToCollectionButton => this.driver.FindElement(By.Id("addNewRecordButton"));
        //public ButtonComponentWrapper AddBookToCollectionButton => this.WaitForWrapper<ButtonComponentWrapper>("addNewRecordButton");
        // public ButtonComponentWrapper GotoNewBookStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("addNewRecordButton");
        //public ButtonComponentWrapper ProfileMenu => this.WaitForWrapper<ButtonComponentWrapper>("//span[contains(.,'Profile')]");
        //public IWebElement GoToBookStoreButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));
    }
}

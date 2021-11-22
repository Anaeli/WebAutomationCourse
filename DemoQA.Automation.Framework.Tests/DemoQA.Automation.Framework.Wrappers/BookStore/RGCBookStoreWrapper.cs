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

        public IWebElement LoginTitle => this.driver.FindElement(By.ClassName("main-header"));

        public TextBoxComponentWrapper PasswordTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("password");

        public ButtonComponentWrapper LoginButton => this.WaitForWrapper<ButtonComponentWrapper>("login");

        public IWebElement ProfileMenu => this.driver.FindElement(By.XPath("//span[contains(.,'Profile')]"));

        public ButtonComponentWrapper GotoStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("gotoStore");

        public IWebElement GitPocketBook => this.driver.FindElement(By.XPath("//a[contains(.,'Git Pocket Guide')]"));

        public IWebElement JsDesignBook => this.driver.FindElement(By.XPath("//a[contains(.,'Learning JavaScript Design Patterns')]"));

        public IWebElement WebApisBook => this.driver.FindElement(By.XPath("//a[contains(.,'Designing Evolvable Web APIs with ASP.NET')]"));

        public IWebElement AddBookToCollectionButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));

        public IWebElement GotoNewBookStoreButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));
        
        public IWebElement GotoBookStoreButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Go To Book Store')]"));

        public IWebElement DeleteGitPocketGuideButton => this.driver.FindElement(By.XPath("//span[@id='see-book-Git Pocket Guide']//parent::div//parent::div//following-sibling::div[3]/div/span"));

        public IWebElement ModalButtonOK => this.driver.FindElement(By.Id("closeSmallModal-ok"));

        public IWebElement DeleteAllBooksButton => this.driver.FindElement(By.XPath("//button[text()='Delete All Books']"));

        public IWebElement NoBooks => this.driver.FindElement(By.XPath("//div[text()='No rows found']"));

        public IWebElement DeleteAccountButton => this.driver.FindElement(By.XPath("//button[text()='Delete Account']"));

        public IWebElement BookIsbnValue => this.driver.FindElement(By.XPath("//div[@id='ISBN-wrapper']/div[2]/label"));

        public IWebElement BookTitleValue => this.driver.FindElement(By.XPath("//div[@id='title-wrapper']/div[2]/label"));

        public IWebElement BookSubTitleValue => this.driver.FindElement(By.XPath("//div[@id='subtitle-wrapper']/div[2]/label"));

        public IWebElement BookAuthorValue => this.driver.FindElement(By.XPath("//div[@id='author-wrapper']/div[2]/label"));

        public IWebElement BookPublisherValue => this.driver.FindElement(By.XPath("//div[@id='publisher-wrapper']/div[2]/label"));

        public IWebElement BookTotalPagesValue => this.driver.FindElement(By.XPath("//div[@id='pages-wrapper']/div[2]/label"));

        public IWebElement BookDescriptionValue => this.driver.FindElement(By.XPath("//div[@id='description-wrapper']/div[2]/label"));

        public IWebElement BookWebsiteValue => this.driver.FindElement(By.XPath("//div[@id='website-wrapper']/div[2]/label"));
    }
}

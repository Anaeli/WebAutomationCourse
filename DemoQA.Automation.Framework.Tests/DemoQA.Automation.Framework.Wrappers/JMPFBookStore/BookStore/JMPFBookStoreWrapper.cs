using DemoQA.Automation.Core.Wrappers;
using DemoQA.Automation.Core.Wrappers.Components;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Framework.Wrappers.JMPFBookStore
{
    public class JMPFBookStoreWrapper : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public JMPFBookStoreWrapper(IWebElement container, AutomationClient client)
             : base(container, client)
        {
            this.UserNameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("userName");
        }

        public TextBoxComponentWrapper UserNameTextBox { get; set; }

        public TextBoxComponentWrapper PasswordTextBox => this.WaitForWrapper<TextBoxComponentWrapper>("password"));

        public ButtonComponentWrapper LoginButton => this.WaitForWrapper<ButtonComponentWrapper>("login");

        public ButtonComponentWrapper GoToStoreButton => this.WaitForWrapper<ButtonComponentWrapper>("gotoStore");

        public ButtonComponentWrapper DeleteAllBooksButton => this.WaitForWrapper<ButtonComponentWrapper>("submit");

        public IWebElement FirstBook => this.driver.FindElement(By.XPath("//a[contains(.,'Git Pocket Guide')]"));

        public IWebElement SecondBook => this.driver.FindElement(By.XPath("//a[contains(.,'Designing Evolvable Web APIs with ASP.NET')]"));

        public IWebElement ThirdBook => this.driver.FindElement(By.XPath("//a[contains(.,'Speaking JavaScript')]"));

        public IWebElement AddBookToCollectionButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));

        public IWebElement GotoNewBookStoreButton => this.driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));

        public IWebElement Profile => this.driver.FindElement(By.XPath("//span[contains(.,'Profile')]"));

        public IWebElement DeleteFirstBook => this.driver.FindElement(By.XPath("//span[@id='see-book-Git Pocket Guide']//parent::div//parent::div//following-sibling::div[3]/div/span"));

        public IWebElement ModalOkButton => this.driver.FindElement(By.Id("closeSmallModal-ok"));

        public IWebElement DeleteAccountButton => this.driver.FindElement(By.XPath("//button[text()='Delete Account']"));

        public IWebElement LoginTitleLabel => this.driver.FindElement(By.Id("userName-label"));
    }
}

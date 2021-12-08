using DemoQA.Automation.Core.Wrappers;
using DemoQA.Automation.Core.Wrappers.Components;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Framework.Wrappers.JMPFBookStore.Login
{
    public class LoginWrapper : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public LoginWrapper(IWebElement container, AutomationClient client)
            : base(container, client)
        {
            this.UserNameTextBox = this.WaitForWrapper<TextBoxComponentWrapper>("userName");
        }

        public TextBoxComponentWrapper UserNameTextBox { get; set; }

        public IWebElement PasswordTextBox => driver.FindElement(By.CssSelector("password"));

        public ButtonComponentWrapper LoginButton => this.WaitForWrapper<ButtonComponentWrapper>("login");
    }
}

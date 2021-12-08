using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Framework.Wrappers
{
    public class JCTextBoxFormWrapper
    {
        // Web driver constructor
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public JCTextBoxFormWrapper()
        {
            // driver = new ChromeDriver();
        }

        // Mapping form fields
        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));
        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));
        public IWebElement EmailTextBoxCss => driver.FindElement(By.CssSelector(".mr-sm-2.field-error.form-control"));
        public IWebElement CurrentAddress => driver.FindElement(By.Id("currentAddress"));
        public IWebElement PermanentAddress => driver.FindElement(By.Id("permanentAddress"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        // Mapping output frame
        public IWebElement output_Name => driver.FindElement(By.Id("name"));
        public IWebElement output_Email => driver.FindElement(By.Id("email"));
        public IWebElement output_CurrentAddress => driver.FindElement(By.XPath("//p[@id='currentAddress']"));
        public IWebElement output_PermanentAddress => driver.FindElement(By.XPath("//p[@id='permanentAddress']"));
    }
}
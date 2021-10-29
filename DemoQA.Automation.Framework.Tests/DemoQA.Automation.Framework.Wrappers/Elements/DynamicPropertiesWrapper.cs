using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Wrappers.Elements
{
    public class DynamicPropertiesWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement RandomText => driver.FindElement(By.TagName("p"));
        public IWebElement EnableAfterBtn => driver.FindElement(By.Id("enableAfter"));
        public IWebElement ColorChangeBtn => driver.FindElement(By.Id("colorChange"));
        public IWebElement VisibleAfterBtn => driver.FindElement(By.Id("visibleAfter"));
    }
}

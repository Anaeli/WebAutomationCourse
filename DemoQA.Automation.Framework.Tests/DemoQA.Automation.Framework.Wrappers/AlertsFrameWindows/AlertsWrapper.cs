using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
namespace DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows
{
    public class AlertsWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement AlertButton => driver.FindElement(By.Id("alertButton"));
        public IWebElement TimerAlertButton => driver.FindElement(By.Id("timerAlertButton"));
        public IWebElement ConfirmButton => driver.FindElement(By.Id("confirmButton"));
        public IWebElement PromptButton => driver.FindElement(By.Id("promtButton"));
        public IWebElement ConfirmResult => driver.FindElement(By.Id("confirmResult"));
        public IWebElement PromptResult => driver.FindElement(By.Id("promptResult"));
    }
}

namespace DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows
{
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    /// <summary>
    /// Wrapper for Alerts page.
    /// </summary>
    public class AlertsWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement AlertButton => this.driver.FindElement(By.Id("alertButton"));
        public IWebElement TimerAlertButton => this.driver.FindElement(By.Id("timerAlertButton"));
        public IWebElement ConfirmButton => this.driver.FindElement(By.Id("confirmButton"));
        public IWebElement PromptButton => this.driver.FindElement(By.Id("promtButton"));
        public IWebElement ConfirmResult => this.driver.FindElement(By.Id("confirmResult"));
        public IWebElement PromptResult => driver.FindElement(By.Id("promptResult"));
    }
}

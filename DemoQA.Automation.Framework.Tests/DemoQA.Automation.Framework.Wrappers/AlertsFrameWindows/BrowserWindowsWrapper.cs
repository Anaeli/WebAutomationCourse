namespace DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows
{
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    /// <summary>
    /// Wrapper for Browser Windows page.
    /// </summary>
    public class BrowserWindowsWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement NewTabButton => this.driver.FindElement(By.Id("tabButton"));

        public IWebElement NewWindowButton => this.driver.FindElement(By.Id("windowButton"));
        public IWebElement NewWindowMessageBtn => this.driver.FindElement(By.Id("messageWindowButton"));

        public IWebElement SampleHeading => this.driver.FindElement(By.Id("sampleHeading"));
        public IWebElement BodyMessage => this.driver.FindElement(By.TagName("body"));
    }
}

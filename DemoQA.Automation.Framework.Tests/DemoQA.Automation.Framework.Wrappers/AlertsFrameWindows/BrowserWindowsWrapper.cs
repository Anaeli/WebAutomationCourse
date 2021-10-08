using OpenQA.Selenium;

namespace DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows
{
    public class BrowserWindowsWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement NewTabButton => driver.FindElement(By.Id("tabButton"));
        public IWebElement NewWindowButton => driver.FindElement(By.Id("windowButton"));
        public IWebElement NewWindowMessageBtn => driver.FindElement(By.Id("messageWindowButton"));

        public IWebElement SampleHeading => driver.FindElement(By.Id("sampleHeading"));
        public IWebElement BodyMessage => driver.FindElement(By.TagName("body"));

    }
}

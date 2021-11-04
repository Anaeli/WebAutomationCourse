namespace DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows
{
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    public class FramesWrappers
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement Frame1 => driver.FindElement(By.Id("frame1"));
        public IWebElement Frame2 => driver.FindElement(By.Id("frame2"));
        public IWebElement SampleHeading => driver.FindElement(By.Id("sampleHeading"));
    }
}

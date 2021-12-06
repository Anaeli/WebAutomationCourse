using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class ECRAlertTest : AutomationTestBase
    {
        private new readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public ECRAlertTest (AutomationFixture fixture) : base (fixture)
        {
            AutomationClient.Instance.GoToPage(URLsList.AlertsURL);
        }

        [Fact]
        public void ValidateThatAlertIsDisplayed()
        {
            this.fixture.Alerts.AlertButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("You clicked a button", alert.Text);
            alert.Accept();
        }

        [Fact]
        public void ValidateTimerAlertButtonIsDisplayed()
        {
            this.fixture.Alerts.TimerAlertButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("This alert appeared after 5 seconds", alert.Text);
            alert.Accept();
        }

        [Theory]
        [InlineData(true)]
        public void ValidatesOkAlertIsDisplayed(Boolean alertButton)
        {
            this.fixture.Alerts.ConfirmButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("Do you confirm action?", alert.Text);
            if (alertButton)
            {
                alert.Accept();
                Assert.Equal("You selected Ok", this.fixture.Alerts.ConfirmResult.Text);
            }
            else
            {
                alert.Dismiss();
                Assert.Equal("You selected Cancel", this.fixture.Alerts.ConfirmResult.Text);
            }
        }

        [Theory]
        [InlineData("Ebert")]
        public void ValidatePromptAlertIsDisplayed(string name)
        {
            this.fixture.Alerts.PromptButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(name);
            alert.Accept();
            Assert.Equal($"You entered {name}", this.fixture.Alerts.PromptResult.Text);
            Thread.Sleep(1000);
        }
    }
}

using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Client;
using DemoQA.Automation.Framework.Wrappers;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class RGCAlertsTests: AutomationTestBase
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public RGCAlertsTests( AutomationFixture fixture) : base(fixture)
        {
            AutomationClient.Instance.GoToPage(URLsList.AlertsURL);
        }

        [Fact]
        public void ValidateThatAlertIsDisplayed()
        {
            this.fixture.Alerts.AlertButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("You clicked a button", alert.Text);
        }

        [Fact]
        public void ValidatesThatOkAlertIsDisplayed()
        {
            this.fixture.Alerts.ConfirmButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("Do you confirm action?", alert.Text);
            alert.Accept();
            Assert.Equal("You selected Ok", this.fixture.Alerts.ConfirmResult.Text);

            this.fixture.Alerts.ConfirmButton.Click();
            IAlert alert1 = driver.SwitchTo().Alert();
            Assert.Equal("Do you confirm action?", alert1.Text);
            alert1.Dismiss();
            Assert.Equal("You selected Cancel", this.fixture.Alerts.ConfirmResult.Text);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidatesAlertToReceiveOkOrDismiss(bool confirm)
        {
            this.fixture.Alerts.ConfirmButton.Click();
            IAlert confirmAlert = driver.SwitchTo().Alert();
            if (confirm == true)
            {
                Assert.Equal("Do you confirm action?", confirmAlert.Text);
                confirmAlert.Accept();
                Assert.Equal("You selected Ok", this.fixture.Alerts.ConfirmResult.Text);
            }
            else
            {
                Assert.Equal("Do you confirm action?", confirmAlert.Text);
                confirmAlert.Dismiss();
                Assert.Equal("You selected Cancel", this.fixture.Alerts.ConfirmResult.Text);
            }

        }

        [Theory]
        [InlineData("Reynaldo")]
        public void ValidatesThatPromptAlertIsDisplayed(string name)
        {
            this.fixture.Alerts.PromptButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(name);
            alert.Accept();
            Assert.Equal($"You entered {name}", this.fixture.Alerts.PromptResult.Text);
        }
    }
}

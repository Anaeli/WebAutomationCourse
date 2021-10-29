using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Client;
using DemoQA.Automation.Framework.Wrappers;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class MCAlertsTests: AutomationTestBase
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public MCAlertsTests( AutomationFixture fixture) : base(fixture)
        {
            AutomationClient.Instance.GoToPage(URLsList.AlertsURL);
        }

        //[Fact]
        //public void ValidateThatAlertIsDispalyed()
        //{
        //    this.fixture.Alerts.AlertButton.Click();
        //    IAlert alert = driver.SwitchTo().Alert();
        //    Assert.Equal("You clicked a button", alert.Text);
        //}

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
    }
}

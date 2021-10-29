﻿using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class AlertsTests : AutomationTestBase
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public AlertsTests(AutomationFixture fixture) : base(fixture)
        {
            AutomationClient.Instance.GoToPage(URLsList.AlertsURL);
        }

        [Fact]
        public void ValidateThatAlertIsDispalyed()
        {
            this.Fixture.Alerts.AlertButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("You clicked a button", alert.Text);
        }

        [Fact]
        public void ValidatesThatOkAlertIsDisplayed()
        {
            this.Fixture.Alerts.ConfirmButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("Do you confirm action?", alert.Text);
            alert.Accept();
            Assert.Equal("You selected Ok", this.Fixture.Alerts.ConfirmResult.Text);

            this.Fixture.Alerts.ConfirmButton.Click();
            IAlert alert1 = driver.SwitchTo().Alert();
            Assert.Equal("Do you confirm action?", alert1.Text);
            alert1.Dismiss();
            Assert.Equal("You selected Cancel", this.Fixture.Alerts.ConfirmResult.Text);
        }

        [Theory]
        [InlineData("Eliana")]
        public void ValidatesThatPromptAlertIsDisplayed(string name)
        {
            this.Fixture.Alerts.PromptButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(name);
            alert.Accept();
            Assert.Equal($"You entered {name}", this.Fixture.Alerts.PromptResult.Text);
        }

        //[Fact]
        //public void ValidatesThatTimerAlertButtonAlertIsDisplayed()
        //{
        //    this.fixture.Alerts.TimerAlertButton.Click();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //    wait.Until(ExpectedConditions.AlertIsPresent());            
        //    IAlert alert = driver.SwitchTo().Alert();
        //    Assert.Equal("This alert appeared after 5 seconds", alert.Text);
        //    alert.Accept();
        //}
    }
}

using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationTestBase: IClassFixture<AutomationFixture>, IDisposable
    {
        public AutomationFixture Fixture { get; private set; }

        public IWebDriver Driver { get; private set; }

        public AutomationClient Client { get; private set; }

        public AutomationTestBase(AutomationFixture fixture)
        {
            this.Fixture = fixture;
            Driver = AutomationClient.Instance.Driver;
            Client = AutomationClient.Instance;
        }

        public void Dispose()
        {
            AutomationClient.Instance.QuitDriver();
        }
    }
}

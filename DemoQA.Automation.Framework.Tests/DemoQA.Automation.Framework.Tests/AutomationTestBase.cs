using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationTestBase: IClassFixture<AutomationFixture>, IDisposable
    {
        public AutomationFixture fixture { get; private set; }

        public IWebDriver driver { get; private set; }

        public AutomationClient client { get; private set; }

        public AutomationTestBase(AutomationFixture fixture)
        {
            this.fixture = fixture;
            driver = AutomationClient.Instance.Driver;
            client = AutomationClient.Instance;
        }

        public void Dispose()
        {
            AutomationClient.Instance.QuitDriver();
        }
    }
}

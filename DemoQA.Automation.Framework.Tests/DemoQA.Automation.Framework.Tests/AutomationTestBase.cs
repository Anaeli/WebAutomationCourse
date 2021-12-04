using AventStack.ExtentReports;
using DemoQA.Automation.Core.ReportManager;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationTestBase: IClassFixture<AutomationFixture>, IDisposable
    {
        private ExtentReports report = TestReport.GetExtent();
        private readonly ITestOutputHelper output;
        public AutomationFixture fixture { get; private set; }

        public IWebDriver driver { get; private set; }

        public AutomationClient client { get; private set; }

        public AutomationTestBase(AutomationFixture fixtureI, ITestOutputHelper output)
        {
            this.output = output;
            this.fixture = fixture;
            driver = AutomationClient.Instance.Driver;
            client = AutomationClient.Instance;
        }

        public void Dispose()
        {
            if (TestCase.Status == TestCaseStatus.Failed.ToString())
            {
                TestReport.TakeScreenshot(this.output, AutomationClient.Instance);
            }
            else if (TestCase.Status == TestCaseStatus.Passed.ToString())
            {
                TestReport.SetTestPass("Test Case Passed!", this.output);
            }

            AutomationClient.Instance.QuitDriver();
        }
    }
}

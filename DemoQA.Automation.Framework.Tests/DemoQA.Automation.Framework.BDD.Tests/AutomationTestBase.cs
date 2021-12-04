using AventStack.ExtentReports;
using DemoQA.Automation.Core.ReportManager;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.BDD.Tests
{
    public class AutomationTestBase : IDisposable
    {
        private ExtentReports report = TestReport.GetExtent();
        private readonly ITestOutputHelper output;
        public IWebDriver driver { get; private set; }

        public AutomationClient client { get; private set; }

        public AutomationTestBase(ITestOutputHelper output)
        {

            this.output = output;
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

        [BeforeScenario(Order = 0)]
        public void SetTestFailed()
        {
            TestCase.SetTestFailed();
        }
    }
}

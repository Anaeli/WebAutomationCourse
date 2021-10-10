using DemoQA.Automation.Framework.Wrappers;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationTestBase: IClassFixture<AutomationFixture>, IDisposable
    {
        public AutomationFixture fixture { get; private set; }

        public AutomationTestBase(AutomationFixture fixture)
        {
            this.fixture = fixture;
        }

        public void Dispose()
        {
            AutomationClient.Instance.QuitDriver();
        }
    }
}

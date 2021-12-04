using DemoQA.Automation.Framework.Tests.Client;
using System.Collections.ObjectModel;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class BrowserWindowsTests: AutomationTestBase
    {
       
        public BrowserWindowsTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.client.GoToPage(URLsList.BrowserWindowsURL);
        }

        [Fact]
        public void ValidateThatANewTabIsOpen()
        {
            this.fixture.BrowserWindows.NewTabButton.Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            string firstTab = windowHandles[0];
            string lastTab = windowHandles[windowHandles.Count - 1];
            driver.SwitchTo().Window(lastTab);

            Assert.Equal("This is a sample page", this.fixture.BrowserWindows.SampleHeading.Text);
            driver.SwitchTo().Window(firstTab); //back to first tab/window
        }

        [Fact]
        public void ValidateThatANewWindowIsOpen()
        {
            this.fixture.BrowserWindows.NewWindowButton.Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            string lastTab = windowHandles[windowHandles.Count - 1];
            driver.SwitchTo().Window(lastTab);

            Assert.Equal("This is a sample page", this.fixture.BrowserWindows.SampleHeading.Text);
        }

        [Fact]
        public void ValidateThatANewWindowMessageIsOpen()
        {
            this.fixture.BrowserWindows.NewWindowMessageBtn.Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            string lastTab = windowHandles[windowHandles.Count - 1];
            driver.SwitchTo().Window(lastTab);

            Assert.Contains("Knowledge increases by sharing but not by saving", this.fixture.BrowserWindows.BodyMessage.Text);
        }
    }
}

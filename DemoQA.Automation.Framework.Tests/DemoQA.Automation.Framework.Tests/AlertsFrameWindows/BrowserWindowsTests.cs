using DemoQA.Automation.Framework.Tests.Client;
using System.Collections.ObjectModel;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class BrowserWindowsTests: AutomationTestBase
    {
       
        public BrowserWindowsTests(AutomationFixture fixture) : base(fixture)
        {
            this.Client.GoToPage(URLsList.BrowserWindowsURL);
        }

        [Fact]
        public void ValidateThatANewTabIsOpen()
        {
            this.Fixture.BrowserWindows.NewTabButton.Click();

            ReadOnlyCollection<string> windowHandles = Driver.WindowHandles;

            string firstTab = windowHandles[0];
            string lastTab = windowHandles[windowHandles.Count - 1];
            Driver.SwitchTo().Window(lastTab);

            Assert.Equal("This is a sample page", this.Fixture.BrowserWindows.SampleHeading.Text);
            Driver.SwitchTo().Window(firstTab); //back to first tab/window
        }

        [Fact]
        public void ValidateThatANewWindowIsOpen()
        {
            this.Fixture.BrowserWindows.NewWindowButton.Click();

            ReadOnlyCollection<string> windowHandles = Driver.WindowHandles;
            string lastTab = windowHandles[windowHandles.Count - 1];
            Driver.SwitchTo().Window(lastTab);

            Assert.Equal("This is a sample page", this.Fixture.BrowserWindows.SampleHeading.Text);
        }

        [Fact]
        public void ValidateThatANewWindowMessageIsOpen()
        {
            this.Fixture.BrowserWindows.NewWindowMessageBtn.Click();

            ReadOnlyCollection<string> windowHandles = Driver.WindowHandles;
            string lastTab = windowHandles[windowHandles.Count - 1];
            Driver.SwitchTo().Window(lastTab);

            Assert.Contains("Knowledge increases by sharing but not by saving", this.Fixture.BrowserWindows.BodyMessage.Text);
        }
    }
}

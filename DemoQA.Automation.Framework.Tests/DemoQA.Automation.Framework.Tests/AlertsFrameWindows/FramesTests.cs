using DemoQA.Automation.Framework.Wrappers;
using OpenQA.Selenium;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class FramesTests: AutomationTestBase
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;
        public FramesTests(AutomationFixture fixture):base (fixture)
        {
            AutomationClient.Instance.GoToPage("https://demoqa.com/frames");
        }

        [Fact]
        public void ValidatesThatIsPossibleSwitchBetweenFrames()
        {
            driver.SwitchTo().Frame(this.fixture.Frames.Frame1);
            Assert.Equal("This is a sample page", this.fixture.Frames.SampleHeading.Text);
        }
    }
}

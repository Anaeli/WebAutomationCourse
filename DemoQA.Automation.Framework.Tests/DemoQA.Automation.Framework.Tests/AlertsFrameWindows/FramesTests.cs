using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class FramesTests: AutomationTestBase
    {
        public FramesTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.client.GoToPage("https://demoqa.com/frames");
        }

        [Fact]
        public void ValidatesThatIsPossibleSwitchBetweenFrames()
        {
            driver.SwitchTo().Frame(this.fixture.Frames.Frame1);
            Assert.Equal("This is a sample page", this.fixture.Frames.SampleHeading.Text);

            driver.SwitchTo().DefaultContent();
            IWebElement element = this.driver.FindElement(By.Id("framesWrapper"));
            Assert.Contains("Sample Iframe page There are 2 Iframes in this page.", element.Text);

            driver.SwitchTo().Frame(this.fixture.Frames.Frame2);
            Assert.Equal("This is a sample page", this.fixture.Frames.SampleHeading.Text);
        }
    }
}

using OpenQA.Selenium;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.AlertsFrameWindows
{
    public class FramesTests: AutomationTestBase
    {
        public FramesTests(AutomationFixture fixture):base (fixture)
        {
            this.client.GoToPage("https://demoqa.com/frames");
        }

        [Fact]
        public void ValidatesThatIsPossibleSwitchBetweenFrames()
        {
            driver.SwitchTo().Frame(this.Fixture.Frames.Frame1);
            Assert.Equal("This is a sample page", this.Fixture.Frames.SampleHeading.Text);

            driver.SwitchTo().DefaultContent();
            IWebElement element = this.driver.FindElement(By.Id("framesWrapper"));
            Assert.Contains("Sample Iframe page There are 2 Iframes in this page.", element.Text);

            driver.SwitchTo().Frame(this.Fixture.Frames.Frame2);
            Assert.Equal("This is a sample page", this.Fixture.Frames.SampleHeading.Text);
        }
    }
}

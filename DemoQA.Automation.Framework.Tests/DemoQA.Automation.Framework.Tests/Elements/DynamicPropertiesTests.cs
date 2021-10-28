using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Labels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class DynamicPropertiesTests : AutomationTestBase, IClassFixture<AutomationFixture>
    { 
        public DynamicPropertiesTests(AutomationFixture fixture) : base(fixture)
        {
            AutomationClient.Instance.GoToPage("https://demoqa.com/dynamic-properties");
        }

        [Fact]
        public void ValidateRandomText()
        {
            Assert.Equal("This text has random Id", this.Fixture.Dynamic.RandomText.Text);
        }

        [Fact]
        public void ValidateEnable5Seconds()
        {
           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

           this.Client.Wait.Until(ExpectedConditions.ElementToBeClickable(this.Fixture.Dynamic.EnableAfterBtn));
            Assert.True(this.Fixture.Dynamic.EnableAfterBtn.Enabled, $"Enable After button is not enabled after 5 seconds");
        }

        [Fact]
        public void ValidateColorChange()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            this.Client.Wait.Equals(ExpectedConditions.Equals(ColorList.Red, this.Fixture.Dynamic.ColorChangeBtn.GetCssValue("color")));
        }
       

        [Fact]
        public void ValidateIsVisibleAfter5Seconds()
        {
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.Client.Wait.Until(ExpectedConditions.ElementExists(By.Id("visibleAfter")));
            Assert.True(this.Fixture.Dynamic.VisibleAfterBtn.Displayed, $"Visible After button is not visible after 5 seconds");
        }
    }
}

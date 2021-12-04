using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers.Students;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class RGCPracticeTextBoxTests : AutomationTestBase
    {
        private readonly RGCPracticeTextBoxWrapper practiceTextBox;

        public RGCPracticeTextBoxTests(AutomationFixture fixture) : base(fixture)
        {
            this.practiceTextBox = new RGCPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Reynaldo Guzman","rguzman@test.com", "This is my Current Address.", "This is my Permanent Address.")]
        public void ValidateThatTextBoxIsFilledProperly(string fullName, string eMail, string currentAddress, string permanentAddress)
        {
            this.client.GoToPage("https://demoqa.com/text-box");
            practiceTextBox.FullNameTextBox.SendKeys(fullName);
            practiceTextBox.EMailTextBox.SendKeys(eMail);
            practiceTextBox.CurrentAddressTextBox.SendKeys(currentAddress);
            practiceTextBox.PermanentAddressTextBox.SendKeys(permanentAddress);
            practiceTextBox.SubmitButton.Click();
            Assert.Contains(fullName, practiceTextBox.OutputFullName.Text);
            Assert.Contains(eMail, practiceTextBox.OutputEmail.Text);
            Assert.Contains(currentAddress, practiceTextBox.OutputCurrentAddress.Text);
            Assert.Contains(permanentAddress, practiceTextBox.OutputPermanentAddress.Text);
        }

        [Theory]
        [InlineData("Reynaldo Guzman", "rguzman.test.com", "This is my Current Address.", "This is my Permanent Address.")]
        public void ValidateThatEmailIsRedWithInvalidValueFilled(string fullName, string eMail, string currentAddress, string permanentAddress)
        {
            this.client.GoToPage("https://demoqa.com/text-box");
            practiceTextBox.FullNameTextBox.SendKeys(fullName);
            practiceTextBox.EMailTextBox.SendKeys(eMail);
            practiceTextBox.SubmitButton.Click();
            practiceTextBox.CurrentAddressTextBox.SendKeys(currentAddress);
            practiceTextBox.PermanentAddressTextBox.SendKeys(permanentAddress);
            string eMailLabelColor = practiceTextBox.EMailTextBox.GetCssValue("border-color");
            Assert.Equal("#FF0000", ColorHelper.ConvertRgbToHex(eMailLabelColor));

        }

    }
}

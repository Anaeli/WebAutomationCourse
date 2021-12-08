using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Client;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers.Students;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class JMPFPracticeTextBoxTest : AutomationTestBase
    {

        public JMPFPracticeTextBoxTest(AutomationFixture fixture) : base(fixture)
        {
            this.client.GoToPage(URLsList.TextBoxURL);
        }

        [Theory]
        [InlineData("Jessica Pena", "testing@gmail.com", "Av Heroinas", "Av Avaroa")]
        public void ValidatesThatFormIsFillSuccessfuly(string fullName, string eMail, string address, string permanentAddress)
        {
            this.fixture.JMPFPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            this.fixture.JMPFPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
            this.fixture.JMPFPracticeTextBoxWrapper.AddressTextBox.SendKeys(address);
            this.fixture.JMPFPracticeTextBoxWrapper.PermanentAddressTextBox.SendKeys(permanentAddress);

            AutomationClient.Instance.ScrollIntoView(this.fixture.JMPFPracticeTextBoxWrapper.SubmitButton);
            this.fixture.JMPFPracticeTextBoxWrapper.SubmitButton.Click();

            Thread.Sleep(1000);
            Assert.Contains(address, this.fixture.JMPFPracticeTextBoxWrapper.OutputCurrentAddress.Text);
            Assert.Contains(permanentAddress, this.fixture.JMPFPracticeTextBoxWrapper.OutputPermanentAddress.Text);
        }

        [Theory]
        [InlineData("testEmail")]
        public void ValidateEmailBorder(string eMail)
        {
            this.fixture.JMPFPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);

            AutomationClient.Instance.ScrollIntoView(this.fixture.JMPFPracticeTextBoxWrapper.SubmitButton);
            this.fixture.JMPFPracticeTextBoxWrapper.SubmitButton.Click();

            Thread.Sleep(1000);
            Assert.Equal(ColorList.RedLabel.ToUpper(), ColorHelper.ConvertRgbaToHex(this.fixture.JMPFPracticeTextBoxWrapper.EmailTextBox.GetCssValue("border-top-color")));
        }
    }
}

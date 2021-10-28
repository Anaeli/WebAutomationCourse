using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using System.Threading;
using Xunit;


namespace DemoQA.Automation.Framework.Tests.Students
{
    public class JCPracticeTextBoxTest : AutomationTestBase
    {
        private JCTextBoxFormWrapper jcPracticeTextBoxWrapper;

        public JCPracticeTextBoxTest(AutomationFixture fixture) : base(fixture)
        {
            this.jcPracticeTextBoxWrapper = new JCTextBoxFormWrapper();
            this.client.GoToPage("https://demoqa.com/text-box");
        }

        [Theory]
        [InlineData("Jose Cruz", "jose.cruz@jalasoft.com", "Av. America #123", "Av. Libertador #456")]
        public void ValidatesThatFormIsFilledOutSuccessfuly(string fullName, string email, string currentAddress, string permanentAddress)
        {

            this.fixture.jcPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            this.fixture.jcPracticeTextBoxWrapper.EmailTextBox.SendKeys(email);
            this.fixture.jcPracticeTextBoxWrapper.CurrentAddress.SendKeys(currentAddress);
            this.fixture.jcPracticeTextBoxWrapper.PermanentAddress.SendKeys(permanentAddress);
            this.fixture.jcPracticeTextBoxWrapper.SubmitButton.Click();

            Assert.Contains(fullName, jcPracticeTextBoxWrapper.output_Name.Text);
            Assert.Contains(email, jcPracticeTextBoxWrapper.output_Email.Text);
            Assert.Contains(currentAddress, jcPracticeTextBoxWrapper.output_CurrentAddress.Text);
            Assert.Contains(permanentAddress, jcPracticeTextBoxWrapper.output_PermanentAddress.Text);
        }

        [Theory]
        [InlineData("Jose Cruz", "bad email", "Av. America #123", "Av. Libertador #456")]
        public void ValidatesThatEmailFieldisErrored(string fullName, string email, string currentAddress, string permanentAddress)
        {

            this.fixture.jcPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            this.fixture.jcPracticeTextBoxWrapper.EmailTextBox.SendKeys(email);
            this.fixture.jcPracticeTextBoxWrapper.CurrentAddress.SendKeys(currentAddress);
            this.fixture.jcPracticeTextBoxWrapper.PermanentAddress.SendKeys(permanentAddress);
            this.fixture.jcPracticeTextBoxWrapper.SubmitButton.Click();

            Thread.Sleep(3000);
            Assert.Equal(ColorList.PureRed.ToUpper(), ColorHelper.ConvertRgbToHexRemovingPxSizes(this.fixture.jcPracticeTextBoxWrapper.EmailTextBoxCss.GetCssValue("border")));
        }
    }
}
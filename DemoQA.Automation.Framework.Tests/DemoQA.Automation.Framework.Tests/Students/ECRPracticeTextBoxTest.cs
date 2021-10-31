using DemoQA.Automation.Framework.Wrappers.Students;
using System;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class ECRPracticeTextBoxTest : IDisposable
    {
        private ECRPracticeTextBoxWrapper ecrPracticeTextBoxWrapper;

        public ECRPracticeTextBoxTest ()
        {
            this.ecrPracticeTextBoxWrapper = new ECRPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Ebert Cervantes", "ebert.cervantes@gmail.com")]
        public void ValidatesThatFormIsFillSuccessfuly(string fullName, string eMail)
        {
            ecrPracticeTextBoxWrapper.GoToPage();
            ecrPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            ecrPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
        }

        [Theory]
        [InlineData("Current Address", "Permanent Address")]
        public void ValidatesThatAddressElementsAreFillSuccessfuly(string currentAddress, string permanentAddress)
        {
            ecrPracticeTextBoxWrapper.GoToPage();
            ecrPracticeTextBoxWrapper.CurrentAddressTextBox.SendKeys(currentAddress);
            ecrPracticeTextBoxWrapper.PermanentAddressTextBox.SendKeys(permanentAddress);
            ecrPracticeTextBoxWrapper.SubmitButton.Click();

            Assert.Contains(currentAddress, ecrPracticeTextBoxWrapper.OutputTextBox.Text);
            Assert.Contains(permanentAddress, ecrPracticeTextBoxWrapper.OutputTextBox.Text);
        }

        [Theory]
        [InlineData("TestValidationEmailField")]
        public void ValidateEmailBorder(string eMail)
        {
            ecrPracticeTextBoxWrapper.GoToPage();
            ecrPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
            ecrPracticeTextBoxWrapper.SubmitButton.Click();
            Thread.Sleep(200);
            Assert.Contains("rgb(255, 0, 0)", ecrPracticeTextBoxWrapper.EmailTextBox.GetCssValue("border"));
        }
        public void Dispose()
        {
            ecrPracticeTextBoxWrapper.QuitDriver();
        }
    }
}

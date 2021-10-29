using DemoQA.Automation.Framework.Wrappers.Students;
using System;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class DZOPracticeTextBoxTest : IDisposable
    {
        private DZOPracticeTextBoxWrapper dzoPracticeTextBoxWrapper;

        public DZOPracticeTextBoxTest()
        {
            this.dzoPracticeTextBoxWrapper = new DZOPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Daniel Zubieta", "Danielz@gmail.com")]
        public void ValidatesThatFormIsFillSuccessfuly(string fullName, string eMail)
        {
            dzoPracticeTextBoxWrapper.GoToPage();
            dzoPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            dzoPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
        }

        [Theory]
        [InlineData("Current Address", "Permanent Address")]
        public void ValidatesThatAddressElemetsAreFillSuccessfuly(string currentAddress, string permanentAddress)
        {
            dzoPracticeTextBoxWrapper.GoToPage();
            dzoPracticeTextBoxWrapper.CurrentAddressTextBox.SendKeys(currentAddress);
            dzoPracticeTextBoxWrapper.PermanentAddressTextBox.SendKeys(permanentAddress);
            String test = this.dzoPracticeTextBoxWrapper.PermanentAddressTextBox.Text;


            dzoPracticeTextBoxWrapper.SubmitButton.Click();

            Assert.Contains(currentAddress, dzoPracticeTextBoxWrapper.OutputTextBox.Text);
            Assert.Contains(permanentAddress, dzoPracticeTextBoxWrapper.OutputTextBox.Text);
            Thread.Sleep(5000);
        }

        [Theory]
        [InlineData("TestInvalidEmail")]
        public void ValidateEmailBorder(string eMail)
        {
            dzoPracticeTextBoxWrapper.GoToPage();
            dzoPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
            dzoPracticeTextBoxWrapper.SubmitButton.Click();
            Thread.Sleep(200);
            Assert.Contains("rgb(255, 0, 0)", dzoPracticeTextBoxWrapper.EmailTextBox.GetCssValue("border"));

        }

        public void Dispose()
        {
            dzoPracticeTextBoxWrapper.QuitDriver();
        }
    }
}

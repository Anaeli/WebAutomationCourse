using System;
using System.Collections.Generic;
using System.Threading;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Wrappers.Students;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class MCPracticeTextBoxTest : IDisposable
    {
        private TableComponentWrapper table;

        private MCPracticeTextBoxWrapper mcPracticeTextBoxWrapper;
        public MCPracticeTextBoxTest()
        {
            this.mcPracticeTextBoxWrapper = new MCPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Marco Chavez", "marcotest@gmail.com", "Pepito Palotes Av.", "Las Planchitas Anexo")]
        public void ValidatesThatFormIsFillSuccessfuly(string fullName, string eMail, string currentAddress, string permanentAddress)
        {
            mcPracticeTextBoxWrapper.GoToPage();
            mcPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            mcPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
            mcPracticeTextBoxWrapper.CurrentAddress.SendKeys(currentAddress);
            mcPracticeTextBoxWrapper.PermanentAddress.SendKeys(permanentAddress);
            mcPracticeTextBoxWrapper.SubmitButton.Click();

            Assert.Contains(fullName, mcPracticeTextBoxWrapper.OTable.Text);
            Assert.Contains(eMail, mcPracticeTextBoxWrapper.OTable.Text);
            Assert.Contains(currentAddress, mcPracticeTextBoxWrapper.OTable.Text);
            Assert.Contains(permanentAddress, mcPracticeTextBoxWrapper.OTable.Text);
        }

        [Theory]
        [InlineData("Marco Chavez", "marcotestgmail.com", "Pepito Palotes Av.", "Las Planchitas Anexo")]
        public void ValidateThatEmailFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string fullName, string eMail, string currentAddress, string permanentAddress)
        {
            mcPracticeTextBoxWrapper.GoToPage();
            mcPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            mcPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
            mcPracticeTextBoxWrapper.CurrentAddress.SendKeys(currentAddress);
            mcPracticeTextBoxWrapper.PermanentAddress.SendKeys(permanentAddress);
            mcPracticeTextBoxWrapper.SubmitButton.Click();

            Thread.Sleep(2000);

            Assert.Contains("rgb(255, 0, 0)", mcPracticeTextBoxWrapper.EmailTextBox.GetCssValue("border"));
        }
        public void Dispose()
        {
            mcPracticeTextBoxWrapper.QuitDriver();
        }
    }
}

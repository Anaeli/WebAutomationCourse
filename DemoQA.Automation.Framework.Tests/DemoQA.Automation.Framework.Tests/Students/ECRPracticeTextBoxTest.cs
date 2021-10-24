using DemoQA.Automation.Framework.Wrappers.Students;
using System;
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

        public void Dispose()
        {
            ecrPracticeTextBoxWrapper.QuitDriver();
        }
    }
}

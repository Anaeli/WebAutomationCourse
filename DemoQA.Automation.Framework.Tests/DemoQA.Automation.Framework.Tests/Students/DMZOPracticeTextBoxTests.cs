using DemoQA.Automation.Framework.Wrappers;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class DMZOPracticeTextBoxTests : IDisposable
    {
        private DMZOPracticeTextBoxWrapper practiceTextBox;

        public DMZOPracticeTextBoxTests()
        {
            this.practiceTextBox = new DMZOPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Daniel Zubieta", "DanielZ@Test.com")]
        public void validateThatTextBoxIsFilledProperly(string fullName, string eMail)
        {
            practiceTextBox.GoToPage();
            practiceTextBox.FullNameTextBox.SendKeys(fullName);
            practiceTextBox.EMailTextBox.SendKeys(eMail);
        }


        public void Dispose()
        {
            practiceTextBox.QuitDriver();
        }
    }
}
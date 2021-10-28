using DemoQA.Automation.Framework.Wrappers;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class HGRPracticeTextBoxTests : IDisposable
    {
        private HGRPracticeTextBoxWrapper practiceTextBox;

        public HGRPracticeTextBoxTests()
        {
            this.practiceTextBox = new HGRPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Harry Grajeda", "grajedaharry@gmail.com")]
        public void validateThatTextBoxIsFilledProperly(string fullName, string eMail)
        {
            practiceTextBox.GoToPage();
            practiceTextBox.FullNameTextBox.SendKeys(fullName);
            practiceTextBox.EMailTextBox.SendKeys(eMail)
;
        }


        public void Dispose()
        {
            practiceTextBox.QuitDriver();
        }
    }
}
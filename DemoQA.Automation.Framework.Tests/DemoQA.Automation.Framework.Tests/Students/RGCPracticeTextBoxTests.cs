using DemoQA.Automation.Framework.Wrappers;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class RGCPracticeTextBoxTests : IDisposable
    {
        private RGCPracticeTextBoxWrapper practiceTextBox;

        public RGCPracticeTextBoxTests()
        {
            this.practiceTextBox = new RGCPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Reynaldo Guzman","rguzman@test.com")]
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

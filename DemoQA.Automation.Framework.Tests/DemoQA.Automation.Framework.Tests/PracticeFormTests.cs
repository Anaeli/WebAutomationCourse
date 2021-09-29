using DemoQA.Automation.Framework.Wrappers;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class TextBoxFromTest : IDisposable
    {
        private TextBoxFormWrapper practiceForm;

        public TextBoxFromTest()
        {
            this.practiceForm = new TextBoxFormWrapper();
        }

        [Theory]
        [InlineData("Eliana", "test@mail.com")]
        public void ValidateNameEmail(string name, string email)
        {
            practiceForm.GoToPage();
            practiceForm.FullNameTextBox.SendKeys(name);
            practiceForm.EmailTextBox.SendKeys(email);
            
        }

        public void Dispose()
        {
            practiceForm.QuitDriver();
        }
    }
}

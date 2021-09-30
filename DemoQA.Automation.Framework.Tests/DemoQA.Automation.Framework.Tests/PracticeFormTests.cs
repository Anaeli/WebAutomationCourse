
using DemoQA.Automation.Framework.Wrappers;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class PracticeFormTests : IDisposable
    {
        private PracticeFormWrapper practiceForm;

        public PracticeFormTests()
        {
            this.practiceForm = new PracticeFormWrapper();
        }

        [Theory]
        [InlineData("Ruben", "Camargo")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName)
        {
            practiceForm.GoToPage();
            practiceForm.NameTextBox.SendKeys(name);
            practiceForm.LastNameTextBox.SendKeys(lastName);
        }

        public void Dispose()
        {
            practiceForm.QuitDriver();
        }
    }
}

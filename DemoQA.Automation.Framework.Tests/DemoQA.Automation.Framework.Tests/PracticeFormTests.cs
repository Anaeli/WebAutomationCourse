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
        [InlineData("Eliana", "Navia", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            practiceForm.GoToPage();
            practiceForm.NameTextBox.SendKeys(name);
            practiceForm.LastNameTextBox.SendKeys(lastName);
            practiceForm.EmailTextBox.SendKeys(email);
            practiceForm.SelectGenderRadioButton(gender);
            practiceForm.MobileNumberTextBox.SendKeys(mobileNumber);
            practiceForm.DateOfBirth.Clear();
            practiceForm.FillDateOfBirth("08 Aug 2021");
            practiceForm.StateDropDown.Click();
            practiceForm.StateDropDown.SendKeys("NCR");
        }

        public void Dispose()
        {
            practiceForm.QuitDriver();
        }
    }
}

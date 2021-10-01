using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using System;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class PracticeFormTests : IDisposable
    {
        private PracticeFormWrapper practiceForm;
        private TableComponentWrapper table;

        public PracticeFormTests()
        {
            this.practiceForm = new PracticeFormWrapper();
            this.table = new TableComponentWrapper();
        }

        [Theory]
        [InlineData("Eliana", "Navia", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            AutomationClient.Instance.GoToPage("https://demoqa.com/automation-practice-form");
            practiceForm.NameTextBox.SendKeys(name);
            practiceForm.LastNameTextBox.SendKeys(lastName);
            practiceForm.EmailTextBox.SendKeys(email);
            practiceForm.SelectGenderRadioButton(gender);
            practiceForm.MobileNumberTextBox.SendKeys(mobileNumber);
            practiceForm.DateOfBirth.Clear();
            practiceForm.SelectChooseFile();
            UploadFile.UploadFiles("mando.jpeg");
            practiceForm.FillDateOfBirth("08 Aug 2021");
            practiceForm.SelectState("NCR");
            practiceForm.SelectCity("Delhi");
            practiceForm.SubmitButton.Click();

            table.GetTextList();
        }

        public void Dispose()
        {
            AutomationClient.Instance.QuitDriver();
        }
    }
}

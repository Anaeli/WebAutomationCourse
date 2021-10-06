using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using System;
using System.Collections.Generic;
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
            AutomationClient.Instance.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Eliana", "Navia", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            string pictureName = "mando.jpeg";            
            practiceForm.NameTextBox.SendKeys(name);
            practiceForm.LastNameTextBox.SendKeys(lastName);
            practiceForm.EmailTextBox.SendKeys(email);
            practiceForm.SelectGenderRadioButton(gender);
            practiceForm.MobileNumberTextBox.SendKeys(mobileNumber);
            practiceForm.DateOfBirth.Clear();
            practiceForm.SelectChooseFile();
            UploadFile.UploadFiles(pictureName);
            practiceForm.FillDateOfBirth("08 Aug 2021");
            //practiceForm.SelectState("NCR");
            //practiceForm.SelectCity("Delhi");
            practiceForm.ClickSubmitButton();

            IEnumerable<string> tableInfo = table.GetTextList();
            Assert.Contains($"{TableLabels.StudentName} {name} {lastName}", tableInfo);
            Assert.Contains($"{TableLabels.StudentEmail} {email}", tableInfo);
            Assert.Contains($"{TableLabels.Mobile} {mobileNumber}", tableInfo);
            Assert.Contains($"{TableLabels.Picture} {pictureName}", tableInfo);
            Assert.Contains($"{TableLabels.DateOfBirth} 08 August,2021", tableInfo);
            //Assert.Contains($"{TableLabels.StateAndCity} NCR Delhi", tableInfo);
        }

        [Fact]
        public void ValidateThatRequiredFiledAreMarkedWithRedIfThemHaveBeenNotFilled()
        {
            practiceForm.ClickSubmitButton();
            string nameLabelColor = practiceForm.NameTextBox.GetCssValue("border-color");
            string lastNameLabelColor = practiceForm.LastNameTextBox.GetCssValue("border-color");
            string maleLabelColor = practiceForm.MaleLabelRadioButton.GetCssValue("color");
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(nameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(lastNameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbaToHex(maleLabelColor));
        }

        [Theory]
        [InlineData("Eliana", "Navia", "user", "Female", "12345678")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber)
        {
            practiceForm.NameTextBox.SendKeys(name);
            practiceForm.LastNameTextBox.SendKeys(lastName);
            practiceForm.EmailTextBox.SendKeys(email);
            practiceForm.SelectGenderRadioButton(gender);
            practiceForm.MobileNumberTextBox.SendKeys(mobileNumber);
            practiceForm.ClickSubmitButton();

            Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(practiceForm.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(practiceForm.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(practiceForm.MobileNumberTextBox.GetCssValue("border-color")));
        }

        public void Dispose()
        {
            AutomationClient.Instance.QuitDriver();
        }
    }
}

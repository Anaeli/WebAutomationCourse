using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using System;
using System.Collections.Generic;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class PracticeFormTests :AutomationTestBase
    {
        private TableComponentWrapper table;

        public PracticeFormTests(AutomationFixture fixture) : base(fixture)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Eliana", "Navia", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            string pictureName = "mando.jpeg";   
            this.fixture.dzoPracticeFormWrapper.NameTextBox.SendKeys(name);
            this.fixture.dzoPracticeFormWrapper.LastNameTextBox.SendKeys(lastName);
            this.fixture.dzoPracticeFormWrapper.EmailTextBox.SendKeys(email);
            this.fixture.dzoPracticeFormWrapper.SelectGenderRadioButton(gender);
            this.fixture.dzoPracticeFormWrapper.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.dzoPracticeFormWrapper.DateOfBirth.Clear();
            this.fixture.dzoPracticeFormWrapper.SelectChooseFile();
            UploadFile.UploadFiles(pictureName);
            this.fixture.dzoPracticeFormWrapper.FillDateOfBirth("08 Aug 2021");
            //this.fixture.PracticeForm.SelectState("NCR");
            //this.fixture.PracticeForm.SelectCity("Delhi");
            this.fixture.dzoPracticeFormWrapper.ClickSubmitButton();

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
            this.fixture.dzoPracticeFormWrapper.ClickSubmitButton();
            string nameLabelColor = this.fixture.dzoPracticeFormWrapper.NameTextBox.GetCssValue("border-color");
            string lastNameLabelColor = this.fixture.dzoPracticeFormWrapper.LastNameTextBox.GetCssValue("border-color");
            string maleLabelColor = this.fixture.dzoPracticeFormWrapper.MaleLabelRadioButton.GetCssValue("color");
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(nameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(lastNameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbaToHex(maleLabelColor));
        }

        [Theory]
        [InlineData("Eliana", "Navia", "user", "Female", "12345678")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.fixture.dzoPracticeFormWrapper.NameTextBox.SendKeys(name);
            this.fixture.dzoPracticeFormWrapper.LastNameTextBox.SendKeys(lastName);
            this.fixture.dzoPracticeFormWrapper.EmailTextBox.SendKeys(email);
            this.fixture.dzoPracticeFormWrapper.SelectGenderRadioButton(gender);
            this.fixture.dzoPracticeFormWrapper.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.dzoPracticeFormWrapper.ClickSubmitButton();

            Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.MobileNumberTextBox.GetCssValue("border-color")));
        }
    }
}

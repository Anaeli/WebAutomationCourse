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
        private TableComponentWrapper Table;

        public PracticeFormTests(AutomationFixture fixture) : base(fixture)
        {
            this.Table = new TableComponentWrapper();
            this.Client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Eliana", "Navia", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            string pictureName = "mando.jpeg";   
            this.Fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.Fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.Fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.Fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.Fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.Fixture.PracticeForm.DateOfBirth.Clear();
            this.Fixture.PracticeForm.SelectChooseFile();
            UploadFile.UploadFiles(pictureName);
            this.Fixture.PracticeForm.FillDateOfBirth("08 Aug 2021");
            //this.fixture.PracticeForm.SelectState("NCR");
            //this.fixture.PracticeForm.SelectCity("Delhi");
            this.Fixture.PracticeForm.ClickSubmitButton();

            IEnumerable<string> tableInfo = Table.GetTextList();
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
            this.Fixture.PracticeForm.ClickSubmitButton();
            string nameLabelColor = this.Fixture.PracticeForm.NameTextBox.GetCssValue("border-color");
            string lastNameLabelColor = this.Fixture.PracticeForm.LastNameTextBox.GetCssValue("border-color");
            string maleLabelColor = this.Fixture.PracticeForm.MaleLabelRadioButton.GetCssValue("color");
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(nameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(lastNameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbaToHex(maleLabelColor));
        }

        [Theory]
        [InlineData("Eliana", "Navia", "user", "Female", "12345678")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.Fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.Fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.Fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.Fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.Fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.Fixture.PracticeForm.ClickSubmitButton();

            Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.MobileNumberTextBox.GetCssValue("border-color")));
        }
    }
}

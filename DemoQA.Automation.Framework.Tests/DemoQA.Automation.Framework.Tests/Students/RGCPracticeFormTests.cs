using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Wrappers.Students;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class RGCPracticeFormTests : AutomationTestBase
    {
        private TableComponentWrapper table;
        private RGCPracticeTextBoxWrapper practiceTextBox = new RGCPracticeTextBoxWrapper();

        public RGCPracticeFormTests(AutomationFixture fixture) : base(fixture)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Reynaldo", "Guzman", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            string pictureName = "mando.jpeg";
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SetValue(lastName);
                form.EmailTextBox.SendKeys(email);
                form.SelectGenderRadioButton(gender);
                form.MobileNumberTextBox.SendKeys(mobileNumber);
                form.DateOfBirth.Clear();
                form.SelectChooseFile();
                UploadFile.UploadFiles(pictureName);
                form.FillDateOfBirth("08 Aug 2021");
                practiceTextBox.adsElement.Click();
                form.SelectState("NCR");
                form.SelectCity("Delhi");
                form.SubmitButton.ClickUsingJS(client);
            });

            IEnumerable<string> tableInfo = table.GetTextList();
            Assert.Contains($"{TableLabels.StudentName} {name} {lastName}", tableInfo);
            Assert.Contains($"{TableLabels.StudentEmail} {email}", tableInfo);
            Assert.Contains($"{TableLabels.Mobile} {mobileNumber}", tableInfo);
            Assert.Contains($"{TableLabels.Picture} {pictureName}", tableInfo);
            Assert.Contains($"{TableLabels.DateOfBirth} 08 August,2021", tableInfo);
            Assert.Contains($"{TableLabels.StateAndCity} NCR Delhi", tableInfo);
        }

        [Fact]
        public void ValidateThatRequiredFiledAreMarkedWithRedIfThemHaveBeenNotFilled()
        {
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.SubmitButton.ClickUsingJS(client);
                Thread.Sleep(1000);
                string nameLabelColor = form.NameTextBox.BorderColor;
                string lastNameLabelColor = form.LastNameTextBox.BorderColor;
                string maleLabelColor = form.MaleLabelRadioButton.GetCssValue("color");

                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(nameLabelColor));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(lastNameLabelColor));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbaToHex(maleLabelColor));
            });
        }

        [Theory]
        [InlineData("", "Guzman", "user", "Male", " ")]
        [InlineData("", "LastName1", " ", "Male", "strings")]
        [InlineData("", "LastName2", "!@#$%", "Male", "!@#%$^")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SetValue(lastName);
                form.EmailTextBox.SendKeys(email);
                form.SelectGenderRadioButton(gender);
                form.MobileNumberTextBox.SendKeys(mobileNumber);
                form.SubmitButton.ClickUsingJS(client);
                Thread.Sleep(1000);

            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.MobileNumberTextBox.GetCssValue("border-color")));
            });
        }

    }
}

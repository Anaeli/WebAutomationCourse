﻿using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.Students.Forms
{
    public class JMPFPracticeFormTests : AutomationTestBase
    {
        private TableComponentWrapper table;

        public JMPFPracticeFormTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Eliana", "Navia", "test@mail.com", "female", "1234567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            string pictureName = "mando.jpeg";
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SetValue(lastName);
                form.EmailTextBox.SetValue(email);
                form.SelectGenderRadioButton(gender);
                form.MobileNumberTextBox.SetValue(mobileNumber);
                form.DateOfBirth.Clear();
                form.FillDateOfBirth("08 Aug 2021");
                form.SelectChooseFile();
                UploadFile.UploadFiles(pictureName);
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
                //string nameLabelColor = ColorHelper.ConvertRgbToHex(form.NameTextBox.BorderColor);
                //string lastNameLabelColor = form.LastNameTextBox.BorderColor;
                //string maleLabelColor = form.MaleLabelRadioButton.GetCssValue("color");
                var nameLabelColor = ColorHelper.ConvertRgbToHex(form.NameTextBox.BorderColor);
                var lastNameLabelColor = ColorHelper.ConvertRgbToHex(form.LastNameTextBox.BorderColor);
                var maleLabelColor = ColorHelper.ConvertRgbaToHex(form.MaleLabelRadioButton.GetCssValue("color"));
              
                Assert.Equal(ColorList.Red.ToUpper(), nameLabelColor);
                Assert.Equal(ColorList.Red.ToUpper(), lastNameLabelColor);
                Assert.Equal(ColorList.Red.ToUpper(), maleLabelColor);
            });
        }

        [Theory]
        [InlineData("Eliana", "Navia", "user", "Female", "12345678")]
        [InlineData("Jessica", "Peña", "1", "Female", "hello")]
        [InlineData("Melisa", "Flores", "testing", "Female", "14*+6")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SetValue(lastName);
                form.EmailTextBox.SetValue(email);
                form.SelectGenderRadioButton(gender);
                form.MobileNumberTextBox.SetValue(mobileNumber);
                form.SubmitButton.ClickUsingJS(client);

                Thread.Sleep(1000);

                Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(form.NameTextBox.BorderColor));
                Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(form.LastNameTextBox.BorderColor));
                Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbaToHex(form.FemaleLabelRadioButton.GetCssValue("color")));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.EmailTextBox.BorderColor));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.MobileNumberTextBox.BorderColor));
                Thread.Sleep(1000);
            });
        }
    }
}

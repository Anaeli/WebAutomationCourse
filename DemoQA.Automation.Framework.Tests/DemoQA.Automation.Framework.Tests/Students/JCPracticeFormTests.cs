using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class JCPracticeFormTests : AutomationTestBase
    {
        private TableComponentWrapper table;

        public JCPracticeFormTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Jose", "Cruz", "mail@mail.com", "male", "5554567890")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string pictureName = "mando.jpeg";
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SetValue(lastName);
                form.EmailTextBox.SetValue(email);
                form.SelectGenderRadioButton(gender);
                form.MobileNumberTextBox.SetValue(mobileNumber);
                form.DateOfBirth.Clear();
                form.SelectChooseFile();
                UploadFile.UploadFiles(pictureName);
                form.FillDateOfBirth("08 Aug 2021");
                js.ExecuteScript("window.scrollBy(0,900)");
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
                Thread.Sleep(2000);
                string nameLabelColor = form.NameTextBox.BorderColor;
                string lastNameLabelColor = form.LastNameTextBox.BorderColor;
                string maleLabelColor = form.MaleLabelRadioButton.GetCssValue("color");
            
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(nameLabelColor));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(lastNameLabelColor));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbaToHex(maleLabelColor));
            });
        }

        [Theory]
        [InlineData("Eliana", "Navia", "user", "Female", "12345678", "NCR", "Delhi")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber, string state, string city)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SetValue(lastName);
                form.EmailTextBox.SetValue(email);
                form.SelectGenderRadioButton(gender);
                form.MobileNumberTextBox.SetValue(mobileNumber);
                js.ExecuteScript("window.scrollBy(0,900)");
                form.SelectState(state);
                form.SelectCity(city);
                form.SubmitButton.ClickUsingJS(client);
            
            Thread.Sleep(2000);
            Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(form.NameTextBox.BorderColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.EmailTextBox.BorderColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.MobileNumberTextBox.BorderColor));
            });
        }
    }
}

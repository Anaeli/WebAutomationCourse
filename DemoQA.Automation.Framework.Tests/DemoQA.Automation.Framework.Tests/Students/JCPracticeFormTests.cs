using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class JCPracticeFormTests : AutomationTestBase
    {
        private TableComponentWrapper table;

        public JCPracticeFormTests(AutomationFixture fixture) : base(fixture)
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
            this.fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.PracticeForm.DateOfBirth.Clear();
            this.fixture.PracticeForm.SelectChooseFile();
            UploadFile.UploadFiles(pictureName);
            this.fixture.PracticeForm.FillDateOfBirth("08 Aug 2021");
            js.ExecuteScript("window.scrollBy(0,900)");
            this.fixture.PracticeForm.SelectState("NCR");
            this.fixture.PracticeForm.SelectCity("Delhi");
            this.fixture.PracticeForm.ClickSubmitButton();

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
            this.fixture.PracticeForm.ClickSubmitButton();
            Thread.Sleep(2000);
            string nameLabelColor = this.fixture.PracticeForm.NameTextBox.GetCssValue("border-color");
            string lastNameLabelColor = this.fixture.PracticeForm.LastNameTextBox.GetCssValue("border-color");
            string maleLabelColor = this.fixture.PracticeForm.MaleLabelRadioButton.GetCssValue("color");
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(nameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(lastNameLabelColor));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbaToHex(maleLabelColor));
        }

        [Theory]
        [InlineData("Eliana", "Navia", "user", "Female", "12345678", "NCR", "Delhi")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber, string state, string city)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            this.fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            js.ExecuteScript("window.scrollBy(0,900)");
            this.fixture.PracticeForm.SelectState(state);
            this.fixture.PracticeForm.SelectCity(city);
            this.fixture.PracticeForm.ClickSubmitButton();

            Thread.Sleep(2000);
            Assert.Equal(ColorList.Green.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.MobileNumberTextBox.GetCssValue("border-color")));
        }
    }
}

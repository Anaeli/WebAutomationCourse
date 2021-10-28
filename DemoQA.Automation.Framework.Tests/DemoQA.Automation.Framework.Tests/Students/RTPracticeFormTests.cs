using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using System;
using System.Collections.Generic;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class RTPracticeFormTests :AutomationTestBase
    {
        private TableComponentWrapper Table;

        public RTPracticeFormTests(AutomationFixture fixture) : base(fixture)
        {
            this.Table = new TableComponentWrapper();
            this.Client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Ruddy", "Torrez", "test@mail.com", "Male", "1234567890")]
        public void ValidatesFormStateCity(string name, string lastName, string email, string gender, string mobileNumber)
        {
             
            this.Fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.Fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.Fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.Fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.Fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.Fixture.PracticeForm.DateOfBirth.Clear();
            
            
            this.Fixture.PracticeForm.FillDateOfBirth("08 Aug 2021");
            this.Fixture.PracticeForm.SelectState("NCR");
            this.Fixture.PracticeForm.SelectCity("Delhi");
            this.Fixture.PracticeForm.ClickSubmitButton();

            IEnumerable<string> tableInfo = Table.GetTextList();
            Assert.Contains($"{TableLabels.StateAndCity} NCR Delhi", tableInfo);
        }

       
        [Theory]
        [InlineData("", "", "user", "", "")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValue(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.Fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.Fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.Fixture.PracticeForm.EmailTextBox.SendKeys(email);
            
            this.Fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.Fixture.PracticeForm.ClickSubmitButton();

            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.LastNameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.MobileNumberTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.MaleLabelRadioButton.GetCssValue("border-color")));
        }
    }
}

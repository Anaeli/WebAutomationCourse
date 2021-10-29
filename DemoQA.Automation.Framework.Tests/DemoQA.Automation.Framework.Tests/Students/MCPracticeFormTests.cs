using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class MCPracticeFormTests : AutomationTestBase
    {
        private TableComponentWrapper table;

        public MCPracticeFormTests(AutomationFixture fixture) : base(fixture)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Marco", "Chavez", "user@ggmail.com", "Male", "6668985451")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.Fixture.PracticeForm.NameTextBox.SetValue(name);
            this.Fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.Fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.Fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.Fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.Fixture.PracticeForm.DateOfBirth.Clear();
            
            this.Fixture.PracticeForm.FillDateOfBirth("08 Aug 2021");
            this.Fixture.PracticeForm.SelectState("Haryana");
            this.Fixture.PracticeForm.SelectCity("Karnal");
            this.Fixture.PracticeForm.ClickSubmitButton();

            Thread.Sleep(1500);

            IEnumerable<string> tableInfo = table.GetTextList();
            Assert.Contains($"{TableLabels.StateAndCity} Haryana Karnal", tableInfo);
            
        }

        [Theory]
        [InlineData("Marco", "Chavez", "bad email", "Male", "666898545")]
        [InlineData("Marco", "Chavez", "bad email", "Male", "1234")]
        // [InlineData("Marco", "", "user", "Male", "6668985451")]        
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.Fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.Fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.Fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.Fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.Fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.Fixture.PracticeForm.ClickSubmitButton();

            Thread.Sleep(1500);
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.EmailTextBox.GetCssValue("border-color")));
            Thread.Sleep(1500);
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.Fixture.PracticeForm.MobileNumberTextBox.GetCssValue("border-color")));
        }
    }
}

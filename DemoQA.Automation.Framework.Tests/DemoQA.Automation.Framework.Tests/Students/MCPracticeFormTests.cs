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
            this.fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.PracticeForm.DateOfBirth.Clear();
            
            this.fixture.PracticeForm.FillDateOfBirth("08 Aug 2021");
            this.fixture.PracticeForm.SelectState("Haryana");
            this.fixture.PracticeForm.SelectCity("Karnal");
            this.fixture.PracticeForm.ClickSubmitButton();

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
            this.fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.PracticeForm.ClickSubmitButton();

            Thread.Sleep(1500);
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.EmailTextBox.GetCssValue("border-color")));
            Thread.Sleep(1500);
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.MobileNumberTextBox.GetCssValue("border-color")));
        }
    }
}

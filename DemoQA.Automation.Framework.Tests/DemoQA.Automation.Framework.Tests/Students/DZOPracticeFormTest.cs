using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Wrappers.Students;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class DZOPracticeFormTest :AutomationTestBase
    {
        private TableComponentWrapper dzoPracticeFormWrapper;

        public DZOPracticeFormTest(AutomationFixture fixture) : base(fixture)
        {
            this.dzoPracticeFormWrapper = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
            //this.dzoPracticeFormWrapper.GoToPage();
        }

        [Theory]
        [InlineData("Daniel", "Zubieta", "test@test.com", "Male", "55122145645", "NCR", "Delhi")]
        public void ValidatesFormStateCity(string name, string lastName, string email, string gender, string mobileNumber, string state, string city)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            this.fixture.dzoPracticeFormWrapper.NameTextBox.SendKeys(name);
            this.fixture.dzoPracticeFormWrapper.LastNameTextBox.SendKeys(lastName);
            this.fixture.dzoPracticeFormWrapper.EmailTextBox.SendKeys(email);
            this.fixture.dzoPracticeFormWrapper.SelectGenderRadioButton(gender);
            this.fixture.dzoPracticeFormWrapper.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.dzoPracticeFormWrapper.DateOfBirth.Clear();


            this.fixture.dzoPracticeFormWrapper.FillDateOfBirth("08 Aug 2021");
            js.ExecuteScript("window.scrollBy(0,900)");

            this.fixture.dzoPracticeFormWrapper.SelectState(state);
            this.fixture.dzoPracticeFormWrapper.SelectCity(city);
            this.fixture.dzoPracticeFormWrapper.ClickSubmitButton();
            
            IEnumerable<string> tableInfo = dzoPracticeFormWrapper.GetTextList();
            Assert.Contains($"{TableLabels.StateAndCity} NCR Delhi", tableInfo);
        }


        [Theory]
        [InlineData("", "", "user", "", "")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValue(string name, string lastName, string email, string gender, string mobileNumber)
        {
            this.fixture.dzoPracticeFormWrapper.NameTextBox.SendKeys(name);
            this.fixture.dzoPracticeFormWrapper.LastNameTextBox.SendKeys(lastName);
            this.fixture.dzoPracticeFormWrapper.EmailTextBox.SendKeys(email);

            this.fixture.dzoPracticeFormWrapper.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.dzoPracticeFormWrapper.ClickSubmitButton();

            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.LastNameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.MobileNumberTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.dzoPracticeFormWrapper.MaleLabelRadioButton.GetCssValue("border-color")));
        }
    }
}

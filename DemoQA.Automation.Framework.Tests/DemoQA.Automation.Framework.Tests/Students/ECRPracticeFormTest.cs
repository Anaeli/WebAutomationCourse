using DemoQA.Automation.Core.Wrappers.Components;
using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Client;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
   public class ECRPracticeFormTest : AutomationTestBase
    {
        private new readonly IWebDriver driver = AutomationClient.Instance.Driver;
        private TableComponentWrapper ecrPracticeFormWrapper;
        public ECRPracticeFormTest(AutomationFixture fixture) : base (fixture)
        {
            AutomationClient.Instance.GoToPage(URLsList.FormURL);
        }

        [Theory]
        [InlineData("Ebert", "Cervantes", "email.test@gmail.com", "Male", "5689789888", "NCR", "Delhi")]
        public void ValidatesFormsToStateandCity (string name, string lastName, string email, string gender, string mobileNumber, string state, string city)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            this.fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.fixture.PracticeForm.SelectGenderRadioButton(gender);
            this.fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);
            this.fixture.PracticeForm.DateOfBirth.Clear();
            this.fixture.PracticeForm.FillDateOfBirth("08 Aug 2021");
            js.ExecuteScript("window.scrollBy(0,900)");
            this.fixture.PracticeForm.SelectState(state);
            this.fixture.PracticeForm.SelectCity(city);

            this.fixture.PracticeForm.ClickSubmitButton();

            IEnumerable<string> tableInfo = ecrPracticeFormWrapper.GetTextList();
            Assert.Contains($"{ TableLabels.StateAndCity} NCR Delhi", tableInfo);
        }

        [Theory]
        [InlineData("", "", "email", "")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValuesEntered (string name,string lastName ,string email, string mobileNumber)
        {
            this.fixture.PracticeForm.NameTextBox.SendKeys(name);
            this.fixture.PracticeForm.LastNameTextBox.SendKeys(lastName);
            this.fixture.PracticeForm.EmailTextBox.SendKeys(email);
            this.fixture.PracticeForm.MobileNumberTextBox.SendKeys(mobileNumber);

            this.fixture.PracticeForm.ClickSubmitButton();

            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.NameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.LastNameTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.EmailTextBox.GetCssValue("border-color")));
            Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(this.fixture.PracticeForm.MobileNumberTextBox.GetCssValue("border-color")));
        }
    }
}

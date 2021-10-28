using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using System;
using System.Threading;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class HGRPracticeFormTests : AutomationTestBase
    {
        public HGRPracticeFormTests(AutomationFixture fixture) : base(fixture)
        {
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
        }

        [Theory]
        [InlineData("Harry", "Grajeda")]
        public void ValidatesThatFormIsFillSuccessfuly(string name, string lastName)
        {
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(name);
                form.LastNameTextBox.SendKeys(lastName);
                form.SelectGender("Male");
                form.SelectState("NCR");
                form.SelectCity("Delhi");
                form.SubmitButton.ClickUsingJS(client);
            });
        }

        [Theory]
        [InlineData("Grajeda", "Male","asd")]
        [InlineData("Aguirre", "Male", "abc")]
        public void ValidateThatARequiredFieldIsMarkedWithRedWhenIncorrectValueIsEntered(string lastName, string gender, string email)
        {
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.LastNameTextBox.SendKeys(lastName);
                form.SelectGender(gender);
                form.EmailTextBox.SendKeys(email);
                form.SubmitButton.ClickUsingJS(client);
                Thread.Sleep(1000);
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.EmailTextBox.GetCssValue("border-color")));
                Assert.Equal(ColorList.Red.ToUpper(), ColorHelper.ConvertRgbToHex(form.MobileNumberTextBox.GetCssValue("border-color")));
            });
            
        }
    }
}
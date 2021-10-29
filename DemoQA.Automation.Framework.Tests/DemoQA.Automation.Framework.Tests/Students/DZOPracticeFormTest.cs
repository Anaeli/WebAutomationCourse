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
    public class DZOPracticeFormTest : AutomationTestBase
    {
        private TableComponentWrapper table;

        public DZOPracticeFormTest(AutomationFixture fixture) : base(fixture)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/automation-practice-form");
            //this.dzoPracticeFormWrapper.GoToPage();
        }

        [Theory]
        [InlineData("Daniel", "Zubieta", "test@test.com", "Male", "5512214564", "NCR", "Delhi")]
        public void ValidatesThatStateAndCityAreFillSuccessfuly(string name, string lastName, string email, string gender, string mobileNumber, string state, string city)
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
                form.SelectChooseFile();
                UploadFile.UploadFiles(pictureName);
                form.FillDateOfBirth("08 Aug 2021");
                form.SelectState(state);
                form.SelectCity(city);
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

    }
}

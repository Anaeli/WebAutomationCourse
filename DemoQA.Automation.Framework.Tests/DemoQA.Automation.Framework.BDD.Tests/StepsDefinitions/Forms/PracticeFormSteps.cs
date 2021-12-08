using DemoQA.Automation.Core.ReportManager;
using DemoQA.Automation.Core.Wrappers.Components;
using DemoQA.Automation.Framework.BDD.Tests.Entities;
using DemoQA.Automation.Framework.Core;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.BDD.Tests.StepsDefinitions.Forms
{
    [Binding]
    public class PracticeFormSteps: AutomationTestBase
    {
        private readonly AutomationClient client;
        private Student student;

        public PracticeFormSteps(ITestOutputHelper output): base(output)
        {
            client = AutomationClient.Instance;
        }
    

        [Given(@"I fill the fields on Practice Form:")]
        public void GivenIFillTheFieldsOnPracticeForm(Table table)
        {
            student = table.CreateInstance<Student>();
            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.NameTextBox.SetValue(student.Name);
                form.LastNameTextBox.SetValue(student.LastName);
                form.EmailTextBox.SetValue(student.Email);
                form.SelectGenderRadioButton(student.Gender);
                form.MobileNumberTextBox.SetValue(student.Mobile);
                form.SelectChooseFile();
                UploadFile.UploadFiles(student.Picture);
                form.FillDateOfBirth(student.DateOfBirth);
            });            
        }
        
        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton()
        {

            this.client.AutomateActivePage<PracticeFormWrapper>(form =>
            {
                form.SubmitButton.ClickUsingJS(client);
            });
        }
        
        [Then(@"table with submitted data should be displayed")]
        public void ThenTableWithSubmittedDataShouldBeDisplayed()
        {
            try
            {
                IEnumerable<string> tableInfo = TableComponentWrapper.Instance.GetTextList();
                Assert.Contains($"{TableLabels.StudentName} {student.Name} {student.LastName}", tableInfo);
                Assert.Contains($"{TableLabels.StudentEmail} {student.Email}", tableInfo);
                Assert.Contains($"{TableLabels.Mobile} {student.Mobile}", tableInfo);
                Assert.Contains($"{TableLabels.Picture} {student.Picture}", tableInfo);
                Assert.Contains($"{TableLabels.DateOfBirth} 08 August,2021", tableInfo);
                TestCase.SetTestPassed();
            }
            catch (Exception e)
            {
                TestCase.SetErrorMessage(e.Message);
                throw e;
            }
        }

        [Then(@"I should see the submitted data in the table")]
        public void ThenIShouldSeeTheSubmittedDataInTheTable(Table table)
        {
            student = table.CreateInstance<Student>();
            try
            {
                IEnumerable<string> tableInfo = TableComponentWrapper.Instance.GetTextList();
                Assert.Contains($"{TableLabels.StudentName} {student.Name} {student.LastName}", tableInfo);
                Assert.Contains($"{TableLabels.StudentEmail} {student.Email}", tableInfo);
                Assert.Contains($"{TableLabels.Mobile} {student.Mobile}", tableInfo);
                Assert.Contains($"{TableLabels.Picture} {student.Picture}", tableInfo);
                Assert.Contains($"{TableLabels.DateOfBirth} {student.DateOfBirth}", tableInfo);
                TestCase.SetTestPassed();
            }
            catch (Exception e)
            {
                TestCase.SetErrorMessage(e.Message);
                throw e;
            }
        }

    }
}

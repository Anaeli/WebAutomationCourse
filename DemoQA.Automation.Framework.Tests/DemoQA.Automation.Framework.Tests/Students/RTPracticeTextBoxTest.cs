using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Automation.Framework.Wrappers;
using Xunit;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace DemoQA.Automation.Framework.Tests
{
    public class RTPracticeTextBoxTest : IDisposable
    {
        
        private RTTextBoxFormWrapper practiceForm;

        public RTPracticeTextBoxTest()
        {
            this.practiceForm = new RTTextBoxFormWrapper();
        }

        [Theory]
        [InlineData("Eliana", "test@mail.com")]
        public void ValidateNameEmail(string name, string email)
        {
            practiceForm.GoToPage();            
            practiceForm.FullNameTextBox.SendKeys(name);
            practiceForm.EmailTextBox.SendKeys(email);

        }
        [Theory]
        [InlineData("Inej Cunumi", "test@mail.com", "av america", "Cochabamba")]
        public void ValidateTextBoxForm(string fullname, string email, string currentAddress, string permanentAddress)
        {
            practiceForm.GoToPage();
            practiceForm.FullNameTextBox.SendKeys(fullname);
            practiceForm.EmailTextBox.SendKeys(email);
            practiceForm.CurrentAddress.SendKeys(currentAddress);
            practiceForm.PermanentAddress.SendKeys(permanentAddress);
            practiceForm.SubmitButton.Click();
            
            Assert.Contains(fullname, practiceForm.OutputTable.Text);
            Assert.Contains(email, practiceForm.OutputTable.Text);
            Assert.Contains(currentAddress, practiceForm.OutputTable.Text);
            Assert.Contains(permanentAddress, practiceForm.OutputTable.Text);
        }

        [Theory]
        [InlineData("Inej Cunumi", "test", "av america", "Cochabamba")]
        public void ValidateEmailBorderRed(string fullname, string email, string currentAddress, string permanentAddress)
        {
            practiceForm.GoToPage();
            practiceForm.FullNameTextBox.SendKeys(fullname);
            practiceForm.EmailTextBox.SendKeys(email);
            practiceForm.CurrentAddress.SendKeys(currentAddress);
            practiceForm.PermanentAddress.SendKeys(permanentAddress);
            practiceForm.SubmitButton.Click();
            Assert.Contains("rgb(255, 0, 0)", practiceForm.EmailTextBox.GetCssValue("border"));
            
        }

       
        public void Dispose()
        {
            practiceForm.QuitDriver();
        }
        
    }
}

using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Wrappers.RCPBookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.RCPBookStore
{
    class TC4
    {
        private RCPBookStoreApplicationWrapper rcpBookStoreApplicationWrapper;
        public TC4(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rcpBookStoreApplicationWrapper = new RCPBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("RCPQA", "Control123@")]
        public void VerifyTestCase4Implementation(string aUserName, string aPassword)
        {
            //1. Create a user by API.
            User user = new User
            {
                userName = aUserName,
                password = aPassword
            };
            string userID = user.AddUserByApi(user);
            Thread.Sleep(3000); // wait for the API to create the user

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //2. Login with user.
            rcpBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rcpBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rcpBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.LogoutButton));

            //3. Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.DeleteAccountButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.ModalOKButton));
            rcpBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            //4. Verify in the login.
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.LoginButton));
            rcpBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rcpBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rcpBookStoreApplicationWrapper.LoginButton.Click();
            Assert.True(rcpBookStoreApplicationWrapper.InvalidUserOrPassMessage.Displayed);
        }
    }
}


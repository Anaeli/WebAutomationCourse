using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Wrappers.BookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.BookStore
{
    public class JCATestCase4 : AutomationTestBase
    {
        private JCABookStoreApplicationWrapper jcaBookStoreApplicationWrapper;
        public JCATestCase4(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.jcaBookStoreApplicationWrapper = new JCABookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("jcruz", "Control123@")]
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
            jcaBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            jcaBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            jcaBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.LogoutButton));

            //3. Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.DeleteAccountButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.ModalOKButton));
            jcaBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            //4. Verify in the login.
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.LoginButton));
            jcaBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            jcaBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            jcaBookStoreApplicationWrapper.LoginButton.Click();
            Assert.True(jcaBookStoreApplicationWrapper.InvalidUserOrPassMessage.Displayed);
        }
    }
}


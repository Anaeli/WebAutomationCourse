using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Wrappers.BookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.BookStore
{
    public class RTTC4 : AutomationTestBase
    {
        private RTBookStoreApplicationWrapper rtBookStoreApplicationWrapper;
        public RTTC4(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rtBookStoreApplicationWrapper = new RTBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Ruddy", "Control123*")]
        public void TestCase4(string aUserName, string aPassword)
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
            rtBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rtBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rtBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.LogoutButton));

            //3. Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.DeleteAccountButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            rtBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.ModalOKButton));
            rtBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            //4. Verify in the login.
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.LoginButton));
            rtBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rtBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rtBookStoreApplicationWrapper.LoginButton.Click();
            Assert.True(rtBookStoreApplicationWrapper.InvalidUserOrPassMessage.Displayed);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RestSharp;
using RestSharp.Authenticators;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Utilities;
using Xunit.Abstractions;
using System.Threading;
using OpenQA.Selenium;

namespace DemoQA.Automation.Framework.Tests.MCBookStore
{
    public class BookStoreLoginTest : AutomationTestBase
    {
        public BookStoreLoginTest(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            BookStoreAPI accountAPI = new BookStoreAPI();
            accountAPI.PostUser();
            this.client.GoToPage("https://demoqa.com/login");
        }

        //This is a preliminary test of login and account deletion steps
        [Theory]
        [InlineData("TandyMiller", "Contr0l-123*/")]
        public void LoginTestUI(string username, string password)
        {
            this.client.AutomateActivePage<MCBookStoreWrapper>(form =>
            {
                Thread.Sleep(3000);
                IJavaScriptExecutor jScript = (IJavaScriptExecutor)driver;

                //Login
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                Thread.Sleep(2000);
                jScript.ExecuteScript("window.scrollBy(0,900)");

                //Delete Account via UI
                form.DeleteAccountButtonX.Click();
                Thread.Sleep(2000);
                form.CloseSmallModalButton.Click();
                Thread.Sleep(2000);
                IAlert deletedAccountAlert = driver.SwitchTo().Alert();
                deletedAccountAlert.Accept();
            });
        }        
    }
}

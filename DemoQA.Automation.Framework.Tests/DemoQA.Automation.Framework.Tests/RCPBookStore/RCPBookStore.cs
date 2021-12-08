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
    public class RCPBookStore : AutomationTestBase
    {
        private RCPBookStoreApplicationWrapper rcpBookStoreApplicationWrapper;

        public RCPBookStore(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rcpBookStoreApplicationWrapper = new RCPBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("RCPQA", "Control123@")]
        public void VerifyBookStoreWorkflow(string userName, string password)
        {
            User user = new User
            {
                userName = userName,
                password = password
            };
            string userID = user.AddUserByApi(user);

            Thread.Sleep(3000); // wait for the API to create the user
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Login
            rcpBookStoreApplicationWrapper.UserNameTextBox.SendKeys(userName);
            rcpBookStoreApplicationWrapper.PasswordTextBox.SendKeys(password);
            rcpBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.BookStoreButton.Click();

            //Add Book1
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.GitPocketGuideLink));
            rcpBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            rcpBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            //Add Book2
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink));
            rcpBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            rcpBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            //Add Book3
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink));
            rcpBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            rcpBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            //Check if books were added
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.ProfileButton.Click();
            Assert.Contains("Git Pocket Guide", rcpBookStoreApplicationWrapper.GitPocketGuideLink.Text);
            Assert.Contains("Learning JavaScript Design Pattern", rcpBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink.Text);
            Assert.Contains("Designing Evolvable Web APIs", rcpBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink.Text);

            //Delete Git Pocket Guide book
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.DeleteGitPocketGuideButton));
            rcpBookStoreApplicationWrapper.DeleteGitPocketGuideButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.ModalOKButton));
            rcpBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            // Check if single book was deleted
            try
            {
                string bookIsPresent = rcpBookStoreApplicationWrapper.GitPocketGuideLink.Text;
                if (bookIsPresent != null)
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                //Test continues
            }

            //Delete all books
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.DeleteAllBooksButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.ModalOKButton));
            rcpBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent()); ;
            alert.Accept();
            Assert.True(rcpBookStoreApplicationWrapper.NoRowsFoundMessage.Displayed);

            //Delete Account
            rcpBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.ModalOKButton));
            rcpBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}


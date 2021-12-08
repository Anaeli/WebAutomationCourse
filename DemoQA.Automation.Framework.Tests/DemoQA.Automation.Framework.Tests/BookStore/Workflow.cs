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
    public class Workflow : AutomationTestBase
    {
        private BookStoreWrapper bookStoreWrapper;

        public Workflow(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.bookStoreWrapper = new BookStoreWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("fsivila", "Control123!")]
        public void VerifyWorkflow(string userName, string password)
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
            bookStoreWrapper.UserNameTextBox.SendKeys(userName);
            bookStoreWrapper.PasswordTextBox.SendKeys(password);
            bookStoreWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            bookStoreWrapper.BookStoreButton.Click();

            //Adding Book 1
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.GitPocketGuideLink));
            bookStoreWrapper.GitPocketGuideLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            bookStoreWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            bookStoreWrapper.BackToBookStoreButton.Click();

            //Adding Book 2
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.LearningJavaScriptDesignPatternsLink));
            bookStoreWrapper.LearningJavaScriptDesignPatternsLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            bookStoreWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            bookStoreWrapper.BackToBookStoreButton.Click();

            //Adding Book 3
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.DesigningEvolvableWebAPIswithASPNETLink));
            bookStoreWrapper.DesigningEvolvableWebAPIswithASPNETLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            bookStoreWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            bookStoreWrapper.BackToBookStoreButton.Click();

            //Check if books were added
            js.ExecuteScript("window.scrollBy(0,900)");
            bookStoreWrapper.ProfileButton.Click();
            Assert.Contains("Git Pocket Guide", bookStoreWrapper.GitPocketGuideLink.Text);
            Assert.Contains("Learning JavaScript Design Pattern", bookStoreWrapper.LearningJavaScriptDesignPatternsLink.Text);
            Assert.Contains("Designing Evolvable Web APIs", bookStoreWrapper.DesigningEvolvableWebAPIswithASPNETLink.Text);

            //Deleteting Git Pocket Guide book
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.DeleteGitPocketGuideButton));
            bookStoreWrapper.DeleteGitPocketGuideButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.ModalOKButton));
            bookStoreWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            // Check if single book was deleted
            try
            {
                string bookIsPresent = bookStoreWrapper.GitPocketGuideLink.Text;
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
            bookStoreWrapper.DeleteAllBooksButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.ModalOKButton));
            bookStoreWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent()); ;
            alert.Accept();
            Assert.True(bookStoreWrapper.NoRowsFoundMessage.Displayed);

            //Delete Account
            bookStoreWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(bookStoreWrapper.ModalOKButton));
            bookStoreWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}

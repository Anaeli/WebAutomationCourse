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
    public class JCABookStoreWorkflowTest : AutomationTestBase
    {
        private JCABookStoreApplicationWrapper jcaBookStoreApplicationWrapper;

        public JCABookStoreWorkflowTest(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.jcaBookStoreApplicationWrapper = new JCABookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("jcruz", "Control123@")]
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
            jcaBookStoreApplicationWrapper.UserNameTextBox.SendKeys(userName);
            jcaBookStoreApplicationWrapper.PasswordTextBox.SendKeys(password);
            jcaBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.BookStoreButton.Click();

            //Adding Book 1
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.GitPocketGuideLink));
            jcaBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            jcaBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            //Adding Book 2
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink));
            jcaBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            jcaBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            //Adding Book 3
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink));
            jcaBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            jcaBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            //Check if books were added
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.ProfileButton.Click();
            Assert.Contains("Git Pocket Guide", jcaBookStoreApplicationWrapper.GitPocketGuideLink.Text);
            Assert.Contains("Learning JavaScript Design Pattern", jcaBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink.Text);
            Assert.Contains("Designing Evolvable Web APIs", jcaBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink.Text);

            //Deleteting Git Pocket Guide book
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.DeleteGitPocketGuideButton));
            jcaBookStoreApplicationWrapper.DeleteGitPocketGuideButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.ModalOKButton));
            jcaBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            // Check if single book was deleted
            try
            {
                string bookIsPresent = jcaBookStoreApplicationWrapper.GitPocketGuideLink.Text;
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
            jcaBookStoreApplicationWrapper.DeleteAllBooksButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.ModalOKButton));
            jcaBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent()); ;
            alert.Accept();
            Assert.True(jcaBookStoreApplicationWrapper.NoRowsFoundMessage.Displayed);

            //Delete Account
            jcaBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.ModalOKButton));
            jcaBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}

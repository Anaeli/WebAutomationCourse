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
    public class RTBookStoreWorkFlowTest : AutomationTestBase
    {
        private RTBookStoreApplicationWrapper rtBookStoreApplicationWrapper;

        public RTBookStoreWorkFlowTest(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rtBookStoreApplicationWrapper = new RTBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Ruddy", "Control123**")]
        public void VerifyBookStoreWorkflow(string userName, string password)
        {
            User user = new User
            {
                userName = userName,
                password = password
            };
            string userID = user.AddUserByApi(user);

            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;


            rtBookStoreApplicationWrapper.UserNameTextBox.SendKeys(userName);
            rtBookStoreApplicationWrapper.PasswordTextBox.SendKeys(password);
            rtBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.LogoutButton));
            rtBookStoreApplicationWrapper.BookStoreButton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.GitPocketGuideLink));
            rtBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            rtBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            rtBookStoreApplicationWrapper.BackToBookStoreButton.Click();

            
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink));
            rtBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink.Click();
            
            rtBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            rtBookStoreApplicationWrapper.BackToBookStoreButton.Click();

           
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink));
            rtBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink.Click();
            
            rtBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            rtBookStoreApplicationWrapper.BackToBookStoreButton.Click();
                        
            rtBookStoreApplicationWrapper.ProfileButton.Click();
            Assert.Contains("Git Pocket Guide", rtBookStoreApplicationWrapper.GitPocketGuideLink.Text);
            Assert.Contains("Learning JavaScript Design Pattern", rtBookStoreApplicationWrapper.LearningJavaScriptDesignPatternsLink.Text);
            Assert.Contains("Designing Evolvable Web APIs", rtBookStoreApplicationWrapper.DesigningEvolvableWebAPIswithASPNETLink.Text);

            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.DeleteGitPocketGuideButton));
            rtBookStoreApplicationWrapper.DeleteGitPocketGuideButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.ModalOKButton));
            rtBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();

            try
            {
                string bookIsPresent = rtBookStoreApplicationWrapper.GitPocketGuideLink.Text;
                if (bookIsPresent != null)
                {
                    throw new ArgumentException();
                }
            }
            catch { }
                                  
            
            rtBookStoreApplicationWrapper.DeleteAllBooksButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.ModalOKButton));
            rtBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent()); ;
            alert.Accept();
            Assert.True(rtBookStoreApplicationWrapper.NoRowsFoundMessage.Displayed);

            
            rtBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.ModalOKButton));
            rtBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}

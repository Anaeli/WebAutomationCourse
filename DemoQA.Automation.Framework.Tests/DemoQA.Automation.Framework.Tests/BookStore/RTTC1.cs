using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.API.Tests.Entities;
using DemoQA.Automation.Framework.Wrappers.BookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.BookStore
{
    public class RTTC1 : AutomationTestBase
    {
        private RTBookStoreApplicationWrapper rtBookStoreApplicationWrapper;

        public RTTC1(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rtBookStoreApplicationWrapper = new RTBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Ruddy", "Control123**")]
        public void TestCase1(string aUserName, string aPassword)
        {
            
            User user = new User
            {
                userName = aUserName,
                password = aPassword
            };
            string userID = user.AddUserByApi(user);
                        
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            rtBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rtBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rtBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.LogoutButton));            
            rtBookStoreApplicationWrapper.ProfileButton.Click();
            rtBookStoreApplicationWrapper.GoToBookStoreButton.Click();

            
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.GitPocketGuideLink));
            rtBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.AddToYourCollectionButton));
            rtBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("Book added to your collection.", alert.Text);
            alert.Accept();
            
            rtBookStoreApplicationWrapper.ProfileButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.GitPocketGuideLink));
            Assert.Contains("Git Pocket Guide", rtBookStoreApplicationWrapper.GitPocketGuideLink.Text);
            rtBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            
            Assert.Equal("9781449325862", rtBookStoreApplicationWrapper.IsbnValue.Text);
            Assert.Equal("Git Pocket Guide", rtBookStoreApplicationWrapper.TitleValue.Text);
            Assert.Equal("A Working Introduction", rtBookStoreApplicationWrapper.SubTitleValue.Text);
            Assert.Equal("Richard E. Silverman", rtBookStoreApplicationWrapper.AuthorValue.Text);
            Assert.Equal("O'Reilly Media", rtBookStoreApplicationWrapper.PublisherValue.Text);
            Assert.Equal("234", rtBookStoreApplicationWrapper.TotalPagesValue.Text);
            Assert.StartsWith("This pocket guide is the perfect on-the-job companion to Git", rtBookStoreApplicationWrapper.DescriptionValue.Text);
            Assert.Equal("http://chimera.labs.oreilly.com/books/1230000000561/index.html", rtBookStoreApplicationWrapper.WebsiteValue.Text);
                                   
            rtBookStoreApplicationWrapper.BookStoreButton.Click();
            rtBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            rtBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.Equal("Book already present in the your collection!", alert.Text);
            alert.Accept();

            //6.Delete the book by API.
            var client = new RestClient("https://demoqa.com")
            {
                Authenticator = new HttpBasicAuthenticator(aUserName, aPassword)
            };
            var request = new RestRequest("/BookStore/v1/Book", Method.DELETE);
            RelationshipBookUser bookUser = new RelationshipBookUser
            {
                userId = user.userId,
                isbn = "9781449325862"
            };
            request.AddJsonBody(bookUser);
            client.Execute(request);
            js.ExecuteScript("window.scrollBy(0,900)");
            rtBookStoreApplicationWrapper.ProfileButton.Click();
            Assert.True(rtBookStoreApplicationWrapper.NoRowsFoundMessage.Displayed);

            //7.Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.DeleteAccountButton));
            rtBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.ModalOKButton));
            rtBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}

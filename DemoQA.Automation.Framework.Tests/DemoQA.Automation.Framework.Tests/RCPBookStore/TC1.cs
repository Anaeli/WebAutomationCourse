using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.API.Tests.Entities;
using DemoQA.Automation.Framework.Wrappers.RCPBookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
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
    public class TC1 : AutomationTestBase
    {

        private RCPBookStoreApplicationWrapper rcpBookStoreApplicationWrapper;

        public TC1(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rcpBookStoreApplicationWrapper = new RCPBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("RCPQA", "Control123@")]
        public void VerifyTestCase1Implementation(string aUserName, string aPassword)
        {
            //1.  Insert the user by API.
            User user = new User
            {
                userName = aUserName,
                password = aPassword
            };
            string userID = user.AddUserByApi(user);

            Thread.Sleep(3000); // wait for the API to create the user
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //2.   Login into the app.
            rcpBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rcpBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rcpBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.ProfileButton.Click();
            rcpBookStoreApplicationWrapper.GoToBookStoreButton.Click();

            //3. Go to Book Store > Add to your collection 1 book verify all the alerts included the book grid.
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.GitPocketGuideLink));
            rcpBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.AddToYourCollectionButton));
            rcpBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("Book added to your collection.", alert.Text);
            alert.Accept();

            //4.Verify the book link and verify their information.
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.ProfileButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.GitPocketGuideLink));
            Assert.Contains("Git Pocket Guide", rcpBookStoreApplicationWrapper.GitPocketGuideLink.Text);
            rcpBookStoreApplicationWrapper.GitPocketGuideLink.Click();

            //Validate book details information
            Assert.Equal("9781449331818", rcpBookStoreApplicationWrapper.IsbnValue.Text);
            Assert.Equal("Learning JavaScript Design Patterns", rcpBookStoreApplicationWrapper.TitleValue.Text);
            Assert.Equal("A JavaScript and jQuery Developer's Guide", rcpBookStoreApplicationWrapper.SubTitleValue.Text);
            Assert.Equal("Addy Osmani", rcpBookStoreApplicationWrapper.AuthorValue.Text);
            Assert.Equal("O'Reilly Media", rcpBookStoreApplicationWrapper.PublisherValue.Text);
            Assert.Equal("254", rcpBookStoreApplicationWrapper.TotalPagesValue.Text);
            Assert.StartsWith("With Learning JavaScript Design Patterns, you'll learn how to write beautiful, structured, and maintainable JavaScript by applying classical and modern design patterns to the language. If you want to keep your code efficient, more manageable, and up-to-da", rcpBookStoreApplicationWrapper.DescriptionValue.Text);
            Assert.Equal("https://addyosmani.com/resources/essentialjsdesignpatterns/book/", rcpBookStoreApplicationWrapper.WebsiteValue.Text);

            //5.Try to include the same book and validate alert.
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.BookStoreButton.Click();
            rcpBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            rcpBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
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
                isbn = "9781449331818"
            };
            request.AddJsonBody(bookUser);
            client.Execute(request);
            js.ExecuteScript("window.scrollBy(0,900)");
            rcpBookStoreApplicationWrapper.ProfileButton.Click();
            Assert.True(rcpBookStoreApplicationWrapper.NoRowsFoundMessage.Displayed);

            //7.Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.DeleteAccountButton));
            rcpBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rcpBookStoreApplicationWrapper.ModalOKButton));
            rcpBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}


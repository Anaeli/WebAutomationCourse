using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.API.Tests.Entities;
using DemoQA.Automation.Framework.Wrappers.BookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.BookStore
{
    public class JCATestCase1 : AutomationTestBase
    {
        private JCABookStoreApplicationWrapper jcaBookStoreApplicationWrapper;

        public JCATestCase1(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.jcaBookStoreApplicationWrapper = new JCABookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("jcruz", "Control123@")]
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
            jcaBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            jcaBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            jcaBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.ProfileButton.Click();
            jcaBookStoreApplicationWrapper.GoToBookStoreButton.Click();

            //3. Go to Book Store > Add to your collection 1 book verify all the alerts included the book grid.
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.GitPocketGuideLink));
            jcaBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.AddToYourCollectionButton));
            jcaBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            Assert.Equal("Book added to your collection.", alert.Text);
            alert.Accept();

            //4.Verify the book link and verify their information.
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.ProfileButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.GitPocketGuideLink));
            Assert.Contains("Git Pocket Guide", jcaBookStoreApplicationWrapper.GitPocketGuideLink.Text);
            jcaBookStoreApplicationWrapper.GitPocketGuideLink.Click();

            //Validate book details information
            Assert.Equal("9781449325862", jcaBookStoreApplicationWrapper.IsbnValue.Text);
            Assert.Equal("Git Pocket Guide", jcaBookStoreApplicationWrapper.TitleValue.Text);
            Assert.Equal("A Working Introduction", jcaBookStoreApplicationWrapper.SubTitleValue.Text);
            Assert.Equal("Richard E. Silverman", jcaBookStoreApplicationWrapper.AuthorValue.Text);
            Assert.Equal("O'Reilly Media", jcaBookStoreApplicationWrapper.PublisherValue.Text);
            Assert.Equal("234", jcaBookStoreApplicationWrapper.TotalPagesValue.Text);
            Assert.StartsWith("This pocket guide is the perfect on-the-job companion to Git", jcaBookStoreApplicationWrapper.DescriptionValue.Text);
            Assert.Equal("http://chimera.labs.oreilly.com/books/1230000000561/index.html", jcaBookStoreApplicationWrapper.WebsiteValue.Text);

            //5.Try to include the same book and validate alert.
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.BookStoreButton.Click();
            jcaBookStoreApplicationWrapper.GitPocketGuideLink.Click();
            jcaBookStoreApplicationWrapper.AddToYourCollectionButton.Click();
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
            jcaBookStoreApplicationWrapper.ProfileButton.Click();
            Assert.True(jcaBookStoreApplicationWrapper.NoRowsFoundMessage.Displayed);

            //7.Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.DeleteAccountButton));
            jcaBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.ModalOKButton));
            jcaBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}

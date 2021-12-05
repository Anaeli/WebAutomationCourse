using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Wrappers.BookStore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.BookStore
{
    public class JCATestCase2 : AutomationTestBase
    {
        private JCABookStoreApplicationWrapper jcaBookStoreApplicationWrapper;

        public JCATestCase2(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.jcaBookStoreApplicationWrapper = new JCABookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("jcruz", "Control123@", "9781449325862", "9781449331818", "9781449337711", "9781449365035", "9781491904244", "9781491950296", "9781593275846")]
        public void VerifyTestCase2Implementation(string aUserName, string aPassword, string aBook1, string aBook2, string aBook3, string aBook4, string aBook5, string aBook6, string aBook7)
        {
            //1. Insert the user by API.
            User user = new User
            {
                userName = aUserName,
                password = aPassword
            };
            string userID = user.AddUserByApi(user);
            Thread.Sleep(3000); // wait for the API to create the user

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //2. Using API insert at least 7 books.
            var client = new RestClient("https://demoqa.com")
            {
                Authenticator = new HttpBasicAuthenticator(aUserName, aPassword)
            };
            var request = new RestRequest("/BookStore/v1/Books", Method.POST);
            Book book1 = new Book
            {
                isbn = aBook1
            };

            Book book2 = new Book
            {
                isbn = aBook2
            };

            Book book3 = new Book
            {
                isbn = aBook3
            };

            Book book4 = new Book
            {
                isbn = aBook4
            };

            Book book5 = new Book
            {
                isbn = aBook5
            };

            Book book6 = new Book
            {
                isbn = aBook6
            };

            Book book7 = new Book
            {
                isbn = aBook7
            };

            User user2 = new User
            {
                userId = user.userId,
                collectionOfIsbns = new List<Book>()
                {
                    book1,
                    book2,
                    book3,
                    book4,
                    book5,
                    book6,
                    book7
                }
            };
            request.AddJsonBody(user2);
            client.Execute(request);

            //3. Change the rows number to change the rows number view and verify.
            jcaBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            jcaBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            jcaBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            jcaBookStoreApplicationWrapper.ProfileButton.Click();
            jcaBookStoreApplicationWrapper.PageSizeSelector.Click();
            jcaBookStoreApplicationWrapper.PageSize10Rows.Click();
            js.ExecuteScript("window.scrollBy(0,900)");
            Assert.Contains("Git Pocket Guide", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook1}')]")).Text);
            Assert.Contains("Learning JavaScript Design Patterns", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook2}')]")).Text);
            Assert.Contains("Designing Evolvable Web APIs with ASP.NET", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook3}')]")).Text);
            Assert.Contains("Speaking JavaScript", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook4}')]")).Text);
            Assert.Contains("You Don't Know JS", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook5}')]")).Text);
            Assert.Contains("Programming JavaScript Applications", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook6}')]")).Text);
            Assert.Contains("Eloquent JavaScript, Second Edition", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook7}')]")).Text);

            //4. Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.DeleteAccountButton));
            jcaBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(jcaBookStoreApplicationWrapper.ModalOKButton));
            jcaBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}

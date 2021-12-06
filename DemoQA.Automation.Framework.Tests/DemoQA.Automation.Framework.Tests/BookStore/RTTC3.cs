using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoQA.Automation.Framework.API.Tests;
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
    public class RTTC3 : AutomationTestBase
    {
        private RTBookStoreApplicationWrapper rtBookStoreApplicationWrapper;
        public RTTC3(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.rtBookStoreApplicationWrapper = new RTBookStoreApplicationWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Ruddy", "Control123*", "9781449325862", "9781449331818", "9781449337711", "9781449365035", "9781491904244", "9781491950296", "9781593275846")]
        public void TestCase3(string aUserName, string aPassword, string aBook1, string aBook2, string aBook3, string aBook4, string aBook5, string aBook6, string aBook7)
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

            //3. Search a book and validate the result.
            rtBookStoreApplicationWrapper.UserNameTextBox.SendKeys(aUserName);
            rtBookStoreApplicationWrapper.PasswordTextBox.SendKeys(aPassword);
            rtBookStoreApplicationWrapper.LoginButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.LogoutButton));
            js.ExecuteScript("window.scrollBy(0,900)");
            rtBookStoreApplicationWrapper.ProfileButton.Click();
            rtBookStoreApplicationWrapper.SearchBox.SendKeys("You Don't Know JS");
            Assert.Contains("You Don't Know JS", driver.FindElement(By.XPath($"//a[contains(@href , '{aBook5}')]")).Text);
            // Check if only filtered book is visible
            try
            {
                string bookIsPresent = driver.FindElement(By.XPath($"//a[contains(@href , '{aBook1}')]")).Text;
                if (bookIsPresent != null)
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                //Test continues
            }

            //4. Delete the account by UI.
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.DeleteAccountButton));
            rtBookStoreApplicationWrapper.DeleteAccountButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(rtBookStoreApplicationWrapper.ModalOKButton));
            rtBookStoreApplicationWrapper.ModalOKButton.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}

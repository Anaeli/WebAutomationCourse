using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Tests.Client;
using DemoQA.Automation.Framework.Wrappers.BookStore.Login;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.BookStore.Login
{
    public class ECRBookStoreTests : AutomationTestBase, IDisposable
    {
        private readonly RestClient Api;
        private User apiUser;
        private User user;
        private string username = "";
        private string userpass = "";

        public ECRBookStoreTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.client.GoToPage(URLsList.BookURL);
            Api = new RestClient(URLsList.ApiURL);
            apiUser = new User();
            init();
        }

        public void init()
        {
            User user = new User
            {
                userName = "ebert2",
                password = "Control123!"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = Api.Execute<User>(request);
            User userResult = queryResult.Data;
            apiUser.userId = userResult.userId;
            apiUser.userName = userResult.userName;
            apiUser.password = user.password;
        }

        //Implement the workflow
        [Fact]
        public void ImplementTheWorkflow()
        {
            this.client.AutomateActivePage<ECRBookStoreWrappers>(form =>
            {
                username = apiUser.userName;
                userpass = apiUser.password;

                form.UserName.SendKeys(username);
                form.Password.SendKeys(userpass);
                form.SubmintButton.ClickUsingJS(client);

                //Go to Book Store.
                form.GoToBookStore.Click();
                Thread.Sleep(3000);

                //Add to your collection at least 3 books (verify the book list)
                //Book 1 added
                form.BookStore1.Click();
                form.AddBookStore.Click();
                Thread.Sleep(6000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                Thread.Sleep(6000);
                form.BackToBookStore.Click();

                //Book 2 added
                form.BookStore2.Click();
                form.AddBookStore.Click();
                Thread.Sleep(6000);
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait2.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert2 = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert2.Text);
                alert2.Accept();
                Thread.Sleep(6000);
                form.BackToBookStore.Click();

                //Book 3 added
                form.BookStore3.Click();
                form.AddBookStore.Click();
                Thread.Sleep(6000);
                WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait3.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert3 = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert3.Text);
                alert3.Accept();
                Thread.Sleep(6000);

                //Go Profile
                driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
                Thread.Sleep(3000);
                form.Profile.Click();
                
                //Checking the 3 books added
                Assert.Equal("Git Pocket Guide", driver.FindElement(By.XPath("//a[text()='Git Pocket Guide']")).Text);
                Assert.Equal("Learning JavaScript Design Patterns", driver.FindElement(By.XPath("//a[text()='Learning JavaScript Design Patterns']")).Text);
                Assert.Equal("Designing Evolvable Web APIs with ASP.NET", driver.FindElement(By.XPath("//a[text()='Designing Evolvable Web APIs with ASP.NET']")).Text);

                //Delete a book and validate it (Verify the book list)
                form.DeleteBook.Click();
                Thread.Sleep(3000);
                form.Ok.Click();
                WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait4.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert4 = driver.SwitchTo().Alert();
                alert4.Accept();

                //Delete All Books and validate the acction
                form.DeleteAllBooks.Click();
                Thread.Sleep(3000);
                form.Ok.Click();
                WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait5.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert5 = driver.SwitchTo().Alert();
                alert5.Accept();
                Assert.Equal("No rows found", driver.FindElement(By.XPath("//div[text()='No rows found']")).Text);
            });
        }

        //TC1
        [Fact]
        public void TC1 ()
        {
            this.client.AutomateActivePage<ECRBookStoreWrappers>(form =>
            {
                username = apiUser.userName;
                userpass = apiUser.password;

                form.UserName.SendKeys(username);
                form.Password.SendKeys(userpass);
                form.SubmintButton.ClickUsingJS(client);

                //Go to Book Store.
                form.GoToBookStore.Click();
                Thread.Sleep(3000);

                //Add to your collection 1 book verify all the alerts included the book grid.
                form.BookStore1.Click();
                form.AddBookStore.Click();
                Thread.Sleep(6000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                Thread.Sleep(6000);

                //Verify the book link and verify their information.
                Assert.Contains("http://chimera.labs.oreilly.com/books/1230000000561/index.html", driver.FindElement(By.XPath("//label[text()='http://chimera.labs.oreilly.com/books/1230000000561/index.html']")).Text);
                Assert.Equal("9781449325862", driver.FindElement(By.XPath("//label[text()='9781449325862']")).Text);
                Assert.Equal("Git Pocket Guide", driver.FindElement(By.XPath("//label[text()='Git Pocket Guide']")).Text);
                Assert.Equal("Richard E. Silverman", driver.FindElement(By.XPath("//label[text()='Richard E. Silverman']")).Text);
                
                //Try to include the same book and validate alert.
                form.AddBookStore.Click();
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait2.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert2 = driver.SwitchTo().Alert();
                Assert.Equal("Book already present in the your collection!", alert2.Text);
                alert2.Accept();
                driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
                Thread.Sleep(3000);
                form.Profile.Click();

                //Delete the Bok by API
                Api.Authenticator = new HttpBasicAuthenticator("ebert2", "Control123!");
                var request1 = new RestRequest("/BookStore/v1/Book", Method.DELETE);
                Book bookDelete = new Book
                {
                    isbn = "9781449325862"
                };
                user = new User
                {
                    userId = apiUser.userId,
                    collectionOfIsbns = new List<Book>()
                    {
                    bookDelete,
                    }
                };
                request1.AddJsonBody(user);
                IRestResponse queryResult1 = Api.Execute(request1);
            });
        }

        //TC2
        [Fact]
        public void TC2 ()
        {
            //Using API insert at least 7 books.
            Api.Authenticator = new HttpBasicAuthenticator("ebert2", "Control123!");
            var request1 = new RestRequest("/BookStore/v1/Books", Method.POST);
            Book book1 = new Book
            {
                isbn = "9781449325862"
            };
            Book book2 = new Book
            {
                isbn = "9781449331818"
            };
            Book book3 = new Book
            {
                isbn = "9781449337711"
            };
            Book book4 = new Book
            {
                isbn = "9781449365035"
            };
            Book book5 = new Book
            {
                isbn = "9781491904244"
            };
            Book book6 = new Book
            {
                isbn = "9781491950296"
            };
            Book book7 = new Book
            {
                isbn = "9781593275846"
            };

            user = new User
            {
                userId = apiUser.userId,
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

            request1.AddJsonBody(user);
            IRestResponse queryResult1 = Api.Execute(request1);
            Assert.True(queryResult1.IsSuccessful, "The request finished with errors");
            Assert.Equal("Created", queryResult1.StatusCode.ToString());
            Assert.Equal("Completed", queryResult1.ResponseStatus.ToString());

            //Change the rows number to change the rows number view and verify
            this.client.AutomateActivePage<ECRBookStoreWrappers>(form =>
            {
                username = apiUser.userName;
                userpass = apiUser.password;

                form.UserName.SendKeys(username);
                form.Password.SendKeys(userpass);
                form.SubmintButton.ClickUsingJS(client);
                Thread.Sleep(6000);
                driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
                Thread.Sleep(3000);
                form.Rows.Click();
                Thread.Sleep(5000);
                form.Row10.Click();
                Thread.Sleep(5000);
                Assert.Equal("Git Pocket Guide", driver.FindElement(By.XPath("//a[text()='Git Pocket Guide']")).Text);
                Assert.Equal("Learning JavaScript Design Patterns", driver.FindElement(By.XPath("//a[text()='Learning JavaScript Design Patterns']")).Text);
                Assert.Equal("Designing Evolvable Web APIs with ASP.NET", driver.FindElement(By.XPath("//a[text()='Designing Evolvable Web APIs with ASP.NET']")).Text);
                Assert.Equal("Speaking JavaScript", driver.FindElement(By.XPath("//a[text()='Speaking JavaScript']")).Text);
                //Author exception, because there is an error for "You Don't Know JS" - '
                Assert.Equal("Kyle Simpson", driver.FindElement(By.XPath("//div[text()='Kyle Simpson']")).Text);
                //
                Assert.Equal("Programming JavaScript Applications", driver.FindElement(By.XPath("//a[text()='Programming JavaScript Applications']")).Text);
                Assert.Equal("Eloquent JavaScript, Second Edition", driver.FindElement(By.XPath("//a[text()='Eloquent JavaScript, Second Edition']")).Text);
            });
        }
        //TC3
        [Theory]
        [InlineData("Speaking JavaScript")]
        public void TC3(string search)
        {
            //Using API insert at least 7 books.
            Api.Authenticator = new HttpBasicAuthenticator("ebert2", "Control123!");
            var request1 = new RestRequest("/BookStore/v1/Books", Method.POST);
            Book book1 = new Book
            {
                isbn = "9781449325862"
            };
            Book book2 = new Book
            {
                isbn = "9781449331818"
            };
            Book book3 = new Book
            {
                isbn = "9781449337711"
            };
            Book book4 = new Book
            {
                isbn = "9781449365035"
            };
            Book book5 = new Book
            {
                isbn = "9781491904244"
            };
            Book book6 = new Book
            {
                isbn = "9781491950296"
            };
            Book book7 = new Book
            {
                isbn = "9781593275846"
            };

            user = new User
            {
                userId = apiUser.userId,
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

            request1.AddJsonBody(user);
            IRestResponse queryResult1 = Api.Execute(request1);
            Assert.True(queryResult1.IsSuccessful, "The request finished with errors");
            Assert.Equal("Created", queryResult1.StatusCode.ToString());
            Assert.Equal("Completed", queryResult1.ResponseStatus.ToString());

            //Search a book and validate the result.
            this.client.AutomateActivePage<ECRBookStoreWrappers>(form =>
            {
                username = apiUser.userName;
                userpass = apiUser.password;
                form.UserName.SendKeys(username);
                form.Password.SendKeys(userpass);
                form.SubmintButton.ClickUsingJS(client);
                Thread.Sleep(3000);
                form.SearchText.SendKeys(search);
                Thread.Sleep(10000);
                Assert.Equal("Speaking JavaScript", driver.FindElement(By.XPath("//a[text()='Speaking JavaScript']")).Text);
            });
        }
        //TC4
        [Fact]
        public void TC4()
        {
            this.client.AutomateActivePage<ECRBookStoreWrappers>(form =>
            {
                //Login with user
                username = apiUser.userName;
                userpass = apiUser.password;

                form.UserName.SendKeys(username);
                form.Password.SendKeys(userpass);
                form.SubmintButton.ClickUsingJS(client);
                Thread.Sleep(3000);

                //Delete the account by UI
                driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
                Thread.Sleep(3000);
                form.DeleteAccount.Click();
                Thread.Sleep(3000);
                form.Ok.Click();
                WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait4.Until(ExpectedConditions.AlertIsPresent());
                IAlert alert4 = driver.SwitchTo().Alert();
                alert4.Accept();

                //Verify in the login
                form.UserName.SendKeys(username);
                form.Password.SendKeys(userpass);
                form.SubmintButton.ClickUsingJS(client);
                Thread.Sleep(6000);
                Assert.Equal("Invalid username or password!", driver.FindElement(By.Id("name")).Text);
            });
        }

        public void Dispose()
         {
            this.client.AutomateActivePage<ECRBookStoreWrappers>(form =>
              {
                 //Delete the account by UI
                  driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
                  Thread.Sleep(3000);
                  form.DeleteAccount.Click();
                  Thread.Sleep(3000);
                  form.Ok.Click();
                  WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                  wait4.Until(ExpectedConditions.AlertIsPresent());
                  IAlert alert4 = driver.SwitchTo().Alert();
                  alert4.Accept();
                  driver.Quit();
               });

         }
    }
}
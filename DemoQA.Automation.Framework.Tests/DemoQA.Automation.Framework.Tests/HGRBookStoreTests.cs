using DemoQA.Automation.Framework.Tests.Entities;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using RestSharp;
using RestSharp.Authenticators;
using OpenQA.Selenium.Chrome;
using System;
using Newtonsoft.Json;


namespace DemoQA.Automation.Framework.Tests
{
    public class HGRBookStoreTests : AutomationTestBase
    {
        private TableComponentWrapper table;
        private readonly RestClient clientAPI;
        public IWebDriver driverTest;
        private readonly ITestOutputHelper output;
        private User apiUser;

        public HGRBookStoreTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            clientAPI = new RestClient("https://demoqa.com");
            this.output = output;
            apiUser = new User();
        }

        [Theory]
        [InlineData("Htest", "Control123!!")]
        public void TC1(string username, string password)
        {
            this.client.AutomateActivePage<HGRBookStoreWrapper>(form =>
            {
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                //form.GotoStoreButton.Click();
                //form.GitPocketBook.Click();
                //form.AddBookToCollectionButton.Click();
                //Thread.Sleep(1000);
                //IAlert alert = driver.SwitchTo().Alert();
                //// Assert.Equal("Book already present in the your collection!", alert.Text);
                //Assert.Equal("Book added to your collection.", alert.Text);
                //alert.Accept();
                //form.GotoNewBookStoreButton.Click();
                //form.JsDesignBook.Click();
                //form.AddBookToCollectionButton.Click();
                //Thread.Sleep(1000);
                //Assert.Equal("Book added to your collection.", alert.Text);
                //alert.Accept();
                //form.GotoNewBookStoreButton.Click();
                //form.WebApisBook.Click();
                //form.AddBookToCollectionButton.Click();
                //Thread.Sleep(1000);
                //Assert.Equal("Book added to your collection.", alert.Text);
                //alert.Accept();
                // ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                // form.ProfileMenu.Click();

            });

            IEnumerable<string> tableInfo = table.GetTextList();
            Assert.Contains($"{TableLabels.FirstBook}", tableInfo);
            var test = 10;

        }

        [Fact]
        public void TC2()
        {
            User user = new User
            {
                userName = "HarryTest",
                password = "Control123!!"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = clientAPI.Execute<User>(request);
            User userResult = queryResult.Data;
            apiUser.userId = userResult.userId;

            clientAPI.Authenticator = new HttpBasicAuthenticator("HarryTest", "Control123!!");
            var request2 = new RestRequest("/BookStore/v1/Books", Method.POST);
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
                isbn = "9781593277574"
            };
            Book book4 = new Book
            {
                isbn = "9781593275846"
            };
            Book book5 = new Book
            {
                isbn = "9781491950296"
            };
            Book book6 = new Book
            {
                isbn = "9781491904244"
            };
            Book book7 = new Book
            {
                isbn = "9781449365035"
            };

            User user2 = new User
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
                    book7,
                },
            };
            request2.AddJsonBody(user2);
            output.WriteLine(JsonConvert.SerializeObject(user2));
            IRestResponse queryResult2 = clientAPI.Execute(request2);
            Assert.True(queryResult2.IsSuccessful, "The request finished with errors");
            Assert.Equal("Created", queryResult2.StatusCode.ToString());
            Assert.Equal("Completed", queryResult2.ResponseStatus.ToString());
            /////////////
            driverTest = new ChromeDriver();
            driverTest.Navigate().GoToUrl("https://demoqa.com/login");
            driverTest.FindElement(By.Id("userName")).SendKeys(user.userName);
            driverTest.FindElement(By.Id("password")).SendKeys(user.password);
            driverTest.FindElement(By.Id("login")).Click();
            Thread.Sleep(3000);
            driverTest.FindElement(By.XPath("//select[@aria-label='rows per page']")).Click();
            driverTest.FindElement(By.XPath("//option[@value='10']")).Click();

            // Books Verification
            Assert.Contains("Git Pocket Guide", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781449325862')]")).Text);
            Assert.Contains("Learning JavaScript Design Patterns", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781449331818')]")).Text);
            Assert.Contains("Understanding ECMAScript 6", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781593277574')]")).Text);
            Assert.Contains("Eloquent JavaScript, Second Edition", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781593275846')]")).Text);
            Assert.Contains("Programming JavaScript Applications", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781491950296')]")).Text);
            Assert.Contains("You Don't Know JS", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781491904244')]")).Text);
            Assert.Contains("Speaking JavaScript", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781449365035')]")).Text);
            
            driverTest.FindElement(By.XPath("//span[contains(.,'Profile')]")).Click();
            Thread.Sleep(1000);
            driverTest.FindElement(By.XPath("//button[contains(text(), 'Delete Account')]")).Click();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            driverTest.FindElement(By.Id("closeSmallModal-ok")).Click();
            Thread.Sleep(1000);
            driverTest.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            driverTest.FindElement(By.Id("userName")).SendKeys(user.userName);
            driverTest.FindElement(By.Id("password")).SendKeys(user.password);
            driverTest.FindElement(By.Id("login")).Click();
            Thread.Sleep(3000);
            driverTest.Close();
        }


        [Fact]
        public void TC3()
        {
            User user = new User
            {
                userName = "HarryTest",
                password = "Control123!!"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = clientAPI.Execute<User>(request);
            User userResult = queryResult.Data;
            apiUser.userId = userResult.userId;

            clientAPI.Authenticator = new HttpBasicAuthenticator("HarryTest", "Control123!!");
            var request2 = new RestRequest("/BookStore/v1/Books", Method.POST);
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
                isbn = "9781593277574"
            };
            Book book4 = new Book
            {
                isbn = "9781593275846"
            };
            Book book5 = new Book
            {
                isbn = "9781491950296"
            };
            Book book6 = new Book
            {
                isbn = "9781491904244"
            };
            Book book7 = new Book
            {
                isbn = "9781449365035"
            };

            User user2 = new User
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
                    book7,
                },
            };
            request2.AddJsonBody(user2);
            IRestResponse queryResult2 = clientAPI.Execute(request2);
            Assert.True(queryResult2.IsSuccessful, "The request finished with errors");
            Assert.Equal("Created", queryResult2.StatusCode.ToString());
            Assert.Equal("Completed", queryResult2.ResponseStatus.ToString());
            /////////////
            driverTest = new ChromeDriver();
            driverTest.Navigate().GoToUrl("https://demoqa.com/login");
            Thread.Sleep(2000);
            driverTest.FindElement(By.Id("userName")).SendKeys(user.userName);
            driverTest.FindElement(By.Id("password")).SendKeys(user.password);
            driverTest.FindElement(By.Id("login")).Click();
            Thread.Sleep(3000);

            driverTest.FindElement(By.XPath("//span[contains(.,'Profile')]")).Click();
            Thread.Sleep(1000);
            driverTest.FindElement(By.Id("searchBox")).SendKeys("Learning");
            Thread.Sleep(2000);
            Assert.Contains("Learning JavaScript Design Patterns", driverTest.FindElement(By.XPath($"//a[contains(@href , '9781449331818')]")).Text);
            Thread.Sleep(1000);
            driverTest.FindElement(By.XPath("//span[contains(.,'Profile')]")).Click();
            Thread.Sleep(1000);
            driverTest.FindElement(By.XPath("//button[contains(text(), 'Delete Account')]")).Click();
            Thread.Sleep(1000);
            driverTest.FindElement(By.Id("closeSmallModal-ok")).Click();
            Thread.Sleep(1000);
            driverTest.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            driverTest.FindElement(By.Id("userName")).SendKeys(user.userName);
            driverTest.FindElement(By.Id("password")).SendKeys(user.password);
            driverTest.FindElement(By.Id("login")).Click();
            Thread.Sleep(3000);
            driverTest.Close();
        }

        [Fact]
        public void TC4()
        {
            User user = new User
            {
                userName = "HarryTest",
                password = "Control123!!"
            };
            RestRequest request = new RestRequest("/Account/v1/User", Method.POST);
            request.AddJsonBody(user);
            IRestResponse<User> queryResult = clientAPI.Execute<User>(request);
            driverTest = new ChromeDriver();
            driverTest.Navigate().GoToUrl("https://demoqa.com/login");
            driverTest.FindElement(By.Id("userName")).SendKeys(user.userName);
            driverTest.FindElement(By.Id("password")).SendKeys(user.password);
            driverTest.FindElement(By.Id("login")).Click();
            Thread.Sleep(3000);
            driverTest.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div[3]/div[2]/button")).Click();
            Thread.Sleep(1000);
            driverTest.FindElement(By.Id("closeSmallModal-ok")).Click();
            Thread.Sleep(1000);
            driverTest.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            driverTest.FindElement(By.Id("userName")).SendKeys(user.userName);
            driverTest.FindElement(By.Id("password")).SendKeys(user.password);
            driverTest.FindElement(By.Id("login")).Click();
            Thread.Sleep(3000);
            driverTest.Close();
        }
    }
}
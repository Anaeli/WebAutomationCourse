using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.Tests.Entities;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using RestSharp;
using RestSharp.Authenticators;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQA.Automation.Framework.Tests
{
    public class DZOBookStoreTests : AutomationTestBase
    {
        //private BookTableComponentWrapper table;
        DZOBookStoreTestsAPI apiInstance = new DZOBookStoreTestsAPI();
        public DZOBookStoreTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            //this.table = new TableComponentWrapper();
            
            apiInstance.PostUser();
            this.client.GoToPage("https://demoqa.com/login");
        }

        //Test Case 1
        [Theory]
        [InlineData("Dan", "Control123!")]
        public void BookstoreWorkFlow(string username, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                // Login
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                
                // Add Book1
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                form.MenuGotoStoreButton.Click();
                form.GitPocketGuideBook.Click();
                Thread.Sleep(2000);
                form.AddBookToCollectionButton.Click(); 
                Thread.Sleep(1000);
                IAlert alertBook1 = driver.SwitchTo().Alert();
                Thread.Sleep(1000);
                alertBook1.Accept();
                Thread.Sleep(1000);

                // Add Book2
                 form.backToStoreButton.Click();
                 form.JsDesignBook.Click();
                 Thread.Sleep(2000);
                 form.AddBookToCollectionButton.Click();
                 Thread.Sleep(2000);
                 IAlert alertBook2 = driver.SwitchTo().Alert();
                 Thread.Sleep(1000);
                 alertBook2.Accept();
                 Thread.Sleep(1000);

                // Add Book3
                form.backToStoreButton.Click();
                form.WebApisBook.Click();
                Thread.Sleep(2000);
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alertBook3 = driver.SwitchTo().Alert();
                Thread.Sleep(1000);
                alertBook3.Accept();

                // Validated Added Books
                 ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                 Thread.Sleep(2000);
                 form.ProfileButtonMenu.Click();
                 Assert.Equal("Git Pocket Guide", form.GitPocketGuideBook.Text);
                 Assert.Equal("Learning JavaScript Design Patterns", form.JsDesignBook.Text);
                 Assert.Equal("Designing Evolvable Web APIs with ASP.NET", form.WebApisBook.Text);

                //Delete Books
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                form.DeleteAllBooksButton.Click();
                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementToBeClickable(form.CloseSmallModal));
                Thread.Sleep(1000);
                form.CloseSmallModal.Click();
                Thread.Sleep(2000);
                IAlert alertDeleteAllBooks = driver.SwitchTo().Alert();
                alertDeleteAllBooks.Accept();
                Thread.Sleep(1000);
                Assert.True(form.noRowsMessage.Displayed);

                // Add duplicate Book
                form.GoToBookStoreButton.Click();
                form.GitPocketGuideBook.Click();
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alertDuplicateBook = driver.SwitchTo().Alert();
                //Assert.Equal("Book already present in the your collection!", alert1.Text);
                alertDuplicateBook.Accept();
                Thread.Sleep(1000);
                
                // Delete Account by UI
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                form.DeleteAccountButton.Click();
                Thread.Sleep(2000);
                this.driver.SwitchTo().ActiveElement();
                form.CloseSmallModal.Click();
                Thread.Sleep(2000);
                IAlert alertDeleteAccount = driver.SwitchTo().Alert();
                Assert.Equal("User Deleted.", alertDeleteAccount.Text);
                alertDeleteAccount.Accept();
                
            });
                     
        }

        //Test Case 1
        [Theory]
        [InlineData("Dan", "Control123!")]
        public void BookStoreTC1(string username, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                // Login
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();

                // Add Book1
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                form.MenuGotoStoreButton.Click();
                form.GitPocketGuideBook.Click();
                Thread.Sleep(2000);
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alertBook1 = driver.SwitchTo().Alert();
                Thread.Sleep(1000);
                alertBook1.Accept();
                Thread.Sleep(1000);

                // Validated Added Books
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                Assert.Equal("Git Pocket Guide", form.GitPocketGuideBook.Text);

                // Add duplicate Book
                form.GoToBookStoreButton.Click();
                form.GitPocketGuideBook.Click();
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alertDuplicateBook = driver.SwitchTo().Alert();
                Assert.Equal("Book already present in the your collection!", alertDuplicateBook.Text);
                alertDuplicateBook.Accept();
                Thread.Sleep(1000);

                // Delete Account by API
                apiInstance.DeleteBook();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                Thread.Sleep(2000);
                Assert.True(form.noRowsMessage.Displayed);

                // Delete Account by UI
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                form.DeleteAccountButton.Click();
                Thread.Sleep(2000);
                this.driver.SwitchTo().ActiveElement();
                form.CloseSmallModal.Click();
                Thread.Sleep(2000);
                IAlert alertDeleteAccount = driver.SwitchTo().Alert();
                Assert.Equal("User Deleted.", alertDeleteAccount.Text);
                alertDeleteAccount.Accept();


            });

        }

        //Test Case 2
        [Theory]
        [InlineData("Dan", "Control123!")]
        public void BookStoreTC2(string username, string password)
        {
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                //Login
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                
                // Add Books API
                apiInstance.PostBooks();
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                
                // Change Number of rows
                form.PageSizeDropDown.Click();
                form.PageSizeRows.Click();
                
                // Books Verification
                Assert.Contains("Git Pocket Guide", driver.FindElement(By.XPath($"//a[contains(@href , '9781449325862')]")).Text);
                Assert.Contains("Learning JavaScript Design Patterns", driver.FindElement(By.XPath($"//a[contains(@href , '9781449331818')]")).Text);
                Assert.Contains("Designing Evolvable Web APIs with ASP.NET", driver.FindElement(By.XPath($"//a[contains(@href , '9781449337711')]")).Text);
                Assert.Contains("Speaking JavaScript", driver.FindElement(By.XPath($"//a[contains(@href , '9781449365035')]")).Text);
                Assert.Contains("You Don't Know JS", driver.FindElement(By.XPath($"//a[contains(@href , '9781491904244')]")).Text);
                Assert.Contains("Eloquent JavaScript, Second Edition", driver.FindElement(By.XPath($"//a[contains(@href , '9781593275846')]")).Text);
                Assert.Contains("Understanding ECMAScript 6", driver.FindElement(By.XPath($"//a[contains(@href , '9781593277574')]")).Text);

                // Delete Account by UI
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                form.DeleteAccountButton.Click();
                Thread.Sleep(2000);
                this.driver.SwitchTo().ActiveElement();
                form.CloseSmallModal.Click();
                Thread.Sleep(2000);
                IAlert alertDeleteAccount = driver.SwitchTo().Alert();
                Assert.Equal("User Deleted.", alertDeleteAccount.Text);
                alertDeleteAccount.Accept();
            });
                       
        }

        [Theory]
        [InlineData("Dan", "Control123!")]
        public void BookStoreTC3(string username, string password)
        {
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                // Login
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                
                // Add Books API
                apiInstance.PostBooks();
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);

                // Search a Book
                form.ProfileButtonMenu.Click();
                form.SearchField.SendKeys("Understanding");
                Thread.Sleep(2000);
                Assert.Contains("Understanding ECMAScript 6", driver.FindElement(By.XPath($"//a[contains(@href , '9781593277574')]")).Text);

                // Delete Account by UI
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                form.ProfileButtonMenu.Click();
                form.DeleteAccountButton.Click();
                Thread.Sleep(2000);
                this.driver.SwitchTo().ActiveElement();
                form.CloseSmallModal.Click();
                Thread.Sleep(2000);
                IAlert alertDeleteAccount = driver.SwitchTo().Alert();
                Assert.Equal("User Deleted.", alertDeleteAccount.Text);
                alertDeleteAccount.Accept();
            });

        }

        [Theory]
        [InlineData("Dan", "Control1234!")]
        public void BookStoreTC4(string username, string password)
        {
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                Assert.Equal("Invalid username or password!", form.LoginValidaton.Text);
            });

        }

    }
}

//Assert.Equal("Book already present in the your collection!", alert.Text);
//Assert.Equal("Book added to your collection.", alert.Text);
//*form.ProfileButton.Click();
//*form.ProfileMenu.Click();
//Assert.Equal("Book added to your collection.", alert.Text);
//Thread.Sleep(1000);
//Assert.Equal("Book added to your collection.", alert.Text);
//alert.Accept();
// ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
// form.ProfileMenu.Click();
//*form.ProfileButton.Click();
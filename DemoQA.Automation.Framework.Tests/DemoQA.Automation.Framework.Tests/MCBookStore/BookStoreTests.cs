using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RestSharp;
using RestSharp.Authenticators;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Utilities;
using Xunit.Abstractions;
using System.Threading;
using OpenQA.Selenium;

namespace DemoQA.Automation.Framework.Tests.MCBookStore
{
    public class BookStoreTests : AutomationTestBase
    {
        public BookStoreTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            BookStoreAPI accountAPI = new BookStoreAPI();
            accountAPI.PostUser();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("TandyMiller", "Contr0l-123*/")]
        public void AddingDeletingBooksAndCollectionTest(string username, string password)
        {
            this.client.AutomateActivePage<MCBookStoreWrapper>(form =>
            {
                Thread.Sleep(3000);
                IJavaScriptExecutor jScript = (IJavaScriptExecutor)driver;

                //Login
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                Thread.Sleep(2000);
                jScript.ExecuteScript("window.scrollBy(0,900)");

                //Adding book #1
                Thread.Sleep(2000);
                form.GoToBookStoreButtonX.Click();
                form.GitPocketGuideBook.Click();
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(2000);
                IAlert alert = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();

                //Adding book #2
                Thread.Sleep(2000);
                form.BackToBookStoreButtonX.Click();
                form.JavaScriptDesignPatternsBook.Click();
                jScript.ExecuteScript("window.scrollBy(0,900)");
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(2000);
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();

                //Adding book #3
                Thread.Sleep(2000);
                form.BackToBookStoreButtonX.Click();
                form.DesigningEvolvableWebAPIsBook.Click();
                jScript.ExecuteScript("window.scrollBy(0,900)");
                form.AddBookToCollectionButton.Click();
                Thread.Sleep(2000);
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();

                //Verify added books in collection
                jScript.ExecuteScript("window.scrollBy(0,900)");
                form.ProfileMenuButton.Click();
                Assert.Contains("Git Pocket Guide", form.GitPocketGuideBook.Text);
                Assert.Contains("Learning JavaScript Design Patterns", form.JavaScriptDesignPatternsBook.Text);
                Assert.Contains("Designing Evolvable Web APIs with ASP.NET", form.DesigningEvolvableWebAPIsBook.Text);

                //Verify book #2 (Learning JavaScript...) deletion
                Thread.Sleep(2000);
                form.DeleteJavaScriptDesignBookButton.Click();
                Thread.Sleep(2000);
                form.CloseSmallModalButton.Click();
                Thread.Sleep(2000);
                alert.Accept();
                //To consider! >>> This step takes up to 40s to execute
                Assert.Throws<NoSuchElementException>(() => form.JavaScriptDesignPatternsBook.Text.Contains("Learning JavaScript Design Patterns"));

                //Verify all books deletion
                Thread.Sleep(2000);
                form.DeleteAllBooksButtonX.Click();
                Thread.Sleep(2000);
                form.CloseSmallModalButton.Click();
                Thread.Sleep(2000);
                alert.Accept();
                Thread.Sleep(2000);
                Assert.True(form.NoRowsFoundTableText.Displayed);

                //Delete Account via UI
                Thread.Sleep(2000);
                form.ProfileMenuButton.Click();
                Thread.Sleep(2000);
                form.DeleteAccountButtonX.Click();
                Thread.Sleep(2000);
                form.CloseSmallModalButton.Click();
                Thread.Sleep(2000);
                IAlert deletedAccountAlert = driver.SwitchTo().Alert();
                deletedAccountAlert.Accept();
            });
        }        
    }
}

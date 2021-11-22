using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests
{
    public class RGCBookStoreWorkFlowTests : AutomationTestBase
    {
        private TableComponentWrapper table;

        public RGCBookStoreWorkFlowTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Rayus008", "Control!23")]
        public void LogInBookStoreTest(string username, string password)
        {
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                User user = new User
                {
                    userName = username,
                    password = password
                };
                string myUser = user.AddUser(user);
                Thread.Sleep(3000);
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                Thread.Sleep(1000);
                form.GotoStoreButton.Click();
                form.GitPocketBook.Click();
                form.AddBookToCollectionButton.Click(); //Add Book #1
                Thread.Sleep(1000);
                IAlert alert = driver.SwitchTo().Alert();
                // Assert.Equal("Book already present in the your collection!", alert.Text);
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                form.GotoNewBookStoreButton.Click();
                form.JsDesignBook.Click();
                form.AddBookToCollectionButton.Click(); //Add Book #2
                Thread.Sleep(1000);
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                form.GotoNewBookStoreButton.Click();
                form.WebApisBook.Click();
                form.AddBookToCollectionButton.Click(); //Add Book #3
                Thread.Sleep(1000);
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                form.ProfileMenu.Click();
                Assert.Contains("Git Pocket Guide", $"{TableLabels.FirstBook}"); //3 Books added
                Assert.Contains("Learning JavaScript Design Patterns", $"{TableLabels.SecondBook}");
                Assert.Contains("Designing Evolvable Web APIs with ASP.NET", $"{TableLabels.ThirdBook}");
                form.DeleteGitPocketGuideButton.Click(); //Delete book
                form.ModalButtonOK.Click();
                Thread.Sleep(1000);
                alert.Accept();
                Thread.Sleep(1000);
                //Assert.DoesNotContain("Git Pocket Guide", $"{TableLabels.FirstBook}");
                form.DeleteAllBooksButton.Click();
                form.ModalButtonOK.Click();
                Thread.Sleep(1000);
                alert.Accept();
                Assert.Contains("No rows found", $"{form.NoBooks.Text}"); //Books deleted
                form.DeleteAccountButton.Click();
                form.ModalButtonOK.Click();
                Thread.Sleep(1000);
                alert.Accept();
                Assert.Contains("Login", form.LoginTitle.Text);
            });
            
        }
    }
}

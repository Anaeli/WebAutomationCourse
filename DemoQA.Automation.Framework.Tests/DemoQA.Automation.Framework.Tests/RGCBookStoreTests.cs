using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Utilities;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests
{
    public class RGCBookStoreTests : AutomationTestBase
    {
        private TableComponentWrapper table;

        public RGCBookStoreTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Rayus007", "Control!23")]
        public void LogInBookStoreTest(string username, string password)
        {
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
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
    }
}

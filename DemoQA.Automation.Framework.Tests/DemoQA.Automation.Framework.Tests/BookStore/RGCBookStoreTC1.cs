using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.Components;
using OpenQA.Selenium;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests
{
    public class RGCBookStoreTC1 : AutomationTestBase
    {
        private TableComponentWrapper table;

        public RGCBookStoreTC1(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage("https://demoqa.com/login");
        }

        [Theory]
        [InlineData("Rayus008", "Control!23")]
        public void RGCTestCase1(string username, string password)
        {
            this.client.AutomateActivePage<RGCBookStoreWrapper>(form =>
            {
                User user = new User
                {
                    userName = username,
                    password = password
                };
                string myUser = user.AddUser(user);
                Thread.Sleep(1000);
                form.UserNameTextBox.SetValue(username);
                form.PasswordTextBox.SetValue(password);
                form.LoginButton.Click();
                Thread.Sleep(1000);
                form.GotoStoreButton.Click();
                form.GitPocketBook.Click();
                form.AddBookToCollectionButton.Click(); //Add Book #1
                Thread.Sleep(1000);
                IAlert alert = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                form.ProfileMenu.Click();
                Thread.Sleep(1000);
                form.GitPocketBook.Click();
                Assert.Equal("9781449325862", form.BookIsbnValue.Text); //Book validations
                Assert.Equal("Git Pocket Guide", form.BookTitleValue.Text);
                Assert.Equal("A Working Introduction", form.BookSubTitleValue.Text);
                Assert.Equal("Richard E. Silverman", form.BookAuthorValue.Text);
                Assert.Equal("O'Reilly Media", form.BookPublisherValue.Text);
                Assert.Equal("234", form.BookTotalPagesValue.Text);
                Assert.StartsWith("This pocket guide is the perfect on-the-job companion to Git", form.BookDescriptionValue.Text);
                Assert.Equal("http://chimera.labs.oreilly.com/books/1230000000561/index.html", form.BookWebsiteValue.Text);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                form.GotoNewBookStoreButton.Click();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                form.GotoBookStoreButton.Click();
                form.GitPocketBook.Click();
                form.AddBookToCollectionButton.Click(); //Add Book #1 again
                Thread.Sleep(1000);
                Assert.Equal("Book already present in the your collection!", alert.Text); //diff alert message
                alert.Accept();
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                form.ProfileMenu.Click();
                form.DeleteGitPocketGuideButton.Click(); //Delete book
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

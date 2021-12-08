using DemoQA.Automation.Framework.API.Tests;
using DemoQA.Automation.Framework.Tests.Client;
using DemoQA.Automation.Framework.Tests.Labels;
using DemoQA.Automation.Framework.Wrappers.Components;
using DemoQA.Automation.Framework.Wrappers.JMPFBookStore;
using OpenQA.Selenium;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.JMPFBookStore
{
    public class JMPFBookStoreWorkFlowTest : AutomationTestBase
    {
        private TableComponentWrapper table;

        public JMPFBookStoreWorkFlowTest(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            this.table = new TableComponentWrapper();
            this.client.GoToPage(URLsList.BookStoreURL);
        }

        [Theory]
        [InlineData("Jess", "Control123!")]
        public void WorkFlow(string username, string password)
        {
            this.client.AutomateActivePage<JMPFBookStoreWrapper>(formLogin =>
            {
                User user = new User
                {
                    userName = username,
                    password = password
                };
                string myUser = user.AddUserApi(user);
                Thread.Sleep(3000);
                formLogin.UserNameTextBox.SetValue(username);
                formLogin.PasswordTextBox.SetValue(password);
                formLogin.LoginButton.Click();
                Thread.Sleep(1000);

                formLogin.GoToStoreButton.Click();
                formLogin.FirstBook.Click();
                formLogin.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alert = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();

                formLogin.GotoNewBookStoreButton.Click();
                formLogin.SecondBook.Click();
                formLogin.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alertSecondBook = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();

                formLogin.GotoNewBookStoreButton.Click();
                formLogin.ThirdBook.Click();
                formLogin.AddBookToCollectionButton.Click();
                Thread.Sleep(1000);
                IAlert alertThirdBook = driver.SwitchTo().Alert();
                Assert.Equal("Book added to your collection.", alert.Text);
                alert.Accept();
                formLogin.Profile.Click();

                //Validations
                Assert.Contains("Git Pocket Guide", $"{BookStoreTableLabel.FirstBook}");
                Assert.Contains("Designing Evolvable Web APIs with ASP.NET", $"{BookStoreTableLabel.SecondBook}");
                Assert.Contains("Speaking JavaScript", $"{BookStoreTableLabel.ThirdBook}");

                //Delete one Book
                formLogin.DeleteFirstBook.Click();
                formLogin.ModalOkButton.Click();
                Thread.Sleep(1000);
                alert.Accept();
                Thread.Sleep(1000);

                //Validations
                Assert.DoesNotContain("Git Pocket Guide", $"{BookStoreTableLabel.FirstBook}");
                Assert.Contains("Designing Evolvable Web APIs with ASP.NET", $"{BookStoreTableLabel.SecondBook}");
                Assert.Contains("Speaking JavaScript", $"{BookStoreTableLabel.ThirdBook}");

                //Delete All books
                formLogin.DeleteAllBooksButton.Click();
                formLogin.ModalOkButton.Click();
                Thread.Sleep(1000);
                alert.Accept();
                Thread.Sleep(1000);

                //Validations
                Assert.DoesNotContain("Git Pocket Guide", $"{BookStoreTableLabel.FirstBook}");
                Assert.DoesNotContain("Designing Evolvable Web APIs with ASP.NET", $"{BookStoreTableLabel.SecondBook}");
                Assert.DoesNotContain("Speaking JavaScript", $"{BookStoreTableLabel.ThirdBook}");

                formLogin.DeleteAccountButton.Click();
                formLogin.ModalOkButton.Click();
                Thread.Sleep(1000);
                alert.Accept();
                Assert.Contains("UserName", formLogin.LoginTitleLabel.Text);
            });
        }
    }
}

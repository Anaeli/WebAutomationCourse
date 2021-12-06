using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoQA.Automation.Framework.Wrappers.BookStore
{
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    /// <summary>
    /// Mapped Book store fields.
    /// </summary>

    public class RTBookStoreApplicationWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public IWebElement UserNameTextBox => this.driver.FindElement(By.XPath("//input[@id='userName']"));

        public IWebElement PasswordTextBox => this.driver.FindElement(By.Id("password"));

        public IWebElement LoginButton => this.driver.FindElement(By.Id("login"));

        public IWebElement InvalidUserOrPassMessage => this.driver.FindElement(By.Id("name"));

        public IWebElement LogoutButton => this.driver.FindElement(By.XPath("//button[text()='Log out']"));

        public IWebElement BookStoreApplicationButton => this.driver.FindElement(By.XPath("//div[text()='Book Store Application']"));

        public IWebElement BookStoreButton => this.driver.FindElement(By.XPath("//span[text()='Book Store']"));

        public IWebElement ProfileButton => this.driver.FindElement(By.XPath("//span[text()='Profile']"));

        public IWebElement GitPocketGuideLink => this.driver.FindElement(By.Id("see-book-Git Pocket Guide"));

        public IWebElement LearningJavaScriptDesignPatternsLink => this.driver.FindElement(By.Id("see-book-Learning JavaScript Design Patterns"));

        public IWebElement DesigningEvolvableWebAPIswithASPNETLink => this.driver.FindElement(By.Id("see-book-Designing Evolvable Web APIs with ASP.NET"));

        public IWebElement DeleteGitPocketGuideButton => this.driver.FindElement(By.XPath("//span[@id='see-book-Git Pocket Guide']//parent::div//parent::div//following-sibling::div[3]/div/span"));

        public IWebElement PageSizeSelector => this.driver.FindElement(By.XPath("//select[@aria-label='rows per page']"));

        public IWebElement PageSize10Rows => this.driver.FindElement(By.XPath("//option[@value='10']"));

        public IWebElement SearchBox => this.driver.FindElement(By.Id("searchBox"));

        public IWebElement AddToYourCollectionButton => this.driver.FindElement(By.XPath("//button[text()='Add To Your Collection']"));

        public IWebElement BackToBookStoreButton => this.driver.FindElement(By.XPath("//button[text()='Back To Book Store']"));

        public IWebElement IsbnValue => this.driver.FindElement(By.XPath("//div[@id='ISBN-wrapper']/div[2]/label"));

        public IWebElement TitleValue => this.driver.FindElement(By.XPath("//div[@id='title-wrapper']/div[2]/label"));

        public IWebElement SubTitleValue => this.driver.FindElement(By.XPath("//div[@id='subtitle-wrapper']/div[2]/label"));

        public IWebElement AuthorValue => this.driver.FindElement(By.XPath("//div[@id='author-wrapper']/div[2]/label"));

        public IWebElement PublisherValue => this.driver.FindElement(By.XPath("//div[@id='publisher-wrapper']/div[2]/label"));

        public IWebElement TotalPagesValue => this.driver.FindElement(By.XPath("//div[@id='pages-wrapper']/div[2]/label"));

        public IWebElement DescriptionValue => this.driver.FindElement(By.XPath("//div[@id='description-wrapper']/div[2]/label"));

        public IWebElement WebsiteValue => this.driver.FindElement(By.XPath("//div[@id='website-wrapper']/div[2]/label"));

        public IWebElement ModalOKButton => this.driver.FindElement(By.Id("closeSmallModal-ok"));

        public IWebElement DeleteAllBooksButton => this.driver.FindElement(By.XPath("//button[text()='Delete All Books']"));

        public IWebElement DeleteAccountButton => this.driver.FindElement(By.XPath("//button[text()='Delete Account']"));

        public IWebElement GoToBookStoreButton => this.driver.FindElement(By.XPath("//button[text()='Go To Book Store']"));

        public IWebElement NoRowsFoundMessage => this.driver.FindElement(By.XPath("//div[text()='No rows found']"));
    }
}

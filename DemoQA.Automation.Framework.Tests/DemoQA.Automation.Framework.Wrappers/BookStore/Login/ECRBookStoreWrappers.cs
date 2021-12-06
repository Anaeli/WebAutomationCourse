using DemoQA.Automation.Core.Wrappers;
using DemoQA.Automation.Core.Wrappers.Components;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;


namespace DemoQA.Automation.Framework.Wrappers.BookStore.Login
{
    public class ECRBookStoreWrappers : ContentScreenWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;
        private readonly IWebElement textBox;

        protected ECRBookStoreWrappers(IWebElement container, AutomationClient client) : base(container, client)
        {
        }

        public IWebElement UserName => driver.FindElement(By.Id("userName"));

        public IWebElement Password => driver.FindElement(By.Id("password"));

        public ButtonComponentWrapper SubmintButton => this.WaitForWrapper<ButtonComponentWrapper>("login");

        public IWebElement WarningMessage => driver.FindElement(By.Id("name"));

        public IWebElement Profile => driver.FindElement(By.XPath("//span[text()='Profile']//ancestor::li"));

        public IWebElement GoToBookStore => driver.FindElement(By.Id("gotoStore"));

        public IWebElement BookStore1 => driver.FindElement(By.Id("see-book-Git Pocket Guide"));

        public IWebElement BookStore2 => driver.FindElement(By.Id("see-book-Learning JavaScript Design Patterns"));

        public IWebElement BookStore3 => driver.FindElement(By.Id("see-book-Designing Evolvable Web APIs with ASP.NET"));

        public IWebElement AddBookStore => driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));

        public IWebElement BackToBookStore => driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));

        public IWebElement DeleteAllBooks => driver.FindElement(By.XPath("//button[text() ='Delete All Books'][1]"));

        public IWebElement DeleteBook => driver.FindElement(By.XPath("//span[@id='delete-record-undefined'][1]"));

        public IWebElement Modal => driver.FindElement(By.XPath("//div[@class = 'modal-content']"));

        public IWebElement Ok => driver.FindElement(By.Id("closeSmallModal-ok"));

        public IWebElement Cancel => driver.FindElement(By.Id("closeSmallModal-cancel"));

        public IWebElement DeleteAccount => driver.FindElement(By.XPath("//button[text()='Delete Account']"));

        public IWebElement OK => driver.FindElement(By.Id("closeSmallModal-ok"));

        public IWebElement Rows => driver.FindElement(By.XPath("//select[@aria-label='rows per page']"));

        public IWebElement Row10 => driver.FindElement(By.XPath("//option[text()='10 rows']"));

        public IWebElement SearchText => driver.FindElement(By.XPath("//input[@id='searchBox']"));
    }
}

using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Automation.Framework.Wrappers.Students
{
    public class DZOPracticeFormTestWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        private IWebElement tableContainer => driver.FindElement(By.ClassName("table"));

        private ReadOnlyCollection<IWebElement> TableRows => tableContainer.FindElements(By.TagName("tr"));

        public IEnumerable<string> GetTextList()
        {
            IEnumerable<string> textList = TableRows.Select(row => row.Text);
            return textList;
        }




        public void GoToPage()
        {
            string appURL = "https://demoqa.com/automation-practice-form";
            driver.Navigate().GoToUrl(appURL);
        }
    }
}

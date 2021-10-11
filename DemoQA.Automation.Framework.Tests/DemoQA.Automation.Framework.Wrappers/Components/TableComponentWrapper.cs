using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DemoQA.Automation.Framework.Wrappers.Components
{
    public class TableComponentWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;
 

        private IWebElement tableContainer => driver.FindElement(By.ClassName("table"));

        private ReadOnlyCollection<IWebElement> TableRows => tableContainer.FindElements(By.TagName("tr"));

        public IEnumerable<string> GetTextList()
        {
            IEnumerable<string> textList = TableRows.Select(row => row.Text);
            return textList;
        }
    }
}

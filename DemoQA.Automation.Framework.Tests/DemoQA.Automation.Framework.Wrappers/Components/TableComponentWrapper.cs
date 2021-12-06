﻿namespace DemoQA.Automation.Framework.Wrappers.Components
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    /// <summary>
    /// Table Component wrapper.
    /// </summary>
    public class TableComponentWrapper
    {
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        private IWebElement tableContainer => this.driver.FindElement(By.ClassName("table-responsive"));

        private ReadOnlyCollection<IWebElement> TableRows => this.tableContainer.FindElements(By.TagName("rt-tr"));
        //private ReadOnlyCollection<IWebElement> TableRows => this.driver.FindElements(By.TagName("rt-td"));
        /// <summary>
        /// Gets list text of table.
        /// </summary>
        /// <returns>Text list.</returns>
        public IEnumerable<string> GetTextList()
        {
            IEnumerable<string> textList = this.TableRows.Select(row => row.Text);
            return textList;
        }
    }
}

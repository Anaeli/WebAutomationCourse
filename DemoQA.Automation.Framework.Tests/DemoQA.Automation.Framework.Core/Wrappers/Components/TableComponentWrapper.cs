using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DemoQA.Automation.Core.Wrappers.Components
{
    public class TableComponentWrapper
    {
        private static TableComponentWrapper table;
		private readonly IWebDriver driver = AutomationClient.Instance.Driver;

		/// <summary>
		/// Initializes a new instance of the <see cref="TableComponentWrapper"/> class.
		/// </summary>
		public TableComponentWrapper() 
        {
			tableContainer = driver.FindElement(By.ClassName("table"));
		}

		public string GetTableTitle()
        {
			return driver.FindElement(By.Id("example-modal-sizes-title-lg")).Text;
		}

		/// <summary>
		/// Gets AppearanceEntity unique instance.
		/// </summary>
		public static TableComponentWrapper Instance => table ?? (table = new TableComponentWrapper());

		private readonly IWebElement tableContainer;

		private ReadOnlyCollection<IWebElement> TableRows => tableContainer.FindElements(By.TagName("tr"));

	    public IEnumerable<string> GetTextList()
		{   
			IEnumerable<string> textList = TableRows.Select(row => row.Text);
			return textList;
		}

		public void ClickCloseButton()
		{
			IWebElement buttonCloseModal = driver.FindElement(By.Id("closeLargeModal"));
			buttonCloseModal.Click();
		}
	}
}

using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Automation.Core.Wrappers.Components
{
	public class DropDownListComponentWrapper : BaseStyledComponentWrapper
	{
		public class Option
		{
			public string Text
			{
				get;
				set;
			}

			public string Value
			{
				get;
				set;
			}
		}

		protected IWebElement ListContainer => base.Client.Driver.FindElements(By.ClassName("k-list-container")).FirstOrDefault((IWebElement element) => element.Displayed);

		private IWebElement DropDown => base.RootElement.FindElementSafe(By.ClassName("k-dropdown"));

		private SelectElement Select => new SelectElement(base.RootElement.FindElementSafe(By.TagName("select")));

		public string SelectedText => Select.SelectedOption.GetHiddenText(base.Client.Driver);

		public string SelectedValue => Select.SelectedOption.GetAttribute("value");

		public IEnumerable<Option> Options
		{
			get
			{
				foreach (IWebElement option in Select.Options)
				{
					yield return new Option
					{
						Text = option.GetHiddenText(Client.Driver),
						Value = option.GetAttribute("value")
					};
				}
			}
		}

		public bool IsEnabled => !bool.Parse(DropDown.GetAttribute("aria-disabled"));

		public override bool IsBold => DropDown.GetIsBold();

		public override bool IsItalic => DropDown.GetIsItalic();

		public override string FontFamily => DropDown.GetFontFamily();

		public override string FontSize => DropDown.GetFontSize();

		public override string BackgroundColor => DropDown.GetBackgroundColor();

		public override string ForegroundColor => DropDown.GetForegroundColor();

		public override int Height => DropDown.Size.Height;

		protected internal DropDownListComponentWrapper(string context, IWebElement containerElement, AutomationClient client)
			: base(context, containerElement, client)
		{
			WaitForSelect();
		}

		private void WaitForSelect()
		{
			Wait.For(() => Select != null);
		}

		public void SelectByValue(string value)
		{
			foreach (Option option in Options)
			{
				if (option.Value == value)
				{
					SelectByText(option.Text);
					break;
				}
			}
		}

		public void SelectByText(string text)
		{
			AutomationTrace.WriteLine("Setting Dropdown to display value {0}", text);
			Func<string, bool> isExpectedText = delegate (string optionText)
			{
				if (string.Equals(optionText, text, StringComparison.InvariantCultureIgnoreCase))
				{
					AutomationTrace.WriteLine("{0}=={1}", text, optionText);
					return true;
				}
				AutomationTrace.WriteLine("{0}!={1}", text, optionText);
				return false;
			};
			Func<bool> openDropDown = delegate
			{
				AutomationTrace.WriteLine("Waiting for the drop down to open");
				return Wait.For(delegate
				{
					AutomationTrace.WriteLine("Clicking the drop down to open it");
					base.RootElement.ClickSafe(base.Client.Driver);
					return ListContainer != null && ListContainer.ExistsVisibleAndEnabled();
				}, 100, 10);
			};
			Func<bool> selectOption = delegate
			{
				AutomationTrace.WriteLine("Searching for the item to select");
				Wait.For(600);
				return Wait.For(delegate
				{
					foreach (IWebElement current in ListContainer.FindElementsSafe(By.TagName("li")))
					{
						if (current.Displayed && isExpectedText(current.Text))
						{
							current.ClickSafe(base.Client.Driver);
							return true;
						}
					}
					return false;
				}, 250, 40);
			};
			Func<bool> waitForCloseDropDown = delegate
			{
				AutomationTrace.WriteLine("Waiting for the drop down to close");
				return Wait.For(() => ListContainer == null, 200, 5);
			};
			int count = 0;
			do
			{
				count++;
				if (Wait.For(openDropDown))
				{
					if (!selectOption())
					{
						break;
					}
					while (!waitForCloseDropDown() && selectOption())
					{
					}
				}
			}
			while (!isExpectedText(SelectedText) && count < 5);
		}

		private void ScrollDown(int index)
		{
			for (int i = 0; i < index; i++)
			{
				//base.Client.SendKeys.Down();
			}
		}

		public bool WaitForBackingValues(params string[] expectedValues)
		{
			AutomationTrace.WriteLine(string.Format("Waiting for DropDown Backing Values to be [{0}]", string.Join(",", expectedValues)));
			return Wait.For(() => expectedValues.CompareLists(from item in Options
															  select item.Value));
		}

		public bool WaitForDisplayValues(params string[] expectedValues)
		{
			AutomationTrace.WriteLine(string.Format("Waiting for DropDown Display Values to be [{0}]", string.Join(",", expectedValues)));
			return Wait.For(() => expectedValues.CompareLists(from item in Options
															  select item.Text));
		}
	}
}

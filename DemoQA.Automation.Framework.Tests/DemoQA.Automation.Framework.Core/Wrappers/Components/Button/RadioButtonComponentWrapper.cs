using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Core.Wrappers.Components.Button
{
	public class RadioButtonComponentWrapper : BaseComponentWrapper
	{
		private IWebElement innerRadioButton;
		private IWebElement radioButton;

		private IWebElement innerLabel;

		public string Value => innerRadioButton.GetAttribute("value");

		public string Text => innerLabel.Text;

		public bool IsSelected => innerRadioButton.Selected;

		public bool IsEnabled => innerRadioButton.Enabled;

		protected internal RadioButtonComponentWrapper(string context, IWebElement containerElement, AutomationClient client)
			: base(context, containerElement, client)
		{
			innerRadioButton = base.RootElement.FindElementSafe(By.TagName("input"));
			innerLabel = base.RootElement.FindElementSafe(By.TagName("label"));
			radioButton = containerElement;
		}

		public void Click()
		{
			innerRadioButton.ClickSafe(base.Client.Driver);
		}

		public void ClickLabel()
		{
			innerLabel.ClickSafe(base.Client.Driver);
		}

		public void Select()
		{
			innerLabel.RequireExistsVisibleAndEnabled("hj-radio-button label");
			if (!IsSelected)
			{
				innerLabel.ScrollToElement(base.Client.Driver);
				ClickLabel();
			}
		}

		public void Unselect()
		{
			innerLabel.RequireExistsVisibleAndEnabled("hj-radio-button label");
			if (IsSelected)
			{
				ClickLabel();
			}
		}
	}
}

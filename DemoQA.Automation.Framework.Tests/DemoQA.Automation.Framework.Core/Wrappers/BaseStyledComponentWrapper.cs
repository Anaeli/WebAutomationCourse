namespace DemoQA.Automation.Core.Wrappers
{
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

	public abstract class BaseStyledComponentWrapper : BaseComponentWrapper
	{
		public abstract bool IsBold
		{
			get;
		}

		public abstract bool IsItalic
		{
			get;
		}

		public abstract string FontFamily
		{
			get;
		}

		public abstract string FontSize
		{
			get;
		}

		public abstract string BackgroundColor
		{
			get;
		}

		public abstract string ForegroundColor
		{
			get;
		}

		public abstract int Height
		{
			get;
		}

		protected internal BaseStyledComponentWrapper(string context, IWebElement rootElement, AutomationClient client)
			: base(context, rootElement, client)
		{
		}
	}

}

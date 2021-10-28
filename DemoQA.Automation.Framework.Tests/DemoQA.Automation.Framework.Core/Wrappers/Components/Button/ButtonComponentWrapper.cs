namespace DemoQA.Automation.Core.Wrappers.Components
{
    using DemoQA.Automation.Core.Extensions;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    public class ButtonComponentWrapper : BaseComponentWrapper
    {
        private readonly IWebElement button;

        public string Text { get { return this.button.Text; } }
        public bool IsEnabled { get { return button.IsVisibleAndEnabled(); } }

        public ButtonComponentWrapper(string context, IWebElement container, AutomationClient client)
        : base(context, container, client)
        {
            this.button = container;
        }

        public void Click()
        {
            this.button.ExistsVisibleAndEnabled();
            this.button.ClickSafe(Client.Driver);
        }

        public void ClickUsingJS(AutomationClient client)
        {
            this.Client.ClickUsingJS(this.button, client.Driver);
        }

        public void PerformClick(IWebElement element, AutomationClient client)
        {
            this.Client.ScrollIntoView(element);
            this.Client.ClickUsingJS(element, client.Driver);
        }

        public bool WaitForButton(int sleep = 150, int iterations = 20)
        {
            return Wait.For(() => button.IsVisibleAndEnabled() == true, sleep, iterations);
        }
    }
}

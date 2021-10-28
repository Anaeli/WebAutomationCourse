using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Core.Wrappers
{
    public abstract class BaseComponentWrapper : ElementWrapper
    {
        private readonly IWebElement rootElement;
        public bool IsDisplayed { get { return this.rootElement.isVisible(); } }

        protected BaseComponentWrapper(string context, IWebElement rootElement, AutomationClient client)
            : base(context, rootElement, client)
        {
            this.rootElement = rootElement;
        }
    }
}

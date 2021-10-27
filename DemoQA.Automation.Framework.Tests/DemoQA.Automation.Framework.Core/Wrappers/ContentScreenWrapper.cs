using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;

namespace DemoQA.Automation.Core.Wrappers
{
    public class ContentScreenWrapper : ElementWrapper
    {
        protected IWebElement Container { get { return base.RootElement; } }

        protected ContentScreenWrapper(IWebElement container, AutomationClient client)
            : base(string.Empty, container, client)
        {
        }
    }
}

using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using System.Linq;

namespace DemoQA.Automation.Core.Wrappers.Components
{
    public class TextBoxComponentWrapper : BaseComponentWrapper
    {
        private readonly IWebElement textBox;

        public string Text { get { return this.textBox.GetAttribute("value"); } }
        public string Placeholder { get { return this.textBox.GetAttribute("placeholder"); } }
        public bool IsEnabled { get { return this.textBox.IsVisibleAndEnabled(); } }
        public bool IsSelected { get { return this.textBox.Selected; } }
        public string TagName { get { return this.textBox.TagName; } }
        public bool HasWarnings { get { return this.textBox.GetAttribute("class").Split(' ').Contains("validationElement"); } }

        public string BorderColor { get { return this.textBox.GetCssValue("border-color"); } }
        

        public TextBoxComponentWrapper(string context, IWebElement container, AutomationClient client)
            : base(context, container, client)
        {
            this.textBox = container;
        }

        public void Click()
        {
            this.textBox.Click();
        }

        public void Clear()
        {
            this.textBox.Clear();
        }

        private void Type(string value)
        {
            System.Threading.Thread.Sleep(50);
            this.textBox.SendKeys(value);
        }

        private void TypeValue(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                System.Threading.Thread.Sleep(30);
                this.textBox.SendKeys(new string((value[i]), 1));
            }
        }

        public void SetValue(string value)
        {
            Click();
            Clear();
            Type(value);
        }

        public bool WaitForValue(string expectedValue, int sleep = 100, int iterations = 20)
        {
            return this.WaitFor(value => { return this.textBox.Text.Equals(expectedValue); }, sleep, iterations);
        }

        //public string GetValidationMessage(IWebDriver driver)
        //{
        //    var sibling = this.textBox.GetNextSibling(driver);
        //    return sibling.GetInnerHtml(driver);
        //}
    }
}

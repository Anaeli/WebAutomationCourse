using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQA.Automation.Core.Wrappers
{
    public abstract class KeysWrapper
    {
        public abstract void SendText(string textToSend);

        public void Enter()
        {
            SendText(Keys.Enter);
        }

        public void Up()
        {
            SendText(Keys.Up);
        }

        public void Left()
        {
            SendText(Keys.Left);
        }

        public void Right()
        {
            SendText(Keys.Right);
        }

        public void Tab()
        {
            SendText(Keys.Tab);
        }

        public void Down()
        {
            SendText(Keys.Down);
        }

        public void F1()
        {
            SendText(Keys.F1);
        }

        public void ControlA()
        {
            SendText(Keys.Control + "a" + Keys.Control);
        }

        public void ControlPlusKey(string key)
        {
            SendText(Keys.Control + key + Keys.Control);
        }

        public void ControlPlusLeftKey()
        {
            SendText(Keys.Control + Keys.Left + Keys.Control);
        }

        public void Delete()
        {
            SendText(Keys.Delete);
        }

        public void Backspace()
        {
            SendText(Keys.Backspace);
        }

        public void Escape()
        {
            SendText(Keys.Escape);
        }

        /// <summary>
        /// Creates a keys wrapper that will route the keys pressed to the active element on the screen.
        /// </summary>
        public static KeysWrapper ScreenKeys(AutomationClient client) { return new ScreenKeysWrapper(client); }

        /// <summary>
        /// Creates a keys wrapper that will route the keys pressed to a specific element on the screen.
        /// </summary>
        public static KeysWrapper ElementKeys(string context, IWebElement element, AutomationClient client) { return new ElementKeysWrapper(context, element, client); }

        public static KeysWrapper BrowserKeys(AutomationClient client)
        {
            return new BrowserKeysWrapper(client);
        }

        private class ScreenKeysWrapper : KeysWrapper
        {
            protected internal AutomationClient Client { get; private set; }

            public ScreenKeysWrapper(AutomationClient client)
            {
                Client = client;
            }

            public override void SendText(string textToSend)
            {
                new Actions(Client.Driver).SendKeys(textToSend).Perform();
            }            
        }

        private class ElementKeysWrapper : KeysWrapper
        {
            protected internal IWebElement Element { get; private set; }
            protected internal AutomationClient Client { get; private set; }
            protected internal string Context { get; private set; }

            public ElementKeysWrapper(string context, IWebElement element, AutomationClient client)
            {
                Context = context;
                Element = element;
                Client = client;
            }

            public override void SendText(string textToSend)
            {
                new Actions(Client.Driver).SendKeys(Element, textToSend).Perform();
            }
        }

        private class BrowserKeysWrapper : KeysWrapper
        {
            protected internal AutomationClient Client
            {
                get;
                private set;
            }

            public BrowserKeysWrapper(AutomationClient client)
            {
                Client = client;
            }

            public override void SendText(string textToSend)
            {
                AutomationTrace.WriteLine("Sending text [{0}] to the browser.", textToSend);
                new Actions(Client.Driver).SendKeys(textToSend).Perform();
            }
        }
    }
}

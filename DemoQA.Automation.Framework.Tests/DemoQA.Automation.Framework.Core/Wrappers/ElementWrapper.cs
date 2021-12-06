namespace DemoQA.Automation.Core.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using DemoQA.Automation.Core.Extensions;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;

    public class ElementWrapper
    {
        protected IWebElement RootElement { get; private set; }
        protected AutomationClient Client { get; private set; }
        protected string Context { get; private set; }
        public bool Exists { get { return RootElement.Exists(); } }
        public bool ExistsAndVisible { get { return RootElement.ExistsAndVisible(); } }
        public bool ExistsVisibleAndEnabled { get { return RootElement.ExistsVisibleAndEnabled(); } }

        /// <summary>
        /// Sends keyboard keys to this element.
        /// </summary>
        public virtual KeysWrapper SendKeys => KeysWrapper.ElementKeys(Context, RootElement, Client);

        protected internal ElementWrapper(string context, IWebElement element, AutomationClient client)
        {
            if (string.IsNullOrWhiteSpace(context))
            {
                context = GetType().Name;
            }

            Context = context;
            RootElement = element;
            Client = client;
        }

        /// <summary>
        /// Finds the first element by xpath
        /// </summary>
        protected internal IWebElement FindElementByXPath(string xpath)
        {
            return RootElement.FindElementSafe(By.XPath(xpath));
        }

        /// <summary>
        /// Finds the first element by css selector
        /// </summary>
        protected internal IWebElement FindElementByCssSelector(string selector)
        {
            return RootElement.FindElementSafe(By.CssSelector(selector));
        }

        /// <summary>
        /// Finds the first element by id
        /// </summary>
        protected internal IWebElement FindElementById(string id)
        {
            return RootElement.FindElementSafe(By.Id(id));
        }

        /// <summary>
        /// Finds the first element by class name
        /// </summary>
        protected internal IWebElement FindElementByClassName(string className)
        {
            return RootElement.FindElementSafe(By.ClassName(className));
        }

        /// <summary>
        /// Finds all elements by xpath
        /// </summary>
        protected internal IReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            return RootElement.FindElementsSafe(By.XPath(xpath));
        }

        /// <summary>
        /// Finds all elements by css selector
        /// </summary>
        protected internal IReadOnlyCollection<IWebElement> FindElementsByCssSelector(string selector)
        {
            return RootElement.FindElementsSafe(By.CssSelector(selector));
        }

        /// <summary>
        /// Finds all elements by id
        /// </summary>
        protected internal IReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return RootElement.FindElementsSafe(By.Id(id));
        }

        /// <summary>
        /// Finds all elements by class name
        /// </summary>
        protected internal IReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return RootElement.FindElementsSafe(By.ClassName(className));
        }

        /// <summary>
        /// Creates the component wrapper for the element
        /// </summary>
        public tComponentWrapperType CreateComponentWrapper<tComponentWrapperType>(string context, IWebElement containerElement) where tComponentWrapperType : BaseComponentWrapper
        {
            return CreateWrapper<tComponentWrapperType>(context, containerElement);
        }

        /// <summary>
        /// Creates the wrapper for the element
        /// </summary>
        public tWrapperType CreateWrapper<tWrapperType>(string context, IWebElement containerElement) where tWrapperType : ElementWrapper
        {
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            return (tWrapperType)Activator.CreateInstance(typeof(tWrapperType), flags, null, new object[] { context, containerElement, Client }, null);
        }

        public tElementWrapperType WaitForWrapper<tElementWrapperType>(string testId, int sleep = 3000, int iterations = 30) where tElementWrapperType : ElementWrapper
        {
            return WaitForWrapper<tElementWrapperType>(testId, FindBy.TestId(testId), sleep, iterations);
        }

        public tElementWrapperType WaitForWrapper<tElementWrapperType>(string context, By by, int sleep = 3000, int iterations = 30) where tElementWrapperType : ElementWrapper
        {
            IWebElement containerElement = null;
            Wait.For(() => { return (containerElement = RootElement.FindElementSafe(by)).ExistsAndVisible() == true; }, sleep, iterations);

            return CreateWrapper<tElementWrapperType>(context, containerElement);
        }

        public tElementWrapperType WaitForWrapper<tElementWrapperType>(IWebElement container, By by, int sleep = 3000, int iterations = 30) where tElementWrapperType : ElementWrapper
        {
            IWebElement containerElement = null;
            Wait.For(() => { return (containerElement = container.FindElementSafe(by)).ExistsAndVisible() == true; }, sleep, iterations);

            return CreateWrapper<tElementWrapperType>("", containerElement);
        }

        // <summary>
        // Finds the element by TestId
        // </summary>
        public IWebElement FindElement(string testId)
        {
            return RootElement.FindElementSafe(FindBy.TestId(testId));
        }

        public IWebElement FindElement(By by)
        {
            return RootElement.FindElementSafe(by);
        }

        public IWebElement FindElement(IWebElement container, By by)
        {
            return RootElement.FindElementSafe(by);
        }

        // <summary>
        // Finds all elements by TestId
        // </summary>
        public IReadOnlyCollection<IWebElement> FindElements(string testId)
        {
            return RootElement.FindElementsSafe(FindBy.TestId(testId));
        }

        /// <summary>
        /// Find Elements and contains a waiter
        /// </summary>
        public ReadOnlyCollection<IWebElement> WaitFindElements(IWebElement container, By by, int sleep = 300, int iteration = 50)
        {
            var menu = container.FindElements(by);
            if (menu == null && iteration > 0)
            {
                Wait.For(sleep);
                return WaitFindElements(container, by, --iteration);
            }
            else
            {
                return menu;
            }
        }

        /// <summary>
        /// Finds the wrapper
        /// </summary>
        public tWrapperType FindWrapper<tWrapperType>(string context, IWebElement element) where tWrapperType : ElementWrapper
        {
            return CreateWrapper<tWrapperType>(context, element);
        }

        /// <summary>
        /// Finds the wrapper by TestId
        /// </summary>
        public tWrapperType FindWrapper<tWrapperType>(string testId) where tWrapperType : ElementWrapper
        {
            var containerElement = RootElement.FindElementSafe(FindBy.TestId(testId));
            return CreateWrapper<tWrapperType>(testId, containerElement);
        }

        /// <summary>
        /// Finds the wrapper by TestId in a container
        /// </summary>
        public tWrapperType FindWrapper<tWrapperType>(IWebElement container, string testId) where tWrapperType : ElementWrapper
        {
            var containerElement = container.FindElementSafe(FindBy.TestId(testId));
            return CreateWrapper<tWrapperType>(testId, containerElement);
        }

        /// <summary>
        /// Finds the wrapper by search criteria in a container
        /// </summary>
        public tWrapperType FindWrapper<tWrapperType>(IWebElement container, By by) where tWrapperType : ElementWrapper
        {
            var containerElement = container.FindElementSafe(by);
            return CreateWrapper<tWrapperType>("wrapper", containerElement);
        }

        /// <summary>
        /// Finds the base component and returns specified wrapper
        /// </summary>
        public tComponentType FindComponentWrapper<tComponentType>(string context, IWebElement element) where tComponentType : BaseComponentWrapper
        {
            return CreateComponentWrapper<tComponentType>(context, element);
        }

        /// <summary>
        /// Finds the base component by TestId and returns specified wrapper
        /// </summary>
        public tComponentType FindComponentWrapper<tComponentType>(string testId) where tComponentType : BaseComponentWrapper
        {
            var containerElement = RootElement.FindElementSafe(FindBy.TestId(testId));
            return CreateComponentWrapper<tComponentType>(testId, containerElement);
        }

        /// <summary>
        /// Finds the base component by TestId in a container and returns specified wrapper
        /// </summary>
        public tComponentType FindComponentWrapper<tComponentType>(IWebElement container, string testId) where tComponentType : BaseComponentWrapper
        {
            var containerElement = container.FindElementSafe(FindBy.TestId(testId));
            return CreateWrapper<tComponentType>(testId, containerElement);
        }
    }
}

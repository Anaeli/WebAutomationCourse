using DemoQA.Automation.Core.Extensions;
using DemoQA.Automation.Core.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;
using System.Reflection;

namespace DemoQA.Automation.Framework.Core
{
    public class AutomationClient
    {
        private IWebDriver driver;
        private static AutomationClient instance;
        protected static WebDriverWait WebDriverWait { get; set; }

        private AutomationClient()
        {
            InitWebDriver();
        }

        public static AutomationClient Instance => instance ?? (instance = new AutomationClient());

        public IWebDriver Driver
        {
            get
            {
                return driver;

            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return WebDriverWait;
            }
        }

        public IWebDriver InitWebDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AutomationSettings.ImplicitWait);
            WebDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(AutomationSettings.ExplicitWait));
            return driver;
        }

        public void GoToPage(string appURL)
        {
            driver.Navigate().GoToUrl(appURL);
        }

        public void QuitDriver()
        {
            try
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                driver?.Close();
            }
            catch (WebDriverException e)
            {
                Console.WriteLine("Error closing the driver: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Quiting current driver...");
                driver?.Quit();
                driver?.Dispose();
                driver = null;
            }
        }

        public void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoViewIfNeeded(true);", element);
        }

        public void ClickUsingJS(IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// Automates a VSCode wrapper based on ContentScreenWrapper
        /// </summary>
        public void AutomateActivePage<tContentScreenWrapper>(Action<tContentScreenWrapper> automate) where tContentScreenWrapper : ContentScreenWrapper
        {
            tContentScreenWrapper wrapper = null;

            var container = driver.FindElementSafe(By.ClassName("body-height"));
            if (container.ExistsAndVisible())
            {
                wrapper = CreateWrapper<tContentScreenWrapper>("Content screen", container);
            }

            automate(wrapper);
        }

        /// <summary>
        /// Creates a wrapper based on ContentScreenWrapper
        /// </summary>
        private tContentScreenWrapper CreateWrapper<tContentScreenWrapper>(string context, IWebElement container) where tContentScreenWrapper : ContentScreenWrapper
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance;
            object[] paremeters = { container, this };

            return (tContentScreenWrapper)Activator.CreateInstance(typeof(tContentScreenWrapper), bindingFlags, (Binder)null, paremeters, (CultureInfo)null);
        }
    }
}

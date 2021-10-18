using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoQA.Automation.Framework.Core
{
    public class AutomationClient
    {
        private IWebDriver driver;
        private static AutomationClient instance;


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

        public IWebDriver InitWebDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
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
    }
}

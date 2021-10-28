using OpenQA.Selenium;
using System.Net;

namespace DemoQA.Automation.Core.Extensions
{
    internal static class WebDriverExtensions
    {
        public static IWebElement FindElementSafe(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch (WebException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            return null;
        }
    }
}

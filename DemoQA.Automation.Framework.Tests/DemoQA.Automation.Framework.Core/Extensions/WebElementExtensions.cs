namespace DemoQA.Automation.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    internal static class WebElementExtensions
    {
        public static void MoveMouseTo(this IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();
        }

        public static void ClickSafe(this IWebElement element, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            try
            {
                element.ScrollToElement(driver);
                builder.Click(element);
                builder.Build().Perform();
            }
            catch (Exception ex)
            {
                AutomationTrace.WriteLine(ex.Message);
            }
        }

        public static void ScrollToElement(this IWebElement webElement, IWebDriver driver)
        {
            AutomationTrace.WriteLine("Element isn't into visible area: " + webElement.TagName);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoViewIfNeeded(true);", webElement);
        }

        public static void DoubleClickSafe(this IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element);
            actions.Build().Perform();
        }

        public static IWebElement FindElementSafe(this IWebElement searchRoot, By by)
        {
            if (searchRoot == null)
            {
                return null;
            }
            try
            {
                return searchRoot.FindElement(by);
            }
            catch (WebException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            return null;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsSafe(this IWebElement searchRoot, By by)
        {
            if (searchRoot == null)
            {
                return new ReadOnlyCollection<IWebElement>(new Collection<IWebElement>());
            }
            try
            {
                return searchRoot.FindElements(by);
            }
            catch (WebException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            return new ReadOnlyCollection<IWebElement>(new Collection<IWebElement>());
        }

        public static ReadOnlyCollection<IWebElement> Children(this IWebElement searchRoot, string tagName = "*")
        {
            if (searchRoot == null)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
            try
            {
                return searchRoot.FindElements(By.XPath(tagName));
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (NoSuchElementException)
            {
            }
            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        public static bool Exists(this IWebElement element)
        {
            if (element == null)
            {
                return false;
            }
            return true;
        }

        public static bool ExistsAndVisible(this IWebElement element)
        {
            try
            {
                return element.Exists() && element.Displayed;
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (InvalidCastException)
            {
            }
            return false;
        }

        public static bool ExistsVisibleAndEnabled(this IWebElement element)
        {
            try
            {
                return element.ExistsAndVisible() && element.Enabled && !element.HasClass("disabled");
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (InvalidCastException)
            {
            }
            return false;
        }

        public static bool isVisible(this IWebElement element)
        {
            return element.ExistsAndVisible();
        }

        public static bool IsVisibleAndEnabled(this IWebElement element)
        {
            return element.ExistsVisibleAndEnabled();
        }

        public static void RequireExists(this IWebElement element, string elementName)
        {
            if (!element.Exists())
            {
                throw new InvalidOperationException(elementName + " is required to exist.");
            }
        }

        public static void RequireExistsAndVisible(this IWebElement element, string elementName)
        {
            if (!element.ExistsAndVisible())
            {
                throw new InvalidOperationException(elementName + " is required to exist and be visible.");
            }
        }

        public static void RequireExistsVisibleAndEnabled(this IWebElement element, string elementName)
        {
            if (!element.ExistsVisibleAndEnabled())
            {
                throw new InvalidOperationException(elementName + " is required to exist, be visible and enabled.");
            }
        }

        public static IWebElement GetNextSibling(this IWebElement element, IWebDriver driver)
        {
            return (IWebElement)(driver as IJavaScriptExecutor).ExecuteScript("return arguments[0].nextSibling", element);
        }

        public static string GetHiddenText(this IWebElement element, IWebDriver driver)
        {
            return (string)(driver as IJavaScriptExecutor).ExecuteScript("return arguments[0].textContent", element);
        }

        public static long GetDepth(this IWebElement element, IWebDriver driver)
        {
            return (long)(driver as IJavaScriptExecutor).ExecuteScript("return $(arguments[0]).parents().length", element);
        }

        internal static bool GetIsBold(this IWebElement element)
        {
            bool value = false;
            if (element != null)
            {
                value = (element.GetCssValue("font-weight") == "bold" || element.GetCssValue("font-weight") == "700");
            }
            return value;
        }

        internal static bool GetIsItalic(this IWebElement element)
        {
            bool value = false;
            if (element != null)
            {
                value = (element.GetCssValue("font-style") == "italic");
            }
            return value;
        }

        internal static string GetFontFamily(this IWebElement element)
        {
            string value = string.Empty;
            if (element != null)
            {
                value = element.GetCssValue("font-family").Replace("\"", "");
            }
            return value;
        }

        internal static string GetFontSize(this IWebElement element)
        {
            string value = string.Empty;
            if (element != null)
            {
                value = element.GetCssValue("font-size");
            }
            return value;
        }

        internal static double GetFontSizeAsDouble(this IWebElement element)
        {
            double value = 0.0;
            if (element != null)
            {
                value = double.Parse(element.GetFontSize().Replace("px", string.Empty));
            }
            return value;
        }

        internal static double GetFontSizeNumber(this IWebElement element)
        {
            double value = 0.0;
            if (element != null)
            {
                value = double.Parse(element.GetCssValue("font-size").Replace("px", string.Empty));
            }
            return value;
        }

        internal static string GetBackgroundColor(this IWebElement element)
        {
            string value = string.Empty;
            if (element != null)
            {
                value = RgbaColorToHexColor(element.GetCssValue("background-color")).ToLowerInvariant();
            }
            return value;
        }

        internal static string GetForegroundColor(this IWebElement element)
        {
            string value = string.Empty;
            if (element != null)
            {
                value = RgbaColorToHexColor(element.GetCssValue("color")).ToLowerInvariant();
            }
            return value;
        }

        private static string RgbaColorToHexColor(string rgba)
        {
            if ("transparent".Equals(rgba, StringComparison.OrdinalIgnoreCase))
            {
                return "#000000";
            }
            string[] hexValues = rgba.ToLowerInvariant().Replace("rgba(", "").Replace("rgb(", "")
                .Replace(")", "")
                .Split(new char[1]
                {
                ','
                }, StringSplitOptions.RemoveEmptyEntries);
            if (hexValues.Length < 3)
            {
                return rgba;
            }
            int alpha = (hexValues.Length == 4) ? Convert.ToInt32(float.Parse(hexValues[3]) * 255f) : 255;
            int red = int.Parse(hexValues[0]);
            int green = int.Parse(hexValues[1]);
            int blue = int.Parse(hexValues[2]);
            return ColorTranslator.ToHtml(Color.FromArgb(alpha, red, green, blue));
        }

        internal static string GetTextAlignment(this IWebElement element)
        {
            string value = string.Empty;
            if (element != null)
            {
                value = element.GetCssValue("text-align");
            }
            return value;
        }

        internal static string GetTransform(this IWebElement element)
        {
            string value = string.Empty;
            if (element != null)
            {
                value = element.GetCssValue("transform");
            }
            return value;
        }

        internal static bool HasClass(this IWebElement element, string className)
        {
            return element.GetAttribute("class").Split(' ').Contains(className);
        }

        internal static void Unfocus(this IWebElement element, IWebDriver driver)
        {
            (driver as IJavaScriptExecutor).ExecuteScript("arguments[0].focus(); arguments[0].blur(); return true", element);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoQA.Automation.Framework.Wrappers
{
    public class PracticeFormWrapper
    {
        private IWebDriver driver;

        public PracticeFormWrapper()
        {
            driver = new ChromeDriver();
        }

        public IWebElement NameTextBox => driver.FindElement(By.Id("firstName"));

        public IWebElement LastNameTextBox => driver.FindElement(By.Id("lastName"));

        public void GoToPage()
        {
            string appURL = "https://demoqa.com/automation-practice-form";
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
    }
}

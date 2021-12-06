using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoQA.Automation.Framework.Wrappers.Students
{
    public class ECRPracticeTextBoxWrapper
    {
        private IWebDriver driver;
        public ECRPracticeTextBoxWrapper()
        {
            driver = new ChromeDriver();
        }
        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public void GoToPage()
        {
            string appURL = "https://demoqa.com/text-box";
            driver.Navigate().GoToUrl(appURL);
        }

        public void QuitDriver()
        {
            try
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            catch(WebDriverException e)
            {
                Console.WriteLine("Error closing the driver: " + e.Message);
            }
            finally
            {
                Console.Write("Quiting current driver...");
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}

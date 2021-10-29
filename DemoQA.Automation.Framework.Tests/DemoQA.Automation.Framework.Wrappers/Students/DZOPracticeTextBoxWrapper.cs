using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoQA.Automation.Framework.Wrappers.Students
{
    public class DZOPracticeTextBoxWrapper
    {
        private IWebDriver driver;
        public DZOPracticeTextBoxWrapper()
        {
            driver = new ChromeDriver();
        }
        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));
        public IWebElement CurrentAddressTextBox => driver.FindElement(By.Id("currentAddress"));
        public IWebElement PermanentAddressTextBox => driver.FindElement(By.Id("permanentAddress"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));
        public IWebElement OutputTextBox => driver.FindElement(By.Id("output"));

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

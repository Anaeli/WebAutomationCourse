using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace DemoQA.Automation.Framework.Wrappers
{
    public class MCPracticeTextBoxWrapper
    {
        private IWebDriver driver;

        public MCPracticeTextBoxWrapper()
        {
            driver = new ChromeDriver();
        }

        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public IWebElement CurrentAddress => driver.FindElement(By.Id("currentAddress"));
        
        public IWebElement PermanentAddress => driver.FindElement(By.Id("permanentAddress"));

        public IWebElement OTable => driver.FindElement(By.Id("output"));

        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));



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

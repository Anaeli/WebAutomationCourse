using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.Automation.Framework.Wrappers.Students
{
    public class JCPracticeTextBoxWrapper
    {
        // Web driver constructor
        private readonly IWebDriver driver = AutomationClient.Instance.Driver;

        public JCPracticeTextBoxWrapper()
        {
           // driver = new ChromeDriver();
        }

        // Mapping form fields
        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));
        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));
        public IWebElement CurrentAddress => driver.FindElement(By.Id("currentAddress"));
        public IWebElement PermanentAddress => driver.FindElement(By.Id("permanentAddress"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        // Mapping output frame
        public IWebElement output_Name => driver.FindElement(By.Id("name"));
        public IWebElement output_Email => driver.FindElement(By.Id("email"));
        public IWebElement output_CurrentAddress => driver.FindElement(By.XPath("//p[@id='currentAddress']"));
        public IWebElement output_PermanentAddress => driver.FindElement(By.XPath("//p[@id='permanentAddress']"));

        // Navigate to URL
        public void GoToPage()
        {
            string appURL = "https://demoqa.com/text-box";
            driver.Navigate().GoToUrl(appURL);
        }

        // Close webdriver instance
   /*     public void QuitDriver()
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
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium.Interactions;

namespace DemoQA.Automation.Framework.Wrappers
{
    public class RTTextBoxFormWrapper
    {

        private IWebDriver driver;
        public RTTextBoxFormWrapper()
        {
            driver = new ChromeDriver();
        }

        public IWebElement FullNameTextBox => driver.FindElement(By.Id("userName"));

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));
        public IWebElement CurrentAddress => driver.FindElement(By.Id("currentAddress"));
        public IWebElement PermanentAddress => driver.FindElement(By.Id("permanentAddress"));
        public IWebElement OutputTable => driver.FindElement(By.Id("output"));
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
        public void ClickSubmitButton()
        {
            
            ClickUsingJS(SubmitButton);
        }
        public void ClickUsingJS(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }
        public static implicit operator RTTextBoxFormWrapper(PracticeFormWrapper v)
        {
            throw new NotImplementedException();
        }


    }
}
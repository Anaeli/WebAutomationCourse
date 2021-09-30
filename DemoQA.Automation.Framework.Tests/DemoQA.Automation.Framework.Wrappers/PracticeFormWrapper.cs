using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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

        public IWebElement EmailTextBox => driver.FindElement(By.Id("userEmail"));

        public IWebElement MaleRadioButton => driver.FindElement(By.Id("gender-radio-1"));
        public IWebElement FemaleRadioButton => driver.FindElement(By.Id("gender-radio-2"));

        public IWebElement OtherRadioButton => driver.FindElement(By.Id("gender-radio-3"));

        public IWebElement MobileNumberTextBox => driver.FindElement(By.Id("userNumber"));

        public IWebElement DateOfBirth => driver.FindElement(By.Id("dateOfBirthInput"));

        public IWebElement StateDropDown => driver.FindElement(By.Id("state"));


        public void SelectGenderRadioButton(string gender)
        {
            switch (gender.ToLower())
            {
                case "female":
                    PerformAction(FemaleRadioButton, driver);
                    break;
                case "male":
                    PerformAction(MaleRadioButton, driver);
                    break;
                case "Other":
                    PerformAction(OtherRadioButton, driver);
                    break;
            }
        }


        public void FillDateOfBirth(string date)
        {
            DateOfBirth.SendKeys(Keys.Control + "a");
            DateOfBirth.SendKeys(date);
            DateOfBirth.SendKeys(Keys.Enter);
        }

        public void PerformAction(IWebElement element, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.Click(element);
            builder.Build().Perform();
        }

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


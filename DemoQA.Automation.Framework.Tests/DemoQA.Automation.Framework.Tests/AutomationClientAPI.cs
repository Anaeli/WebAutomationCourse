using Docker.DotNet.Models;
using OpenQA.Selenium;
using RestSharp;
using System;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationClientAPI
    {
        public RestClient RestClient;
        
        private IWebDriver driver;

        private static AutomationClientAPI instance;
        private AutomationClientAPI()
        {
            RestClient = new RestClient("https://demoqa.com");
        }

        public static AutomationClientAPI Instance => instance ?? (instance = new AutomationClientAPI());

        public RestRequest GetBookRequest
        {
            get
            {
                return new RestRequest("/BookStore/v1/Book", Method.GET, DataFormat.Json);
            }
        }

        public RestRequest GetBooksRequest
        {
            get
            {
                return new RestRequest("/BookStore/v1/Books", Method.GET, DataFormat.Json);
            }
        }

        //public void GoToPage(string appURL)
        //{
        //    driver.Navigate().GoToUrl(appURL);
        //}

        public RestRequest PostBooksRequest
        {
            get
            {
                return new RestRequest("/BookStore/v1/Books", Method.POST, DataFormat.Json);
            }
        }

        public RestRequest PostUserRequest
        {
            get
            {
                return new RestRequest("/Account/v1/User", Method.POST);
            }
        }
    }
}

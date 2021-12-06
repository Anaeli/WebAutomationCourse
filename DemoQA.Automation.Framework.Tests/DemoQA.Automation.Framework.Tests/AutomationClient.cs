using RestSharp;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationClientApi
    {
        public RestClient RestClient;

        private static AutomationClientApi instance;
        private AutomationClientApi()
        {
            RestClient = new RestClient("https://demoqa.com");
        }

        public static AutomationClientApi Instance => instance ?? (instance = new AutomationClientApi());

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

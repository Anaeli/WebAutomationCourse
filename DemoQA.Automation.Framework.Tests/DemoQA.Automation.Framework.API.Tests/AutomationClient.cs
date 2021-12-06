using RestSharp;

namespace DemoQA.Automation.Framework.BDD.API
{
    public class AutomationClient
    {
        public RestClient RestClient;

        private static AutomationClient instance;
        private AutomationClient()
        {
            RestClient = new RestClient("https://demoqa.com");
        }

        public static AutomationClient Instance => instance ?? (instance = new AutomationClient());

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

using RestSharp;

namespace DemoQA.Automation.Framework.Tests
{
    
    public class AutomationTestBaseApi
    {
        public RestClient RestClient = AutomationClientApi.Instance.RestClient;
        public AutomationClientApi Fixture = AutomationClientApi.Instance;
    }
}


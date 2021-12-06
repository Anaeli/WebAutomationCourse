using RestSharp;

namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationTestBaseAPI
    {
        public RestClient RestClient = AutomationClientAPI.Instance.RestClient;
        public AutomationClientAPI Fixture = AutomationClientAPI.Instance;
    }
}

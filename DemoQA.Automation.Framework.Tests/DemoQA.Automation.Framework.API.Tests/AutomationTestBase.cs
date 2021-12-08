using RestSharp;

namespace DemoQA.Automation.Framework.BDD.API
{
    public class AutomationTestBase
    {
        public RestClient RestClient = AutomationClient.Instance.RestClient;
        public AutomationClient Fixture = AutomationClient.Instance;
    }
}

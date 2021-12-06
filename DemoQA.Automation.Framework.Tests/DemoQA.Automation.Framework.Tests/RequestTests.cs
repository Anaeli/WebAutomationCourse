using DemoQA.Automation.Framework.Tests.Entities;
using RestSharp;
using Xunit;

namespace DemoQA.Automation.Framework.Tests
{
    public class RequestTests : AutomationTestBaseApi
    {

        private readonly RestClient ApiClient;

        public RequestTests()
        {
            ApiClient = this.RestClient;
        }

    }
}
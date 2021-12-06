using DemoQA.Automation.Framework.Core;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.BDD.Tests.StepsDefinitions.Common
{
    [Binding]
    public class CommonSteps: AutomationTestBase
    {
        private readonly AutomationClient client;
        private readonly string urlPage = "demoqa.com/{0}";

        public CommonSteps(ITestOutputHelper output): base(output)
        {
            client = AutomationClient.Instance;
        }

        [Given(@"I go to ""(.*)"" page")]
        public void GivenIGoToPage(string url)
        {
            client.GoToPage($"https://{string.Format(urlPage, url)}");
        }
    }
}

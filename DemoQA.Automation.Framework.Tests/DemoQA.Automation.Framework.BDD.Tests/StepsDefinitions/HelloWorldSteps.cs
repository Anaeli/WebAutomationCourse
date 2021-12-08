using DemoQA.Automation.Framework.Utilities;
using TechTalk.SpecFlow;
using Xunit;

namespace DemoQA.Automation.Framework.BDD.Tests.StepsDefinitions
{
    [Binding]
    public class HelloWorldSteps
    {
        private readonly AddNumbers add;

        private int result;
        public HelloWorldSteps()
        {
            add = new AddNumbers();
        }


        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num1)
        {
            add.Num1 = num1;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int num2)
        {
            add.Num2 = num2;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            result = add.Add(add.Num1, add.Num2);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.Equal(result, p0);
        }
    }
}

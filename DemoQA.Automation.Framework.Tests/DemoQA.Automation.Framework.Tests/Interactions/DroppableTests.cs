using DemoQA.Automation.Core.ReportManager;
using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DemoQA.Automation.Framework.Tests.Interactions
{
    public class DroppableTests: AutomationTestBase
    {
        public DroppableTests(AutomationFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
            TestCase.SetTestFailed();
            AutomationClient.Instance.GoToPage("https://demoqa.com/droppable");
        }

        [Fact]
        public void TestDragAndDrop()
        {
            try
            {
                IWebElement dragFrom = this.driver.FindElement(By.Id("draggable"));
                IWebElement dropTo = this.driver.FindElement(By.Id("droppable"));

                //Target
                IAction dragAndDrop = new Actions(this.driver).ClickAndHold(dragFrom)
                        .MoveToElement(dropTo).Release(dropTo).Build();
                dragAndDrop.Perform();

                //Or
                //new Actions(this.driver).ClickAndHold(dragFrom)
                //    .MoveToElement(dropTo)
                //    .Release(dropTo)
                //    .Build()
                //    .Perform();

                Assert.Equal("Dropped", dropTo.Text);
                TestCase.SetTestPassed();
            }
            catch(Exception e)
            {
                TestCase.SetErrorMessage(e.Message);
                throw e;
            }
        }
    }
}

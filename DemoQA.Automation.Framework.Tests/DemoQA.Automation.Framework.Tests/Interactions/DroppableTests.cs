using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Interactions
{
    public class DroppableTests: AutomationTestBase
    {
        public DroppableTests(AutomationFixture fixture) : base(fixture)
        {
            AutomationClient.Instance.GoToPage("https://demoqa.com/droppable");
        }

        [Fact]
        public void TestDragAndDrop()
        {
            IWebElement dragFrom = this.Driver.FindElement(By.Id("draggable"));
            IWebElement dropTo = this.Driver.FindElement(By.Id("droppable"));

            //Target
            IAction dragAndDrop = new Actions(this.Driver).ClickAndHold(dragFrom)
                    .MoveToElement(dropTo).Release(dropTo).Build();
            dragAndDrop.Perform();

            //Or
            //new Actions(this.driver).ClickAndHold(dragFrom)
            //    .MoveToElement(dropTo)
            //    .Release(dropTo)
            //    .Build()
            //    .Perform();

            Assert.Equal("Dropped!", dropTo.Text);
        }

    }
}

using DemoQA.Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Interactions
{
    public class ResizableTests : AutomationTestBase
    {
        public ResizableTests(AutomationFixture fixture) : base(fixture)
        {
            AutomationClient.Instance.GoToPage("https://demoqa.com/resizable");
        }

        [Fact]
        public void TestDragSlider()
        {
            IWebElement box = this.driver.FindElement(By.Id("resizableBoxWithRestriction"));

            Assert.Equal("width: 200px; height: 200px;", box.GetAttribute("style"));

            IWebElement elem = this.driver.FindElement(By.ClassName("react-resizable-handle"));

            new Actions(this.driver).DragAndDropToOffset(elem, 260, 100).Build().Perform();

            Assert.Equal("width: 460px; height: 300px;", box.GetAttribute("style"));
        }

    }
}

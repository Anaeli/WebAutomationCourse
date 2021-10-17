using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows;
using System;
namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationFixture
    {
        public PracticeFormWrapper PracticeForm { get; private set; }
        public BrowserWindowsWrapper BrowserWindows { get; private set; }

        public FramesWrappers Frames { get; private set; }

        public AlertsWrapper Alerts { get; private set; }

        public AutomationFixture()
        {
            PracticeForm = new PracticeFormWrapper();
            BrowserWindows = new BrowserWindowsWrapper();
            Frames = new FramesWrappers();
            Alerts = new AlertsWrapper();
        }
    }
}

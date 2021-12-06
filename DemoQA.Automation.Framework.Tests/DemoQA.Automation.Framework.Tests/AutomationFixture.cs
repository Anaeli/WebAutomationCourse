﻿using DemoQA.Automation.Framework.Wrappers;
using DemoQA.Automation.Framework.Wrappers.AlertsFrameWindows;
using DemoQA.Automation.Wrappers.Elements;
using DemoQA.Automation.Framework.Wrappers.Students;
using DemoQA.Automation.Framework.Wrappers.BookStore;
using System;
namespace DemoQA.Automation.Framework.Tests
{
    public class AutomationFixture
    {
        public BrowserWindowsWrapper BrowserWindows { get; private set; }

        public FramesWrappers Frames { get; private set; }

        public AlertsWrapper Alerts { get; private set; }

        public DynamicPropertiesWrapper Dynamic { get; private set; }

        public RTBookStoreApplicationWrapper rtBookStoreApplicationWrapper { get; private set; }

        public AutomationFixture()
        {
            BrowserWindows = new BrowserWindowsWrapper();
            Frames = new FramesWrappers();
            Alerts = new AlertsWrapper();
            Dynamic = new DynamicPropertiesWrapper();
            rtBookStoreApplicationWrapper = new RTBookStoreApplicationWrapper();
        }
    }
}

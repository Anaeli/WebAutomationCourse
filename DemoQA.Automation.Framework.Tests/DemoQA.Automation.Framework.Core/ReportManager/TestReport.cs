namespace DemoQA.Automation.Core.ReportManager
{
    using System;
    using System.IO;
    using System.Reflection;
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Reporter;
    using DemoQA.Automation.Framework.Core;
    using OpenQA.Selenium;
    using Xunit.Abstractions;

    /// <summary>
    /// Test report helper class.
    /// </summary>
    public class TestReport
    {
        /// <summary>
        /// Gets or sets extent report.
        /// </summary>
        private static ExtentReports Extent { get; set; }

        /// <summary>
        /// Gets or sets reporter instance.
        /// </summary>
        private static ExtentHtmlReporter Reporter { get; set; }

        /// <summary>
        /// Gets or sets Test instance.
        /// </summary>
        private static ExtentTest Test { get; set; }

        /// <summary>
        /// Gets or sets report path file information.
        /// </summary>
        private static string ReportPathFile { get; set; }

        /// <summary>
        /// Gets or sets report path information.
        /// </summary>
        private static string ReportPath { get; set; }

        /// <summary>
        /// Gets extent instance.
        /// </summary>
        /// <returns>New extent instance.</returns>
        public static ExtentReports GetExtent()
        {
            if (Extent != null)
            {
                return Extent;
            }

            Extent = new ExtentReports();
            Reporter = new ExtentHtmlReporter(GetPathInfo().Item2);
            Reporter.AppendExisting = true;
            Reporter.Configuration().DocumentTitle = "Web Automation Course";
            Reporter.Configuration().ReportName = "Automation Report";
            Reporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            Reporter.Configuration().Encoding = "UTF-8";
            Extent.AttachReporter(Reporter);
            Extent.AddSystemInfo("App Version", "App Version");
            Extent.AddSystemInfo("Environment", "Server Name");
            Extent.AddSystemInfo("User", "UserName");
            return Extent;
        }

        /// <summary>
        /// Create a test.
        /// </summary>
        /// <param name="testName">Test name.</param>
        /// <returns>Test created</returns>
        public static ExtentTest CreateTest(string testName)
        {
            return Extent.CreateTest(testName);
        }

        /// <summary>
        /// Set test status to Pass.
        /// </summary>
        /// <param name="message">Pass message.</param>
        /// <param name="output">Output instance.</param>
        public static void SetTestPass(string message, ITestOutputHelper output)
        {
            Test = CreateTest(GetTest(output).TestCase.DisplayName);
            Test.Pass(message);
            Extent.Flush();
        }

        /// <summary>
        /// Method to define the report file path.
        /// </summary>
        /// <returns>Report paths.</returns>
        public static Tuple<string, string> GetPathInfo()
        {
            DateTime time = DateTime.Now;
            string todayDate = $"{time.ToString("yyyy-MM-dd")}";
            string todayTime = $"{time.ToString("HH-mm-ss")}";
            //Changed E: to F: beacause there is no E: drive in my PC
            string reportPath = $"F:\\Report\\{todayDate}";
            string reportFile = $"{reportPath}\\Report.html";
            string path = $"{reportPath}\\{todayTime}";
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            Tuple<string, string> values = new Tuple<string, string>(path, reportFile);
            return values;
        }

        /// <summary>
        /// Gets output test value.
        /// </summary>
        /// <param name="output">Output helper.</param>
        /// <returns>Test value.</returns>
        public static ITest GetTest(ITestOutputHelper output)
        {
            Type type = output.GetType();
            FieldInfo testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            return (ITest)testMember.GetValue(output);
        }

        /// <summary>
        /// Takes screenshot.
        /// </summary>
        /// <param name="output">Output helper.</param>
        /// <param name="client">Automation client.</param>
        public static void TakeScreenshot(ITestOutputHelper output, AutomationClient client)
        {
            string screenshotName = $"{GetPathInfo().Item1}testcase.png";
            Screenshot screenshot = ((ITakesScreenshot)client.Driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
            Test = CreateTest(GetTest(output).TestCase.DisplayName);
            Test.Fail(TestCase.ErrorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotName).Build());
            Extent.Flush();
        }
    }
}

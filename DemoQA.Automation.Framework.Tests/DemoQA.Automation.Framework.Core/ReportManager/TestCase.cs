namespace DemoQA.Automation.Core.ReportManager
{ 
    /// <summary>
    /// Test case status.
    /// </summary>
    public enum TestCaseStatus
    {
        /// <summary>
        /// Failed
        /// </summary>
        Failed,

        /// <summary>
        /// Passed
        /// </summary>
        Passed,

        /// <summary>
        /// Skip
        /// </summary>
        Skip
    }

    /// <summary>
    /// Class to manage test cases information.
    /// </summary>
    public static class TestCase
    {
        /// <summary>
        /// Gets or sets test case status.
        /// </summary>
        public static string Status { get; set; }

        /// <summary>
        /// Gets or sets error message value.
        /// </summary>
        public static string ErrorMessage { get; set; }

        /// <summary>
        /// Personalize error message.
        /// </summary>
        /// <param name="actual">Actual value.</param>
        /// <param name="expected">Expected value</param>
        /// <param name="aditionalMessage">additional information to include in the message.</param>
        /// <returns>Error message.</returns>
        public static string SetErrorMessageEqual(string actual, string expected, string aditionalMessage = "")
        {
            ErrorMessage = $"Actual value : {actual} is not equal to: {expected} <br /> {aditionalMessage}";
            return ErrorMessage;
        }

        /// <summary>
        /// Personalize error message.
        /// </summary>
        /// <param name="message">Information to include in the message.</param>
        /// <returns>Error message.</returns>
        public static string SetErrorMessage(string message)
        {
            ErrorMessage = $"<b>Error Message:</b> <br /> {message}";
            return ErrorMessage;
        }

        /// <summary>
        /// Sets test case status to Pass.
        /// </summary>
        public static void SetTestPassed()
        {
            Status = TestCaseStatus.Passed.ToString();
        }

        /// <summary>
        /// Sets test case status to Fail.
        /// </summary>
        public static void SetTestFailed()
        {
            Status = TestCaseStatus.Failed.ToString();
        }
    }
}

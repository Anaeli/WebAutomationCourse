namespace DemoQA.Automation.Core.Extensions
{
    using OpenQA.Selenium;

    public static class FindBy
    {
        /// <summary>
        /// Finds an element using the attribute TestId.
        /// </summary>
        public static By TestId(string testId)
        {
            //return By.CssSelector(string.Format("[data-test-id=\"{0}\"]", testId));
            return By.Id(testId);
        }

        /// <summary>
        /// Finds an element using the attribute ClassName.
        /// </summary>
        public static By Class(string className)
        {
            return By.ClassName(className);
        }
    }
}

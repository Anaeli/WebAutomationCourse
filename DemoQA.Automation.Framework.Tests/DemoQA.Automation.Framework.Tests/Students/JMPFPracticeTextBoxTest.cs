using DemoQA.Automation.Framework.Wrappers.Students;
using Xunit;

namespace DemoQA.Automation.Framework.Tests.Students
{
    public class JMPFPracticeTextBoxTest
    {

        private JMPFPracticeTextBoxWrapper jmpfPracticeTextBoxWrapper;

        public JMPFPracticeTextBoxTest()
        {
            this.jmpfPracticeTextBoxWrapper = new JMPFPracticeTextBoxWrapper();
        }

        [Theory]
        [InlineData("Jessica Pena", "testing@gmail.com")]
        public void ValidatesThatFormIsFillSuccessfuly(string fullName, string eMail)
        {
            jmpfPracticeTextBoxWrapper.GoToPage();
            jmpfPracticeTextBoxWrapper.FullNameTextBox.SendKeys(fullName);
            jmpfPracticeTextBoxWrapper.EmailTextBox.SendKeys(eMail);
        }

        public void Dispose()
        {
            jmpfPracticeTextBoxWrapper.QuitDriver();
        }
    }
}

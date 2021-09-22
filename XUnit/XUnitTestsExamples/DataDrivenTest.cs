using Xunit;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class DataDrivenTest
    {
        [Theory(DisplayName = "InLine Data")]
        [InlineData(10, 4, 6)]
        [InlineData(5, 2, 3)]
        public void TestInLineDataAddition(int n1, int n2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractionI(n1, n2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Subtraction Data Attribute")]
        [SubtractionDataAttribute]
        public void TestAdditionDataAttribute(int n1, int n2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractionI(n1, n2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Internal Subtraction Data")]
        [MemberData(nameof(InternalSubtractionData.TestDataPractice),
         MemberType = typeof(InternalSubtractionData))]
        public void TestInternalAdditionData(int n1, int n2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractionI(n1, n2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "External Subtraction Data")]
        [MemberData(nameof(ExternalSubtractionData.TestDataPractice),
         MemberType = typeof(ExternalSubtractionData))]
        public void TestExternalAdditionData(int n1, int n2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractionI(n1, n2);
            Assert.Equal(expectResult, actualResult);
        }
    }
}

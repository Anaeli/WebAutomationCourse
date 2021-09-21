using Xunit;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class TestDataDriven
    {
        [Theory(DisplayName = "Inline Data")]
        [InlineData(5, 5, 10)]
        public void TestAddition(int num1, int num2, int expectedResult)
        {
            Addition add = new();
            int actualResult = add.AddInt(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory(DisplayName = "Data Attribute")]
        [AdditionDataAttribute]
        public void TestAdditionDataAttribute(int num1, int num2, int expectedResult)
        {
            Addition add = new();
            int actualResult = add.AddInt(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory(DisplayName = "Internal Data")]
        [MemberData(nameof(InternalAdditionData.TestData), MemberType = typeof(InternalAdditionData))]
        public void TestAdditionInternalData(int num1, int num2, int expectedResult)
        {
            Addition add = new();
            int actualResult = add.AddInt(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory(DisplayName = "External Data")]
        [MemberData(nameof(ExternalAdditionData.TestData), MemberType = typeof(ExternalAdditionData))]
        public void TestAdditionExternalData(int num1, int num2, int expectedResult)
        {
            Addition add = new();
            int actualResult = add.AddInt(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

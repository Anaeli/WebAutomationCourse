using Xunit;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class TestSubtractNumbersDataDriven
    {
        [Theory(DisplayName = "Data driven - InlineData")]
        [InlineData(2, 2, 0)]
        [InlineData(5, 2, 3)]
        [InlineData(10, 2, 8)]
        public void TestInlineDataWithSubtract(int num1, int num2, int expectResult)
        {
            Rest rest = new();
            int actualResult = rest.RestInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - DataAttribute")]
        [SubtractDataAttribute]
        public void TestSubtractDataAttribute(int num1, int num2, int expectResult) 
        {
            Rest rest = new();
            int actualResult = rest.RestInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(InternalSubtractData.TestData),
         MemberType = typeof(InternalSubtractData))]
        public void TestSubtractInternalData(int num1, int num2, int expectResult)
        {
            Rest rest = new();
            int actualResult = rest.RestInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - ExternalData")]
        [MemberData(nameof(ExternalSubtractData.TestData),
         MemberType = typeof(ExternalSubtractData))]
        public void TestSubtractExternalData(int num1, int num2, int expectResult)
        {
            Rest rest = new();
            int actualResult = rest.RestInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }
    }
}

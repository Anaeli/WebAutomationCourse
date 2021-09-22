using Xunit;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class TestDataDrivenPractice
    {
        [Theory()]
        [InlineData(7, 3, 4)]
        [InlineData(5, 3, 2)]
        [InlineData(6, 3, 3)]
        public void TestSubtraction1(int num1, int num2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory()]
        [InlineData(5, 3, 2)]
        public void TestSubtraction2(int num1, int num2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - DataAttribute")]
        [SubtractionDataAttribute]
        public void TestSubtractionDataDriven1(int num1, int num2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(InternalSubtractionData.TestData),
         MemberType = typeof(InternalSubtractionData))]
        public void TestSubtractionDataDriven2(int num1, int num2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(InternalSubtractionData.TestData),
         MemberType = typeof(InternalSubtractionData))]
        public void TestSubtractionDataDriven3(int num1, int num2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - ExternalData")]
        [MemberData(nameof(ExternalSubtractionData.TestData),
         MemberType = typeof(ExternalSubtractionData))]
        public void TestSubtractionDataDriven4(int num1, int num2, int expectResult)
        {
            Subtraction subtraction = new();
            int actualResult = subtraction.SubtractInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }
    }
}


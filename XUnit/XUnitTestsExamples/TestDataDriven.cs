using Xunit;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class TestDataDriven
    {
        [Theory()]
        [InlineData(10, 15, 25)]
        [InlineData(12, 5, 17)]
        [InlineData(3, 11, 14)]
        public void TestAddition(int num1, int num2, int expectResult)
        {
            Addition addition = new();
            int actualResult = addition.AddInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory()]
        [InlineData(2, 3, 5)]
        public void TestAddition2(int num1, int num2, int expectResult)
        {
            Addition addition = new();
            int actualResult = addition.AddInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - DataAttribute")]
        [AdditionDataAttribute]
        public void TestAdditionDataDriven4(int num1, int num2, int expectResult)
        {
            Addition addition = new();
            int actualResult = addition.AddInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(InternalAdditionData.TestData),
         MemberType = typeof(InternalAdditionData))]
        public void TestAdditionDataDriven2(int num1, int num2, int expectResult)
        {
            Addition addition = new();
            int actualResult = addition.AddInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(InternalAdditionData.TestData),
         MemberType = typeof(InternalAdditionData))]
        public void TestAdditionDataDriven9(int num1, int num2, int expectResult)
        {
            Addition addition = new();
            int actualResult = addition.AddInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }

        [Theory(DisplayName = "Data driven - ExternalData")]
        [MemberData(nameof(ExternalAdditionData.TestData),
         MemberType = typeof(ExternalAdditionData))]
        public void TestAdditionDataDriven3(int num1, int num2, int expectResult)
        {
            Addition addition = new();
            int actualResult = addition.AddInt(num1, num2);
            Assert.Equal(expectResult, actualResult);
        }
    }
}
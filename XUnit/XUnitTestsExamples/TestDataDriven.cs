using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using XUnitTests;
using XUnitProject;

namespace XUnitTestsExamples
{
    public class TestDataDriven
    {
        [Theory(DisplayName = "Inline Data")]
        [InlineData(5, 5, 0)]
        public void TestSubtrac(int num1, int num2, int expectedResult)
        {
            Rest r1 = new();
            int actualResult= r1.restInt(num1,num2);
            Assert.Equal(expectedResult,actualResult);
        }
        [Theory(DisplayName = "Data Attribute")]
        [RestDataAttribute]
        public void TestSubtractDataAttribute(int num1, int num2, int expectedResult)
        {
            Rest r1 = new();
            int actualResult= r1.restInt(num1,num2);
            Assert.Equal(expectedResult,actualResult);
        }

        [Theory(DisplayName = "Internal Data")]
        [MemberData(nameof(InternalRestData.TestData), MemberType = typeof(InternalRestData))]
        public void TestSubtractInternalData(int num1, int num2, int expectedResult)
        {
            Rest r1 = new();
            int actualResult= r1.restInt(num1,num2);
            Assert.Equal(expectedResult,actualResult);
        }

        [Theory(DisplayName = "External Data")]
        [MemberData(nameof(ExternalRestData.TestData), MemberType = typeof(ExternalRestData))]
        public void TestSubtractExternalData(int num1, int num2, int expectedResult)
        {
            Rest r1 = new();
            int actualResult= r1.restInt(num1,num2);
            Assert.Equal(expectedResult,actualResult);
        }
        
    }
}
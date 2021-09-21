using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitProject;
using XUnitTests;

namespace XUnitTestsExamples
{
    public class DataDrivenTest
    {
        [Theory()]
        [InlineData(50, 40, 10)]        
        [InlineData(20, 11, 9)]        
        [InlineData(18, 3, 15)]        
        [InlineData(435, 112, 323)]        
        public void SubstractionTest(int num1, int num2, int expectedResult)
        {
            Rest rest = new();
            
            Assert.Equal(expectedResult, rest.RestInt(num1, num2));
        }

        [Theory(DisplayName = "Data driven - DataAttribute")]
        [RestDataAttribute]
        public void TestRestDataDriven(int num1, int num2, int expectedResult)
        {
            Rest rest = new();

            Assert.Equal(expectedResult, rest.RestInt(num1, num2));
        }
        
        [Theory(DisplayName = "Data driven - InternalData")]
        [MemberData(nameof(InternalRestData.TestData), MemberType = typeof(InternalRestData))]
        public void TestRestDataDriven2(int num1, int num2, int expectedResult)
        {
            Rest rest = new();

            Assert.Equal(expectedResult, rest.RestInt(num1, num2));
        }
        
        [Theory(DisplayName = "Data driven - ExternalData")]
        [MemberData(nameof(ExternalRestData.TestData), MemberType = typeof(ExternalRestData))]
        public void TestRestDataDriven3(int num1, int num2, int expectedResult)
        {
            Rest rest = new();

            Assert.Equal(expectedResult, rest.RestInt(num1, num2));
        }
    }
}

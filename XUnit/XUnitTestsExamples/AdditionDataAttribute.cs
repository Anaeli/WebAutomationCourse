using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class AdditionDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            yield return new object[] { 10, 15, 25 };
            yield return new object[] { 12, 5, 17 };
            yield return new object[] { 3, 11, 14 };
        }
    }
}

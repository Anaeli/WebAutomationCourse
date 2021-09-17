using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class AdditionDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 2, 3, 5 };
            yield return new object[] { 6, 5, 11 };
            yield return new object[] { 3, 4, 7 };
        }
    }
}

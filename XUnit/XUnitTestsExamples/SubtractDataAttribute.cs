using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class SubtractDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 7, 2, 5 };
            yield return new object[] { 20, 9, 11 };
            yield return new object[] { 0, 0, 0 };
        }
    }
}
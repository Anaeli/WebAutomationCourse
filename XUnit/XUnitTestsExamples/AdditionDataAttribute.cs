using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class AdditionDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 20, 20, 40 };
            yield return new object[] { 20, 30, 50 };
            yield return new object[] { 30, 30, 60 };
            yield return new object[] { 40, 30, 70 };
        }
    }
}

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
            yield return new object[] { 50, 20, 70 };
        }
    }
}

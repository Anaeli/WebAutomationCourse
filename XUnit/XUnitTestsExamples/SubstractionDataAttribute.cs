using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class SubstractionDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 7, 4, 3 };
            yield return new object[] { 15, 5, 10 };
            yield return new object[] { 8, 2, 6 };
        }
    }
}

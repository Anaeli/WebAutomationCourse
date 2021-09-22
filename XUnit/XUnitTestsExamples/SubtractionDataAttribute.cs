using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class SubtractionDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 5, 3, 2 };
            yield return new object[] { 11, 5, 6 };
            yield return new object[] { 7, 4, 3 };
        }
    }
}

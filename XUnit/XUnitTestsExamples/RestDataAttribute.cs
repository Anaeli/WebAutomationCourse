using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace XUnitTestsExamples
{
    public class RestDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 50, 40, 10 };
            yield return new object[] { 20, 11, 9 };
            yield return new object[] { 18, 3, 15 };
            yield return new object[] { 435, 112, 323 };
        }
    }
}

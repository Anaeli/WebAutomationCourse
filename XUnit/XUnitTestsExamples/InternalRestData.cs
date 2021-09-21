using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;
using System.Reflection;

namespace XUnitTestsExamples
{
    public class InternalRestData
    {
        public static IEnumerable<object[]> TestData
        {
        get
        {
            yield return new object[] { 60, 20, 40 };
            yield return new object[] { 20, 30, -10 };
            yield return new object[] { 40, 30, 10 };
            
        }
    }
}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestsExamples
{
    public class InternalRestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 50, 40, 10 };
                yield return new object[] { 20, 11, 9 };
                yield return new object[] { 18, 3, 15 };
                yield return new object[] { 435, 112, 323 };
            }
        }
    }
}

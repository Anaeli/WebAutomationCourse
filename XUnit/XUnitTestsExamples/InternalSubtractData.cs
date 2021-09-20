using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestsExamples
{
    public class InternalSubtractData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 20, 3, 17 };
                yield return new object[] { 6, 5, 1 };
                yield return new object[] { 11, 4, 7 };
                yield return new object[] { 4, 4, 0 };
            }
        }
    }
}

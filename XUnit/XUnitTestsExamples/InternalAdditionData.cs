using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestsExamples
{
    public class InternalAdditionData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 12, 3, 15 };
                yield return new object[] { 8, 2, 10 };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestsExamples
{
    public class InternalSubtractionData
    {
        public static IEnumerable<object[]> TestDataPractice
        {
            get
            {
                yield return new object[] { 18, 3, 15 };
                yield return new object[] { 22, 12, 10 };
            }
        }
    }
}

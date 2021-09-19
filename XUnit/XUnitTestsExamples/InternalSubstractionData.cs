using System.Collections.Generic;

namespace XUnitTestsExamples
{
    public class InternalSubstractionData
    {
        public static IEnumerable<object[]> SubstractionTestData
        {
            get
            {
                yield return new object[] { 5, 2, 3 };
                yield return new object[] { 6, 5, 1 };
                yield return new object[] { 23, 14, 9 };
                yield return new object[] { 4, 4, 0 };
            }
        }
    }
}

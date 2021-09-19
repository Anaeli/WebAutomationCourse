using System.Collections.Generic;

namespace XUnitTestsExamples
{
    public class InternalAdditionData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 2, 3, 5 };
                yield return new object[] { 6, 5, 11 };
                yield return new object[] { 3, 4, 7 };
                yield return new object[] { 4, 4, 8 };
            }
        }
    }
}

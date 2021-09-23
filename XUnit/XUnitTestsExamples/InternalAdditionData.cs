using System.Collections.Generic;

namespace XUnitTestsExamples
{
    public class InternalAdditionData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 2, 5, 7 };
                yield return new object[] { 3, 6, 9 };
                yield return new object[] { 4, 7, 11 };
                yield return new object[] { 5, 8, 13 };
            }
        }
    }
}
using System.Collections.Generic;

namespace XUnitTestsExamples
{
    public class InternalSubtractionData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 5, 3, 2 };
                yield return new object[] { 11, 5, 6 };
                yield return new object[] { 7, 4, 3 };
                yield return new object[] { 8, 4, 4 };
            }
        }
    }
}
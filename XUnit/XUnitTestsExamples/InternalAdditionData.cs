using System.Collections.Generic;

namespace XUnitTestsExamples
{
    public class InternalAdditionData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 40, 40, 80 };
                yield return new object[] { 50, 40, 90 };
                yield return new object[] { 50, 50, 100 };
                yield return new object[] { 50, 60, 110 };
            }
        }
    }
}

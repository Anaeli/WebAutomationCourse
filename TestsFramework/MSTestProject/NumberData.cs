using System.Collections.Generic;

namespace MSTestProject
{
    public class NumberData
    {
        public static IEnumerable<object[]> TestData()
        {
            return new List<object[]>
            {
                new object[] { 45, 20, 45 },
                new object[] { 100, 99, 101 }
            };
        }
    }
}

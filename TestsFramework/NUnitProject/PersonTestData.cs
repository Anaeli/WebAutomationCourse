using System.Collections.Generic;

namespace Persons
{
    public class PersonTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { "Eliana", "Navia" };
                yield return new object[] { "Juan", "Perez" };
            }
        }
    }
}

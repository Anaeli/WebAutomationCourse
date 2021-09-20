using System.Collections.Generic;

namespace XUnitProject
{
    public class PersonData
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

using XUnitProject;

namespace XUnitTests
{
    public class HumanResource : Worker
    {
        public HumanResource(string name, string lastname, string salary) : base(name, lastname)
        {
            this.Salary = salary;
        }
    }
}

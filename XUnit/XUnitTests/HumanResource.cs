using System;
using XUnitProject;

namespace XUnitTests
{
    public class HumanResource : Worker
    {
        public HumanResource(string name, string lastname, string salary) : base(name, lastname)
        {
            this.Salary = salary;
        }

        public string GetName()
        {
            string name;
            if (Name is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                name = Name;
            }
            return name;
        }
    }
}

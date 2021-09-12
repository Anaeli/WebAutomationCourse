using System;

namespace XUnitProject
{
    public class HumanResource: Worker
    {
        public HumanResource(string name, string lastname) : base(name, lastname)
        { }

        public void humanResourceExists(HumanResource myhr)
        {
            if (myhr == null)
                throw new ArgumentNullException();
            else
            {
                Console.WriteLine("Human Resource exists.");
            }
        }

        public void humanResourceExists()
        {

            if ( Name is null && LastName is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Console.WriteLine("Human Resource exists.");
            }
        }
    }
}

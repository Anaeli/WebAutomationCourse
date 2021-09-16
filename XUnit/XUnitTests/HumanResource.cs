using System;
using XUnitProject;

namespace XUnitTests
{
    public class HumanResource : Worker
    {

        public HumanResource(string name, string lastname) : base(name, lastname) 
        {
        }

        public void isAHRValid()
        {
            if (Name is null && LastName is null)
            {
                throw new ArgumentNullException();
            }
        }

        protected override void CalculateHours(EventArgs e)
        {
            base.CalculateHours(e);
        }
    }
}

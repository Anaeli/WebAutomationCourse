using System;
using XUnitProject;

namespace XUnitTests
{
    public class HumanResource : Worker
    {

        public HumanResource(string name, string lastname) : base(name, lastname) 
        { }

        protected override void CalculateHours(EventArgs e)
        {
            base.CalculateHours(e);
        }
    }
}

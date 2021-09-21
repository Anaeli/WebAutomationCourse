using XUnitProject;
using System;

namespace XUnitTests
{
    public class HumanResource : Worker
    {
        public HumanResource(string name, string lastname) : base(name, lastname)
        {
            
        }
        public HumanResource HRIsNull(HumanResource hr)
        {
            if (hr is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return hr;
            }
        }

		public void GetName()
		{
			throw new ArgumentNullException();
		}
	}
}

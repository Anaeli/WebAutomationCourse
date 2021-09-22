using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitProject;

namespace XUnitTests
{
    public class HumanResources : Worker
    {
        public HumanResources(string name, string lastname) 
            : base(name, lastname)
        {

        }

        public HumanResources HRNullException(HumanResources HR)
        {
            if (HR is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return HR;
            }
        }
    }
}

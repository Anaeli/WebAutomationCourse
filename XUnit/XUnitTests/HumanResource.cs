using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitProject
{
    public class HumanResources : Worker
    {
        public HumanResources(string name, string lastname) : base(name, lastname)
        {

        }
        public HumanResources HRIsNull(HumanResources hr)
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
    }
   
}

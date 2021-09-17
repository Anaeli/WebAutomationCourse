using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitProject
{
    public class HumanResource : Worker
    {
        public HumanResource(string name, string lastname) : base(name, lastname)
        {

        }
        public HumanResource IsHRnull(HumanResource hrWorker)
        {
            if (hrWorker is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return hrWorker;
            }            
        }

    }
}

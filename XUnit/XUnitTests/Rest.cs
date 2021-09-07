using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests
{
	public class Rest
	{
        public int RestInt(int num1, int num2)
        {
            return num1 - num2;
        }

        public double RestDouble(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}

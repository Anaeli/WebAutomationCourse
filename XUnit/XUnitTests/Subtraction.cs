using System;

namespace XUnitTests
{
    public class Subtraction
    {
        public int SubtractionI(int n1, int n2)
        {
            return n1 - n2;
        }

        public int RandomNumber()
        {
            var rnd = new Random();
            return rnd.Next(1, 200);
        }
    }
}

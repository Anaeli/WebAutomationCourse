using System;

namespace XUnitTests
{
    public class Addition
    {
        public int AddInt(int num1, int num2)
        {
            return num1 + num2;
        }

        public int RandomNumber()
        {
            var rnd = new Random();
            return rnd.Next(600, 700);            
        }

        public double AddDouble(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}

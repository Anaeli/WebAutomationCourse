using System;

namespace XUnitTests
{
    public class Subtraction
    {
        public int SubtractInt(int num1, int num2)
        {
            return num1 - num2;
        }

        public int RandomNumber()
        {
            var rnd = new Random();
            return rnd.Next(1, 101);
            //return rnd.Next(101, 200);
        }

        public double SubtractDouble(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
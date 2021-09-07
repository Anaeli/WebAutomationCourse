using System;

public class Rest
{
        public int RestInt(int a, int b)
        {
			return a-b;
        }

		public double RestDouble(double a, double b)
        {
			return Math.Round(a-b,3);
        }
}

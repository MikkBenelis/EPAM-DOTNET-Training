namespace Logic.NumberOperations
{
    using System;

    /// <summary>
    /// Floating point number operations
    /// </summary>
    public static class FloatNumberOperations
    {
        /// <summary>Find nth root using Newton algorithm</summary>
        /// <param name="number">double number to find nth root</param>
        /// <param name="degree">int degree of nth root</param>
        /// <param name="precision">double root pricision</param>
        /// <returns>double result of nth root</returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree <= 0 || precision <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double a = number;
            double n = degree;
            double eps = precision / 10;

            var x0 = a / n;
            var x1 = (1 / n) * (((n - 1) * x0) + (a / Math.Pow(x0, (int)n - 1)));

            while (Math.Abs(x1 - x0) >= eps)
            {
                x0 = x1;
                x1 = (1 / n) * (((n - 1) * x0) + (a / Math.Pow(x0, (int)n - 1)));
            }

            return Math.Round(x1, precision.ToString().Length - "0.".Length);
        }
    }
}

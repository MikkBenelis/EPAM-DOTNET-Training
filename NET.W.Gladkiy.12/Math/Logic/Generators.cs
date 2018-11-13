namespace Math
{
    using System;
    using System.Collections.Generic;

    public static class Generators
    {
        public static IEnumerable<int> Fibonacci(int x)
        {
            if (x <= 0)
            {
                throw new ArgumentException();
            }

            int prev = 0;
            int next = 1;
            for (int i = 0; i < x; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}

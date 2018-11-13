namespace NUnitTests
{
    using Math;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitMathGeneratorsTests
    {
        [TestCase(1, ExpectedResult = new int[] { 1 })]
        [TestCase(3, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(5, ExpectedResult = new int[] { 1, 2, 3, 5, 8 })]
        public int[] TestFibonacciGenerator(int n)
        {
            var result = new int[n];
            int currentIndex = 0;
            foreach (int fib in Generators.Fibonacci(n))
            {
                result[currentIndex++] = fib;
            }

            return result;
        }
    }
}

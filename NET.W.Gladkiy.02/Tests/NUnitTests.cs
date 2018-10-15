namespace UnitTests
{
    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class NUnitTests
    {
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int TestBitInsertion(int numberSource, int numberIn, int from, int to)
        {
            return Logic.NumberOperations.BitOperations.InsertNumber(numberSource, numberIn, from, to);
        }
        
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(13132, ExpectedResult = 13213)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int TestFindNextBiggerNumber(int number)
        {
            return Logic.NumberOperations.IntNumberOperations.FindNextBiggerNumber(number, out _);
        }
        
        [TestCase(3, new int[] { 3, 2, 21, 4, 52, 35, 77, 68, 59, 77, 93 }, ExpectedResult = new int[] { 3, 35, 93 })]
        [TestCase(1, new int[] { 13, 2, 3, 1, 24, 62, 31, 68, 88, 70, 15 }, ExpectedResult = new int[] { 13, 1, 31, 15 })]
        [TestCase(7, new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        public int[] TestFilterDigits(int digit, int[] numbers)
        {
            return Logic.NumberOperations.IntNumberOperations.FilterDigits(digit, numbers);
        }
        
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double TestFindNthRoot(double number, int degree, double precision)
        {
            return Logic.NumberOperations.FloatNumberOperations.FindNthRoot(number, degree, precision);
        }

        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        public void TestFindNthRootArgumentOutOfRangeException(double number, int degree, double precision, double expected)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Logic.NumberOperations.FloatNumberOperations.FindNthRoot(number, degree, precision));
        }
    }
}

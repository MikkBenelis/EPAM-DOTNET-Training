namespace NUnitTests
{
    using Logic.Converters;
    using Logic.MathOperations;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTests
    {
        [TestCase(13, 13, ExpectedResult = 13)]
        [TestCase(37, 600, ExpectedResult = 1)]
        [TestCase(20, 100, ExpectedResult = 20)]
        [TestCase(624129, 2061517, ExpectedResult = 18913)]
        [TestCase(125, 25, 45, ExpectedResult = 5)]
        public int TestGCDEuclideanR(params int[] nums)
        {
            return GCDOperations.EuclideanRecursive(out _, nums);
        }

        [TestCase(13, 13, ExpectedResult = 13)]
        [TestCase(37, 600, ExpectedResult = 1)]
        [TestCase(20, 100, ExpectedResult = 20)]
        [TestCase(624129, 2061517, ExpectedResult = 18913)]
        [TestCase(125, 25, 45, ExpectedResult = 5)]
        public int TestGCDEuclideanI(params int[] nums)
        {
            return GCDOperations.EuclideanIterative(out _, nums);
        }

        [TestCase(13, 13, ExpectedResult = 13)]
        [TestCase(37, 600, ExpectedResult = 1)]
        [TestCase(20, 100, ExpectedResult = 20)]
        [TestCase(624129, 2061517, ExpectedResult = 18913)]
        [TestCase(125, 25, 45, ExpectedResult = 5)]
        public int TestGCDStein(params int[] nums)
        {
            return GCDOperations.Stein(out _, nums);
        }

        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        public string TestDoubleToBinatyString(double number)
        {
            return number.DoubleToBinaryString();
        }
    }
}

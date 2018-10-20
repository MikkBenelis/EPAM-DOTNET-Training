namespace NUnitTests
{
    using Logic.Math;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTests
    {
        [TestCase]
        public void TestPolynomialEquality()
        {
            Polynomial p1 = new Polynomial(1, 2, 3, 4, 5);
            Polynomial p2 = new Polynomial(1.0, 2, 3, 4, 5);
            Polynomial p3 = new Polynomial(1, 1, 1);

            Assert.IsTrue(p1 != null);
            Assert.IsFalse(p1 == null);

            Assert.IsTrue(p1 == p2);
            Assert.IsTrue(p1 != p3);
            Assert.IsFalse(p2 == p3);
        }

        [TestCase]
        public void TestPolynomialEqualityMethod()
        {
            Polynomial p1 = new Polynomial(1, 2, 3, 4, 5);
            Polynomial p2 = new Polynomial(1.0, 2, 3, 4, 5);
            Polynomial p3 = new Polynomial(1, 1, 1);

            Assert.AreEqual(p1, p1);
            Assert.AreNotEqual(p1, null);

            Assert.AreEqual(p1, p2);
            Assert.AreNotEqual(p1, p3);
        }

        [TestCase]
        public void TestPolynomialSum()
        {
            Polynomial p1 = new Polynomial(1, 2, 3, 4, 5);
            Polynomial p2 = new Polynomial(1, 2, 3, 4, 5);
            Polynomial p3 = new Polynomial(-1, -2, -3, -4, -5);
            Assert.AreEqual(p1 + p2, new Polynomial(2, 4, 6, 8, 10));
            Assert.AreEqual(p1 + p3, new Polynomial(0));
        }

        [TestCase]
        public void TestPolynomialSub()
        {
            Polynomial p1 = new Polynomial(2, 4, 6, 8, 10);
            Polynomial p2 = new Polynomial(1, 2, 3, 4, 5);
            Polynomial p3 = new Polynomial(1, 2, 3, 4, 5);
            Assert.AreEqual(p1 - p2, new Polynomial(1, 2, 3, 4, 5));
            Assert.AreEqual(p2 - p3, new Polynomial(0));
        }

        [TestCase]
        public void TestPolynomialMulByNumber()
        {
            Polynomial p = new Polynomial(1, 2, 3, 4, 5);
            Assert.AreEqual(p * 2, new Polynomial(2, 4, 6, 8, 10));
            Assert.AreEqual(-2 * p, new Polynomial(-2, -4, -6, -8, -10));
            Assert.AreEqual(p * 0, new Polynomial(0));
        }

        [TestCase]
        public void TestPolynomialMulByPolynomial()
        {
            Polynomial p1 = new Polynomial(1, 2, 3);
            Polynomial p2 = new Polynomial(1, 2, 3);
            Polynomial p3 = new Polynomial(0);
            Assert.AreEqual(p1 * p2, new Polynomial(1, 4, 10, 12, 9));
            Assert.AreEqual(p1 * p3, new Polynomial(0));
        }
    }
}

namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MSUnitTests
    {
        [DataTestMethod]
        [DataRow(12, 21)]
        [DataRow(513, 531)]
        [DataRow(2017, 2071)]
        [DataRow(414, 441)]
        [DataRow(144, 414)]
        [DataRow(1234321, 1241233)]
        [DataRow(1234126, 1234162)]
        [DataRow(3456432, 3462345)]
        [DataRow(10, -1)]
        [DataRow(20, -1)]
        public void TestFindNextBiggerNumber(int arg, int expected)
        {
            Assert.AreEqual(Logic.NumberOperations.IntNumberOperations.FindNextBiggerNumber(arg, out _), expected);
        }
    }
}

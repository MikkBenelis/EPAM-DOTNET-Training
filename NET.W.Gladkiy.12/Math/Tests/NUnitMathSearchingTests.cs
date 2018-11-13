namespace NUnitTests
{
    using Math;
    using NUnit.Framework;
    
    [TestFixture]
    public class NUnitMathSearchingTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, ExpectedResult = true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, ExpectedResult = true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, ExpectedResult = true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, ExpectedResult = false)]
        public bool TestIntBinarySearch(int[] array, int smthToFind)
        {
            return Searching.BinarySearch(array, smthToFind);
        }

        [TestCase(new string[] { "1", "2", "3", "4", "5" }, "1", ExpectedResult = true)]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, "3", ExpectedResult = true)]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, "5", ExpectedResult = true)]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, "10", ExpectedResult = false)]
        public bool TestStringBinarySearch(string[] array, string smthToFind)
        {
            return Searching.BinarySearch(array, smthToFind);
        }
        
        [TestCase]
        public void TestCustomBinarySearch()
        {
            var array = new CustomType[]
            {
                new CustomType(1, 2, "name1"),
                new CustomType(3, 4, "name2"),
                new CustomType(5, 6, "name3"),
                new CustomType(7, 8, "name4"),
                new CustomType(9, 10, "name5")
            };

            var smthToFind1 = new CustomType(1, 2, "name1");
            var smthToFind2 = new CustomType(5, 6, "name3");
            var smthToFind3 = new CustomType(9, 10, "name5");
            var smthToFind = new CustomType(0, 0, "name0");

            Assert.True(Searching.BinarySearch(array, smthToFind1));
            Assert.True(Searching.BinarySearch(array, smthToFind2));
            Assert.True(Searching.BinarySearch(array, smthToFind3));
            Assert.False(Searching.BinarySearch(array, smthToFind));
        }
    }
}

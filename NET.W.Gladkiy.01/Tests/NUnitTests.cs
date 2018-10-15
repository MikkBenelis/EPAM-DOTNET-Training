namespace NUnitTests
{
    using NUnit.Framework;

    [TestFixture]
    public class TestSorting
    {
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 0, 1, 7, 5, 6, 3, 8, 9, 2, 4 }, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, ExpectedResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public int[] TestQuickSort(int[] array)
        {
            return Logic.Sorting.QuickSort.SortInt(array);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 0, 1, 7, 5, 6, 3, 8, 9, 2, 4 }, ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, ExpectedResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public int[] TestMergeSort(int[] array)
        {
            return Logic.Sorting.MergeSort.SortInt(array);
        }
    }
}

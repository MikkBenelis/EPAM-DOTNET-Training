namespace NUnitTests
{
    using System.Linq;
    using Logic.Math;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTestsSorting
    {
        // Compare two two-dimensional arrays for equality
        public static bool CompareArrays(int[][] arr1, int[][] arr2)
        {
            bool result = true;
            for (int i = 0; i < arr1.Length; i++)
            {
                result &= arr1[i].SequenceEqual(arr2[i]);
            }

            return result;
        }

        [TestCase]
        public void TestSortingBySum()
        {
            int[][] tempArray;
            int[][] arrToSort = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };
            int[][] sortedArr = { new int[] { 1, 2, 3 }, new int[] { 5, 10 }, new int[] { 15 } };

            tempArray = Sorting.Sort(arrToSort, new SumComparator());
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
            tempArray = Sorting.Sort(arrToSort, new SumComparator().Compare);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
        }

        [TestCase]
        public void TestSortingBySumReversed()
        {
            int[][] tempArray;
            int[][] arrToSort = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };
            int[][] sortedArr = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };

            tempArray = Sorting.Sort(arrToSort, new SumComparator(), reverse: true);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
            tempArray = Sorting.Sort(arrToSort, new SumComparator().Compare, reverse: true);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
        }

        [TestCase]
        public void TestSortingByMinElements()
        {
            int[][] tempArray;
            int[][] arrToSort = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };
            int[][] sortedArr = { new int[] { 1, 2, 3 }, new int[] { 5, 10 }, new int[] { 15 } };

            tempArray = Sorting.Sort(arrToSort, new MinElementComparator());
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
            tempArray = Sorting.Sort(arrToSort, new MinElementComparator().Compare);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
        }

        [TestCase]
        public void TestSortingByMinElementsReversed()
        {
            int[][] tempArray;
            int[][] arrToSort = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };
            int[][] sortedArr = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };

            tempArray = Sorting.Sort(arrToSort, new MinElementComparator(), reverse: true);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
            tempArray = Sorting.Sort(arrToSort, new MinElementComparator().Compare, reverse: true);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
        }

        [TestCase]
        public void TestSortingByMaxElements()
        {
            int[][] tempArray;
            int[][] arrToSort = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };
            int[][] sortedArr = { new int[] { 1, 2, 3 }, new int[] { 5, 10 }, new int[] { 15 } };

            tempArray = Sorting.Sort(arrToSort, new MaxElementComparator());
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
            tempArray = Sorting.Sort(arrToSort, new MaxElementComparator().Compare);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
        }

        [TestCase]
        public void TestSortingByMaxElementsReversed()
        {
            int[][] tempArray;
            int[][] arrToSort = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };
            int[][] sortedArr = { new int[] { 15 }, new int[] { 5, 10 }, new int[] { 1, 2, 3 } };

            tempArray = Sorting.Sort(arrToSort, new MaxElementComparator(), reverse: true);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
            tempArray = Sorting.Sort(arrToSort, new MaxElementComparator().Compare, reverse: true);
            Assert.IsTrue(CompareArrays(tempArray, sortedArr));
        }
    }
}

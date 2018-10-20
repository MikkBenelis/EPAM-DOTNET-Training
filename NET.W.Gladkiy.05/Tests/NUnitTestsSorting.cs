namespace NUnitTests
{
    using System.Linq;
    using Logic.Math;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTestsSorting
    {
        [TestCase]
        public void TestSortingBySum()
        {
            int[][] arrToSort =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            int[][] sortedArr =
            {
                new int[] { 1, 2, 3 },
                new int[] { 5, 10 },
                new int[] { 15 }
            };

            arrToSort = Sorting.SortBySum(arrToSort);

            bool result = true;
            for (int i = 0; i < arrToSort.Length; i++)
            {
                result &= arrToSort[i].SequenceEqual(sortedArr[i]);
            }

            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestSortingBySumReversed()
        {
            int[][] arrToSort =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            int[][] sortedArr =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            arrToSort = Sorting.SortBySum(arrToSort, reverse: true);

            bool result = true;
            for (int i = 0; i < arrToSort.Length; i++)
            {
                result &= arrToSort[i].SequenceEqual(sortedArr[i]);
            }

            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestSortingByMinElements()
        {
            int[][] arrToSort =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            int[][] sortedArr =
            {
                new int[] { 1, 2, 3 },
                new int[] { 5, 10 },
                new int[] { 15 }
            };

            arrToSort = Sorting.SortByMinElements(arrToSort);

            bool result = true;
            for (int i = 0; i < arrToSort.Length; i++)
            {
                result &= arrToSort[i].SequenceEqual(sortedArr[i]);
            }

            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestSortingByMinElementsReversed()
        {
            int[][] arrToSort =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            int[][] sortedArr =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            arrToSort = Sorting.SortByMinElements(arrToSort, reverse: true);

            bool result = true;
            for (int i = 0; i < arrToSort.Length; i++)
            {
                result &= arrToSort[i].SequenceEqual(sortedArr[i]);
            }

            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestSortingByMaxElements()
        {
            int[][] arrToSort =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            int[][] sortedArr =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            arrToSort = Sorting.SortByMaxElements(arrToSort);

            bool result = true;
            for (int i = 0; i < arrToSort.Length; i++)
            {
                result &= arrToSort[i].SequenceEqual(sortedArr[i]);
            }

            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestSortingByMaxElementsReversed()
        {
            int[][] arrToSort =
            {
                new int[] { 15 },
                new int[] { 5, 10 },
                new int[] { 1, 2, 3 }
            };

            int[][] sortedArr =
            {
                new int[] { 1, 2, 3 },
                new int[] { 5, 10 },
                new int[] { 15 }
            };

            arrToSort = Sorting.SortByMaxElements(arrToSort, reverse: true);

            bool result = true;
            for (int i = 0; i < arrToSort.Length; i++)
            {
                result &= arrToSort[i].SequenceEqual(sortedArr[i]);
            }

            Assert.IsTrue(result);
        }
    }
}

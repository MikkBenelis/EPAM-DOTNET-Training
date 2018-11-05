namespace Logic.Math
{
    using System;
    using System.Collections;

    public static class Sorting
    {
        #region Delegates

        public delegate int ComparerDelegate(int[] arr1, int[] arr2);

        #endregion Delegates

        #region PublicAPI

        // Sort with given comparer
        public static int[][] Sort(int[][] array, IComparer comparer, bool reverse = false)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            int[][] result = (int[][])array.Clone();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (!reverse)
                    {
                        if (comparer.Compare(result[i], result[j]) > 0)
                        {
                            SwapIntArrs(ref result[i], ref result[j]);
                        }
                    }
                    else
                    {
                        if (comparer.Compare(result[i], result[j]) < 0)
                        {
                            SwapIntArrs(ref result[i], ref result[j]);
                        }
                    }
                }
            }

            return result;
        }

        // Sort with giver comparer degegate
        public static int[][] Sort(int[][] array, ComparerDelegate comparerDelegate, bool reverse = false)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            int[][] result = (int[][])array.Clone();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (!reverse)
                    {
                        if (comparerDelegate(result[i], result[j]) > 0)
                        {
                            SwapIntArrs(ref result[i], ref result[j]);
                        }
                    }
                    else
                    {
                        if (comparerDelegate(result[i], result[j]) < 0)
                        {
                            SwapIntArrs(ref result[i], ref result[j]);
                        }
                    }
                }
            }

            return result;
        }

        #endregion PublicAPI

        #region InternalAPI

        // SwapIntArrs
        public static void SwapIntArrs(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        // GetArraySum
        public static int GetArraySum(int[] array)
        {
            int result = 0;
            foreach (int element in array)
            {
                result += element;
            }

            return result;
        }

        // GetMinElement
        public static int GetMinElement(int[] array)
        {
            int min = array[0];
            foreach (int element in array)
            {
                if (element < min)
                {
                    min = element;
                }
            }

            return min;
        }

        // GetMaxElemeny
        public static int GetMaxElement(int[] array)
        {
            int max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
            }

            return max;
        }

        #endregion InternalAPI
    }
}

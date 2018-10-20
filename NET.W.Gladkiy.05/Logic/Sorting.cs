namespace Logic.Math
{
    using System;

    public static class Sorting
    {
        #region PublicAPI

        // SortBySum
        public static int[][] SortBySum(int[][] array, bool reverse = false)
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
                    if (reverse)
                    {
                        if (GetArraySum(result[i]) < GetArraySum(result[j]))
                        {
                            SwapIntArrs(ref result[i], ref result[j]);
                        }
                    }
                    else
                    {
                        if (GetArraySum(result[i]) > GetArraySum(result[j]))
                        {
                            SwapIntArrs(ref result[i], ref result[j]);
                        }
                    }
                }
            }

            return result;
        }

        // SortByMinElements
        public static int[][] SortByMinElements(int[][] array, bool reverse = false)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            return new int[0][];
        }

        // SortByMaxElements
        public static int[][] SortByMaxElements(int[][] array, bool reverse = false)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            return new int[0][];
        }

        #endregion PublicAPI

        #region PrivateAPI

        // SwapIntArrs
        private static void SwapIntArrs(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        // GetArraySum
        private static int GetArraySum(int[] array)
        {
            int result = 0;
            foreach (int element in array)
            {
                result += element;
            }

            return result;
        }

        // GetMinElement
        private static int GetMinElement(int[] array)
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
        private static int GetMaxElement(int[] array)
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

        #endregion PrivateAPI
    }
}

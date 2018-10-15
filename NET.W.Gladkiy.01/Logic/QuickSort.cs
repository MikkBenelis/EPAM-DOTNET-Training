namespace Logic.Sorting
{
    /// <summary>
    /// Quick sorting algorithm
    /// </summary>
    public static class QuickSort
    {
        /// <summary>QuickSort algorithm</summary>
        /// <param name="array">int array to be sorted</param>
        /// <returns>Sorted copy of int array</returns>
        public static int[] SortInt(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            SortIntRoutine(sortedArray, 0, array.Length - 1);
            return sortedArray;
        }

        // QuickSort recursive routine for int[] array
        private static void SortIntRoutine(int[] array, int left, int right)
        {
            int l = left, r = right;
            int pivot = array[(left + right) / 2];

            // Sort array relative to pivot
            while (l <= r)
            {
                while (array[l] < pivot)
                {
                    l++;
                }

                while (array[r] > pivot)
                {
                    r--;
                }

                if (l <= r)
                {
                    int tmp = array[l];
                    array[l] = array[r];
                    array[r] = tmp;

                    l++;
                    r--;
                }
            }

            // Sort subarrays
            if (left < right)
            {
                SortIntRoutine(array, left, r);
                SortIntRoutine(array, l, right);
            }
        }
    }
}

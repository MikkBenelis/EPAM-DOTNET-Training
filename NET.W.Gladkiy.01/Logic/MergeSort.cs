namespace Logic.Sorting
{
    /// <summary>
    /// Merge sorting algorithm
    /// </summary>
    public static class MergeSort
    {
        /// <summary>MergeSort algorithm</summary>
        /// <param name="array">int array to be sorted</param>
        /// <returns>Sorted copy of int array</returns>
        public static int[] SortInt(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            SortIntRoutine(sortedArray, 0, array.Length - 1);
            return sortedArray;
        }

        // MergeSort merge sorted parts
        private static void MergeSortedInt(int[] array, int left, int middle, int right)
        {
            int low = left;
            int high = middle + 1;
            int[] tmp = new int[(right - left) + 1];
            int tmpIndex = 0;
            
            // Merge to the middle or to the right
            while ((low <= middle) && (high <= right))
            {
                if (array[low] < array[high])
                {
                    tmp[tmpIndex] = array[low];
                    low = low + 1;
                }
                else
                {
                    tmp[tmpIndex] = array[high];
                    high = high + 1;
                }

                tmpIndex = tmpIndex + 1;
            }
            
            // Add left remaining
            while (low <= middle)
            {
                tmp[tmpIndex] = array[low];
                low = low + 1;
                tmpIndex = tmpIndex + 1;
            }
            
            // Add right remaining
            while (high <= right)
            {
                tmp[tmpIndex] = array[high];
                high = high + 1;
                tmpIndex = tmpIndex + 1;
            }

            // Change input array
            for (int i = 0; i < tmp.Length; i++)
            {
                array[left + i] = tmp[i];
            }
        }

        // MergeSort recursive routine for int[] array
        private static void SortIntRoutine(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (right + left) / 2;
                SortIntRoutine(array, left, middle);
                SortIntRoutine(array, middle + 1, right);
                MergeSortedInt(array, left, middle, right);
            }
        }
    }
}

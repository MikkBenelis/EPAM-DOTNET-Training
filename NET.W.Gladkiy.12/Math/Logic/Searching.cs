namespace Math
{
    using System;

    public static class Searching
    {
        public static bool BinarySearch<T>(T[] array, T smthToFind) where T : IComparable<T>
        {
            if (array == null || smthToFind == null || !CheckIfSorted(array))
            {
                throw new ArgumentException();
            }
            
            int min = 0;
            int max = array.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (smthToFind.CompareTo(array[mid]) == 0)
                {
                    return true;
                }
                else if (smthToFind.CompareTo(array[mid]) < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return false;
        }

        private static bool CheckIfSorted<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length == 1)
            {
                return true;
            }

            T last = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (last.CompareTo(array[i]) > 0)
                {
                    return false;
                }

                last = array[i];
            }

            return true;
        }
    }
}

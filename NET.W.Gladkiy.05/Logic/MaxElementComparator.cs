namespace Logic.Math
{
    using System;
    using System.Collections;

    public class MaxElementComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null || x as int[] == null || y as int[] == null)
            {
                throw new ArgumentException();
            }

            return Sorting.GetMaxElement(x as int[]).CompareTo(Sorting.GetMaxElement(y as int[]));
        }
    }
}

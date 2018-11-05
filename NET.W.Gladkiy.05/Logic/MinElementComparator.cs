namespace Logic.Math
{
    using System;
    using System.Collections;

    public class MinElementComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null || x as int[] == null || y as int[] == null)
            {
                throw new ArgumentException();
            }

            return Sorting.GetMinElement(x as int[]).CompareTo(Sorting.GetMinElement(y as int[]));
        }
    }
}

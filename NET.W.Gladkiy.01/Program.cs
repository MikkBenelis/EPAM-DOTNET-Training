using System;

namespace NET.W.Gladkiy._01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] { 0, 1, 7, 5, 6, 3, 8, 9, 2, 4 };
            Console.WriteLine("BEFORE: [{0}]", string.Join(",", array));
            Console.WriteLine(" QUICK: [{0}]", string.Join(",", Logic.Sorting.QuickSort.SortInt(array)));
            Console.WriteLine(" MERGE: [{0}]", string.Join(",", Logic.Sorting.MergeSort.SortInt(array)));
            Console.ReadKey();
        }
    }
}

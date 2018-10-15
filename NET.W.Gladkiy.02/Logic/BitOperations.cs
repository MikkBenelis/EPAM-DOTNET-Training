namespace Logic.NumberOperations
{
    using System;

    /// <summary>
    /// Bit operations
    /// </summary>
    public static class BitOperations
    {
        /// <summary>Insert bits from 'numberIn' to 'numberSource' at given indexes</summary>
        /// <param name="numberSource">int destination (result) number</param>
        /// <param name="numberIn">int number to be inserted</param>
        /// <param name="from">int insertion from index (31..0)</param>
        /// <param name="to">int insertion to index (31..0, including)</param>
        /// <returns>int number with inserted bits</returns>
        public static int InsertNumber(int numberSource, int numberIn, int from, int to)
        {
            // Check bits indexes
            if (from > to || from < 0 || to > 31)
            {
                throw new ArgumentException();
            }
            
            // Get bit masks
            int insertionMask = (int)Math.Pow(2, to - from + 1) - 1;
            int resultBitMask = insertionMask << from;

            // Calculate result
            numberSource &= ~resultBitMask;
            numberSource |= (numberIn << from) & resultBitMask;
            
            return numberSource;
        }
    }
}

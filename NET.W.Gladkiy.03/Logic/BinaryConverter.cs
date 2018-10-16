namespace Logic.Converters
{
    using System;
    using System.Text;

    /// <summary>
    /// Binary converter
    /// </summary>
    public static class BinaryConverter
    {
        #region PublicAPI

        /// <summary>Converts double to bit string</summary>
        /// <param name="number">double value to convert</param>
        /// <returns>string result of double bit representation</returns>
        public static string DoubleToBinaryString(double number)
        {
            StringBuilder result = new StringBuilder();
            long intBits = BitConverter.DoubleToInt64Bits(number);
            result.Append(LongToBitString(intBits));

            return result.ToString();
        }

        #endregion PublicAPI

        #region PrivateAPI

        /*
        private static unsafe long DoubleToInt64Bits(double value)
        {
            return *((long*)&value);
        }
        */
        
        private static string LongToBitString(long number)
        {
            var result = new StringBuilder();
            for (int i = (sizeof(long) * 8) - 1; i >= 0; i--)
            {
                result.Append((number >> i) & 1);
            }

            return result.ToString().PadLeft(sizeof(long) * 8, '0');
        }

        #endregion PrivateAPI
    }
}

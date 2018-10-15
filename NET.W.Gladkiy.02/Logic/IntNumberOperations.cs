namespace Logic.NumberOperations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Integer number operations
    /// </summary>
    public static class IntNumberOperations
    {
        /// <summary>Find next bigger number which contsists same digits</summary>
        /// <param name="number">positive int number to find next bigger</param>
        /// <param name="execTime">long reference to execution time result</param>
        /// <returns>int next bigger number which consists same digits, or -1</returns>
        public static int FindNextBiggerNumber(int number, out long execTime)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }

            // Replace and sort numbers
            var watch = Stopwatch.StartNew();
            char[] strNumber = number.ToString().ToCharArray();
            for (int i = strNumber.Length - 1; i > 0; i--)
            {
                if (strNumber[i] > strNumber[i - 1])
                {
                    char tmpMin = strNumber[i];
                    int tmpMinInd = i;
                    for (int j = i; j < strNumber.Length; j++)
                    {
                        if (strNumber[j] < tmpMin && strNumber[j] > strNumber[i - 1])
                        {
                            tmpMin = strNumber[j];
                            tmpMinInd = j;
                        }
                    }

                    char tmp = strNumber[i - 1];
                    strNumber[i - 1] = strNumber[tmpMinInd];
                    strNumber[tmpMinInd] = tmp;
                    Array.Sort(strNumber, i, strNumber.Length - i);
                    break;
                }
            }

            watch.Stop();
            execTime = watch.ElapsedMilliseconds;

            // Check if possible to find bigger number
            int.TryParse(new string(strNumber), out int result);
            if (result == number)
            {
                return -1;
            }

            return result;
        }

        /// <summary>Remove elements without 'digit' from 'numbers'</summary>
        /// <param name="digit">int digit to filter</param>
        /// <param name="numbers">int array of numbers</param>
        /// <returns>int array with filtered numbers</returns>
        public static int[] FilterDigits(int digit, int[] numbers)
        {
            if (digit < 0 || digit > 9 || numbers == null)
            {
                throw new ArgumentException();
            }

            var result = new List<int>();
            var strDigit = digit.ToString()[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                // Check if element contains digit
                bool needToAdd = false;
                string strNumber = numbers[i].ToString();
                foreach (char letter in strNumber)
                {
                    if (letter == strDigit)
                    {
                        needToAdd = true;
                    }
                }
                
                // Add to result
                if (needToAdd)
                {
                    result.Add(numbers[i]);
                }
            }

            return result.ToArray();
        }
    }
}

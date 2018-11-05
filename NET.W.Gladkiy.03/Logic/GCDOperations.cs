namespace Logic.MathOperations
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Finding GCD algorithms
    /// </summary>
    public partial class GCDOperations
    {
        #region Delegates
        
        private delegate int CommonGCDDelegate(int a, int b);

        #endregion Delegetes

        #region PublicAPI

        /// <summary>Recursive Euclidean's GCD algorithm</summary>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>greatest common divisor of given numbers</returns>
        public static int EuclideanRecursive(out long execTime, params int[] nums)
        {
            return EuclideanCommon(EuclideanR, out execTime, nums);
        }

        /// <summary>Iterative Euclidean's GCD algorithm</summary>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>Greatest common divisor of given numbers</returns>
        public static int EuclideanIterative(out long execTime, params int[] nums)
        {
            return EuclideanCommon(EuclideanI, out execTime, nums);
        }

        #endregion PublicAPI

        #region PrivateEuclideanAPI

        /// <summary>Common algorithm to caclulate GCD</summary>
        /// <param name="alg">Ierative or recursive algorithm</param>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>Greatest common divisor of given numbers</returns>
        private static int EuclideanCommon(CommonGCDDelegate alg, out long execTime, params int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                throw new ArgumentException();
            }

            var watch = Stopwatch.StartNew();

            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result = alg(result, nums[i]);
            }

            watch.Stop();
            execTime = watch.ElapsedMilliseconds;
            return result;
        }

        // Recursive varian of Euclidean algorithm
        private static int EuclideanR(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a > b)
            {
                return EuclideanR(a % b, b);
            }
            else
            {
                return EuclideanR(a, b % a);
            }
        }

        // Iterative varian of Euclidean algorithm
        private static int EuclideanI(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            if (a == 0)
            {
                return b;
            }
            else
            {
                return a;
            }
        }

        #endregion PrivateEuclideanAPI
    }
}

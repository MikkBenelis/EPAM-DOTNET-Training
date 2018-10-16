﻿namespace Logic.MathOperations
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Finding GCD algorithms
    /// </summary>
    public static class GCDOperations
    {
        #region PublicAPI

        /// <summary>Recursive Euclidean's GCD algorithm</summary>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>greatest common divisor of given numbers</returns>
        public static int EuclideanRecursive(out long execTime, params int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                throw new ArgumentException();
            }

            var watch = Stopwatch.StartNew();

            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result = EuclideanR(result, nums[i]);
            }
            
            watch.Stop();
            execTime = watch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Iterative Euclidean's GCD algorithm</summary>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>Greatest common divisor of given numbers</returns>
        public static int EuclideanIterative(out long execTime, params int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                throw new ArgumentException();
            }

            var watch = Stopwatch.StartNew();
            
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result = EuclideanI(result, nums[i]);
            }

            watch.Stop();
            execTime = watch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Stein's GCD algorithm</summary>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>Greatest common divisor of given numbers</returns>
        public static int Stein(out long execTime, params int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                throw new ArgumentException();
            }

            var watch = Stopwatch.StartNew();
            
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result = SteinLogic(result, nums[i]);
            }

            watch.Stop();
            execTime = watch.ElapsedMilliseconds;
            return result;
        }

        #endregion PublicAPI
        
        #region PrivateEuclideanAPI

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

        #region PrivateSteinAPI

        private static int SteinLogic(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if (a == b)
            {
                return a;
            }

            if ((a & 1) == 0 && (b & 1) == 0)
            {
                return SteinLogic(a >> 1, b >> 1) << 1;
            }
            else
            {
                if ((a & 1) == 0 && (b & 1) != 0)
                {
                    return SteinLogic(a >> 1, b);
                }
                else
                {
                    if ((b & 1) == 0)
                    {
                        return SteinLogic(a, b >> 1);
                    }
                    else
                    {
                        if (a > b)
                        {
                            return SteinLogic((a - b) >> 1, b);
                        }
                        else
                        {
                            return SteinLogic(a, (b - a) >> 1);
                        }
                    }
                }
            }
        }

        #endregion PrivateSteinAPI
    }
}

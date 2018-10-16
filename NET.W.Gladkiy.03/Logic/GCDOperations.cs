// Разработать класс, позволяющий выполнять вычисления НОД по 
// алгоритму Евклида для двух, трех и т.д.целых чисел. 
// Методы класса помимо вычисления НОД должны определять значение 
// времени, необходимое для выполнения расчета. Добавить к 
// разработанному классу методы, реализующие алгоритм Стейна 
// (бинарный алгоритм Евклида) для расчета НОД двух, трех и 
// т.д. целых чисел. Методы должны также  определять значение 
// времени, необходимое для выполнения расчетов.

namespace Logic.MathOperations
{
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
        public static int EuclideanR(out long execTime, params int[] nums)
        {
            var watch = Stopwatch.StartNew();

            int result = 0;
            
            watch.Stop();
            execTime = watch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>Iterative Euclidean's GCD algorithm</summary>
        /// <param name="execTime">long reference to execution time result</param>
        /// <param name="nums">int array to find GCD</param>
        /// <returns>Greatest common divisor of given numbers</returns>
        public static int EuclideanI(out long execTime, params int[] nums)
        {
            var watch = Stopwatch.StartNew();

            /// TODO
            int result = 0;

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
            var watch = Stopwatch.StartNew();

            /// TODO
            int result = 0;

            watch.Stop();
            execTime = watch.ElapsedMilliseconds;
            return result;
        }

        #endregion PublicAPI
        
        #region PrivateEuclideanAPI

        // Recursive varian of Euclidean algorithm
        private static int EuclideanRecursive(int a, int b)
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
                return EuclideanRecursive(a % b, b);
            }
            else
            {
                return EuclideanRecursive(a, b % a);
            }
        }

        // Iterative varian of Euclidean algorithm
        private static int EuclideanIterative(int a, int b)
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

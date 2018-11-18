namespace Logic.Generic
{
    using System;

    public static class MatrixOperations
    {
        /// <summary>Calculate sum of two matrices</summary>
        /// <typeparam name="T">Matrix type</typeparam>
        /// <param name="matrix">First matrix</param>
        /// <param name="addition">Matrix to add</param>
        /// <param name="add">Delegate of sum function</param>
        /// <returns>New matrix result as sum of matrix1 and matrix2</returns>
        public static SquareMatrix<T> AddMatrix<T>(this SquareMatrix<T> matrix, SquareMatrix<T> addition, Func<T, T, T> add)
        {
            if (matrix.Size != addition.Size)
            {
                throw new ArgumentException();
            }

            int size = matrix.Size;
            var m1 = matrix.Matrix;
            var m2 = addition.Matrix;

            var result = new SquareMatrix<T>(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result.SetItem(i, j, add(m1[i, j], m2[i, j]));
                }
            }

            return result;
        }
    }
}

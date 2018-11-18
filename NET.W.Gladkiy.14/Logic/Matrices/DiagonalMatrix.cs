namespace Logic.Generic
{
    using System;

    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>Create diagonal matrix</summary>
        /// <param name="size">Matrix size</param>
        public DiagonalMatrix(int size) : base(size)
        {
            // Calls base constructor
        }

        /// <summary>Set new diagonal matrix elements</summary>
        /// <param name="elements">New diagonal matrix elements</param>
        public void SetElements(T[] elements)
        {
            if (elements == null || elements.Length != this.Size)
            {
                throw new ArgumentException();
            }

            for (int s = 0; s < this.Size; s++)
            {
                this.SetItem(s, s, elements[s]);
            }
        }

        /// <summary>Set new diagonal matrix elements</summary>
        /// <param name="elements">New diagonal matrix elements</param>
        public override void SetElements(T[,] elements)
        {
            if (elements == null || elements.GetLength(0) != this.Size || elements.GetLength(1) != this.Size)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (!elements[i, j].Equals(default(T)) && i != j)
                    {
                        throw new ArgumentException();
                    }
                }
            }

            base.SetElements(elements);
        }

        /// <summary>Set diagonal matrix item</summary>
        /// <param name="row">Element's row</param>
        /// <param name="col">Element's column</param>
        /// <param name="value">New element's value</param>
        public override void SetItem(int row, int col, T value)
        {
            if (col != row)
            {
                throw new ArgumentException();
            }

            base.SetItem(row, col, value);
        }
    }
}

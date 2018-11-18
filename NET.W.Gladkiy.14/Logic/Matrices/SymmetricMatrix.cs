namespace Logic.Generic
{
    using System;

    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>Create symmetric matrix</summary>
        /// <param name="size">Matrix size</param>
        public SymmetricMatrix(int size) : base(size)
        {
            // Calls base constructor
        }

        /// <summary>Set new symmetric matrix elements</summary>
        /// <param name="elements">New symmetric matrix elements</param>
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
                    if (!elements[i, j].Equals(elements[j, i]))
                    {
                        throw new ArgumentException();
                    }
                }
            }
            
            base.SetElements(elements);
        }

        /// <summary>Set symmetric matrix item</summary>
        /// <param name="row">Element's row</param>
        /// <param name="col">Element's column</param>
        /// <param name="value">New element's value</param>
        public override void SetItem(int row, int col, T value)
        {
            base.SetItem(row, col, value);
            base.SetItem(this.Size - row, this.Size - col, value);
        }
    }
}

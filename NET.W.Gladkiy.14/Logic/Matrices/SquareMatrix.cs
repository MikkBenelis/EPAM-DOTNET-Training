namespace Logic.Generic
{
    using System;

    public class SquareMatrix<T> : IEquatable<SquareMatrix<T>>
    {
        public delegate void ItemChanged(object sender, MatrixChangedEventArgs<T> args);
        public event ItemChanged ItemChangedEvent;

        /// <summary>Create empty sqare matrix</summary>
        /// <param name="size">Square matrix size</param>
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException();
            }

            Size = size;
            Matrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Matrix[i, j] = default(T);
                }
            }
        }

        // Matrix size
        public int Size { get; private set; }

        // Matrix values
        public T[,] Matrix { get; private set; }

        /// <summary>Set new square matrix elements</summary>
        /// <param name="elements">New matrix elements</param>
        public virtual void SetElements(T[,] elements)
        {
            if (elements == null || elements.GetLength(0) != Size || elements.GetLength(1) != Size)
            {
                throw new ArgumentException();
            }
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Matrix[i, j] = elements[i, j];
                }
            }
        }
        
        /// <summary>Set matrix item</summary>
        /// <param name="row">Element's row</param>
        /// <param name="col">Element's column</param>
        /// <param name="value">New element's value</param>
        public virtual void SetItem(int row, int col, T value)
        {
            if (row < 0 || row >= Size || col < 0 || col >= Size)
            {
                throw new ArgumentException();
            }

            T valueBefore = value;
            Matrix[row, col] = value;
            var args = new MatrixChangedEventArgs<T>(row, col, valueBefore, value);
            ItemChangedEvent?.Invoke(this, args);
        }

        /// <summary>Equals</summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>State of equality result</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as SquareMatrix<T>);
        }

        /// <summary>Equals</summary>
        /// <param name="other">Matrix to compare with</param>
        /// <returns>State of equality result</returns>
        public bool Equals(SquareMatrix<T> other)
        {
            if (other == null || Size != other.Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (!Matrix[i, j].Equals(other.Matrix[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>GetHashCode</summary>
        /// <returns>Matrix hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = 31;
            hashCode = hashCode * 31 + Size.GetHashCode();
            hashCode = hashCode * 31 + Matrix.GetHashCode();
            return hashCode;
        }
    }
}

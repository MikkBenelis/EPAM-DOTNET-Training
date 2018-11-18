namespace Logic.Generic
{
    public class MatrixChangedEventArgs<T>
    {
        public MatrixChangedEventArgs(int row, int column, T valueBefore, T valueAfter)
        {
            Row = row;
            Column = column;
            ValueBefore = valueBefore;
            ValueAfter = valueAfter;
        }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public T ValueBefore { get; private set; }

        public T ValueAfter { get; private set; }
    }
}

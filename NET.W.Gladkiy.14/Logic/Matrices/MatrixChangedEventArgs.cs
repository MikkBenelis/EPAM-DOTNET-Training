namespace Logic.Generic
{
    public class MatrixChangedEventArgs<T>
    {
        public int Row;

        public int Column;

        public T ValueBefore;

        public T ValueAfter;

        public MatrixChangedEventArgs(int row, int column, T valueBefore, T valueAfter) {
            Row = row;
            Column = column;
            ValueBefore = valueBefore;
            ValueAfter = valueAfter;
        }
    }
}

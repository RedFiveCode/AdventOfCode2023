using System.Diagnostics;

namespace Day3
{
    [DebuggerDisplay("Value={Value}, Type={Type}, Row={Row}, Column={Column}, ColumnEnd ={ColumnEnd}")]
    public class Symbol
    {
        public enum SymbolType { Part = 0, Cog = 1 }

        public Symbol(string value, SymbolType type, int row = -1, int column = -1)
        {
            Value = value;
            Type = type;
            Row = row;
            Column = column;
        }

        public string Value { get; private set; }

        public SymbolType Type { get; private set; }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public int ColumnEnd
        {
            get { return Column + Value.Length; }
        }

        public bool IsNear(Symbol other)
        {
            return IsNear(other.Row, other.Column);
        }

        private bool IsNear(int row, int column)
        {
            // inclusive range of row indices
            int startRow = Math.Max(0, Row - 1);
            int endRow = Row + 1;

            // inclusive range of column indices
            int startColumn = Math.Max(0, Column  - 1);
            int endColumn = Column + Value.Length;

            return row >= startRow && row <= endRow &&
                   column >= startColumn && column <= endColumn;
        }
    }
}

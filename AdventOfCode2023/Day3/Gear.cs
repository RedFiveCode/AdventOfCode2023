using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Day3
{
    [DebuggerDisplay("First={First}, Second={Second}, Row={Row}, Column={Column}, GearRatio={GearRatio}")]
    public class Gear
    {
        public Gear(int first, int second, int row = -1, int column = -1)
        {
            First = first;
            Second = second;
            Row = row;
            Column = column;
        }

        public int First { get; private set; }

        public int Second { get; private set; }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public int GearRatio
        {
            get { return First * Second; }
        }

        public override string ToString()
        {
            return $"line[{Row + 1}] : first = {First}, second = {Second}";
        }
    }
}

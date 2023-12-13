using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day3
{
    [DebuggerDisplay("PartNumber={PartNumber}, Index={Index}, Row={Row}, Length={Length}")]
    public class EnginePart
    {
        public EnginePart(Match match, int row)
        {
            PartNumber = Int32.Parse(match.Value);
            Row = row;
            Index = match.Index;
            Length = match.Length;
        }

        public int PartNumber { get; private set; }

        public int Row { get; private set; }

        public int Index { get; private set; }

        public int Length { get; private set; }
    }
}

using System.Text.RegularExpressions;

namespace Day3
{
    public class EngineReader
    {
        public Engine Read(string filename)
        {
            var engineSchematic = File.ReadAllLines(filename);

            var engineParts = new List<EnginePart>();
            for (int row = 0; row < engineSchematic.Length; row++)
            {
                var parts = GetEngineParts(engineSchematic[row], row);

                // filter out any parts that are not adjacent to a symbol, even diagonally

                var validParts = parts.Where(p => HasAdjacentSymbol(p, engineSchematic)).ToList();

                engineParts.AddRange(validParts); 
            }

            return new Engine(engineParts);
        }

        private List<EnginePart> GetEngineParts(string line, int row)
        {
            return Regex.Matches(line, @"(\d+)+")
                        .Cast<Match>()
                        .Select(m => new EnginePart(m, row))
                        .ToList();
        }

        private bool HasAdjacentSymbol(EnginePart part, string[] engineSchematic)
        {
            // look for symbol (#,$,*) on
            // same line - cell before numbers
            // same line - cell after numbers
            // previous line - before numbers, after numbers (diagonal relationship)
            // previous line - below numbers (same index)
            // following line - before numbers, after numbers (diagonal relationship)
            // following line - below numbers (same index)
            //
            // Remember that there may or may not be a previous line, following line, a previous cell or a following cell
            // depending on the row value and the index value

            var currentLine = engineSchematic[part.Row];

            var previousLine = (part.Row - 1 < 0 ? null : engineSchematic[part.Row - 1]);
            var followingLine = (part.Row + 1 > engineSchematic.Length - 1 ? null : engineSchematic[part.Row + 1]);

            var startIndex = Math.Max(part.Index - 1, 0);

            // assume current line, previous line and following line are all the same length
            var endIndex = Math.Min(part.Index + part.Length, currentLine.Length - 1);

            // look for symbols in cell on current/previous/next line before the part
            if (startIndex >= 0)
            {
                if (currentLine  != null && ContainsSymbol(currentLine[startIndex]))
                {
                    return true;
                }

                if (previousLine != null && ContainsSymbol(previousLine[startIndex]))
                {
                    return true;
                }

                if (followingLine != null && ContainsSymbol(followingLine[startIndex]))
                {
                    return true;
                }
            }

            // look for symbols in cell on current/previous/next line after the part
            if (endIndex <= currentLine.Length - 1)
            {
                if (currentLine != null && ContainsSymbol(currentLine[endIndex]))
                {
                    return true;
                }

                if (previousLine != null && ContainsSymbol(previousLine[endIndex]))
                {
                    return true;
                }

                if (followingLine != null && ContainsSymbol(followingLine[endIndex]))
                {
                    return true;
                }
            }

            // look for symbols in cell on current/previous/next line within the part
            for (int index = part.Index; index < (part.Index + part.Length); index++)
            {
                if (currentLine != null && ContainsSymbol(currentLine[index]))
                {
                    return true;
                }

                if (previousLine != null && ContainsSymbol(previousLine[index]))
                {
                    return true;
                }

                if (followingLine != null && ContainsSymbol(followingLine[index]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsSymbol(char cell)
        {
            //var symbols = new List<char>() { '*', '$', '#', '+' };

            return cell != '.' && !Char.IsDigit(cell);
        }
    }
}

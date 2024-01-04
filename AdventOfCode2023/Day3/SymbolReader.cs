using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day3
{
    public class SymbolReader
    {
        public List<Symbol> Read(string filename)
        {
            var lines = File.ReadAllLines(filename);

            // get all the part numbers
            // get all the * symbols
            // foreach * symbol, look for adjacent pair of numbers

            var symbols = new List<Symbol>();

            for (int rowIndex = 0; rowIndex < lines.Length; rowIndex++)
            {
                var currentLine = lines[rowIndex];

                symbols.AddRange(ReadLine(currentLine, rowIndex));
            }

            return symbols;
        }

        private List<Symbol> ReadLine(string line, int rowIndex)
        {
            // look for numbers

            var enginePartSymbols = Regex.Matches(line, @"(\d+)+")
                        .Cast<Match>()
                        .Select(m => new Symbol(m.Value, Symbol.SymbolType.Part, rowIndex, m.Index))
                        .ToList();

            // look for cogs
            var cogSymbols = Regex.Matches(line, @"(\*)+")
                        .Cast<Match>()
                        .Select(m => new Symbol(m.Value, Symbol.SymbolType.Cog, rowIndex, m.Index))
                        .ToList();

            var symbols = new List<Symbol>();
            
            symbols.AddRange(enginePartSymbols);
            symbols.AddRange(cogSymbols);

            return symbols;
        }
    }
}

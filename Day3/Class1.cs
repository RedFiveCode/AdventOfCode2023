using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    // https://github.com/objectwizard/AdventOfCode2023/blob/master/Day3.cs
    public class Day3ObjectWizard
    {
        private const string numberMatch = @"\d+";

        private string[] _input;

        public Day3ObjectWizard()
        {
            _input = File.ReadAllLines("PuzzleData.txt");
        }
        public int? Q1()
        {
            var numberTotal = 0;
            for (var i = 0; i < _input.Count(); i++)
            {
                Dictionary<int, char>? symbolMatchesPreviousRow = null;
                Dictionary<int, char>? symbolMatchesNextRow = null;
                var numberMatches = Regex.Matches(_input[i], numberMatch);
                if (i > 0)
                {
                    symbolMatchesPreviousRow = GetAllSymbolMatches(_input[i - 1]);
                }
                var symbolMatchesCurrentRow = GetAllSymbolMatches(_input[i]);
                if (i < _input.Count() - 1)
                {
                    symbolMatchesNextRow = GetAllSymbolMatches(_input[i + 1]);
                }
                foreach (var numberMatch in numberMatches.ToList())
                {
                    var indexMin = numberMatch.Index;
                    var indexMax = numberMatch.Index + numberMatch.Length - 1;
                    if ((symbolMatchesPreviousRow != null && symbolMatchesPreviousRow.Keys.Any(si => indexMin - 1 <= si && indexMax + 1 >= si))
                    || (symbolMatchesCurrentRow.Keys.Any(si => indexMin - 1 <= si && indexMax + 1 >= si))
                    || (symbolMatchesNextRow != null && symbolMatchesNextRow.Keys.Any(si => indexMin - 1 <= si && indexMax + 1 >= si)))
                    {
                        numberTotal += int.Parse(numberMatch.Value);
                    }

                }
            }
            return numberTotal;
        }
        private Dictionary<int, char> GetAllSymbolMatches(string line)
        {
            Dictionary<int, char> matches = new Dictionary<int, char>();
            for (var i = 0; i < line.Count(); i++)
            {
                if (!char.IsNumber(line[i]) && !char.Equals(line[i], '.'))
                {
                    matches.Add(i, line[i]);
                }
            }
            return matches;
        }
        public int? Q2()
        {
            int asteriskCount = 0;

            var numberTotal = 0;
            for (var i = 0; i < _input.Count(); i++)
            {
                var symbolMatchesCurrentRow = GetAsteriskMatches(_input[i]);

                asteriskCount += symbolMatchesCurrentRow.Count;

                foreach (var symbolMatch in symbolMatchesCurrentRow)
                {
                    string? prevRow = null;
                    string? nextRow = null;
                    if (i > 0)
                    {
                        prevRow = _input[i - 1];
                    }
                    if (i < _input.Count() - 1)
                    {
                        nextRow = _input[i + 1];
                    }

                    var numberMatches = GetAdjacentNumberMatches(_input[i], symbolMatch.Key, prevRow, nextRow);

                    if (numberMatches.Count() == 2)
                    {
                        var first = numberMatches[0];
                        var second = numberMatches[1];

                        Console.WriteLine($"line[{i}] : first = {first}, second = {second}");

                        // print lowest then highest number
                        //if (first < second)
                        //{
                        //    Console.WriteLine($"line[{i}] : first = {first}, second = {second}");
                        //}
                        //else
                        //{
                        //    Console.WriteLine($"line[{i}] : first = {second}, second = {first}");
                        //}

                        numberTotal += numberMatches[0] * numberMatches[1];
                    }
                }
            }

            Console.WriteLine($"asteriskCount: {asteriskCount}");

            return numberTotal;
        }
        private Dictionary<int, char> GetAsteriskMatches(string line)
        {
            Dictionary<int, char> matches = new Dictionary<int, char>();
            for (var i = 0; i < line.Count(); i++)
            {
                if (Regex.IsMatch(line[i].ToString(), @"\*"))
                {
                    matches.Add(i, line[i]);
                }
            }
            return matches;
        }
        private List<int> GetAdjacentNumberMatches(string line, int symbolIndex, string? prevLine, string? nextLine)
        {
            List<int> adjacentNumbers = new List<int>();

            var lineNumberMatches = Regex.Matches(line, numberMatch).ToList();

            if (prevLine != null)
            {
                lineNumberMatches.AddRange(Regex.Matches(prevLine, numberMatch));
            }
            if (nextLine != null)
            {
                lineNumberMatches.AddRange(Regex.Matches(nextLine, numberMatch));
            }

            adjacentNumbers.AddRange(lineNumberMatches.Where(ln => (symbolIndex >= ln.Index - 1 && symbolIndex <= (ln.Index + ln.Length)))
                           .Select(m => int.Parse(m.Value)));

            return adjacentNumbers;
        }
    }
}

using System.Text.RegularExpressions;

namespace Day1
{
    public class CalibrationReaderPartTwo
    {
        public IEnumerable<int> ReadCalibration(string filename)
        {
            var data = File.ReadAllLines(filename);

            return ReadCalibration(data);
        }

        public IEnumerable<int> ReadCalibration(string[] data)
        {
            var calibrationValues = new List<int>();
            
            // positive look ahead
            var regex = new Regex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))");

            foreach (var line in data)
            {
                var matches = regex.Matches(line);

                if (matches.Any())
                {
                    var first = matches.First().Groups[1].Value;
                    var last = matches.Last().Groups[1].Value;

                    var firstNumber = ConvertWordToDigit(first);
                    var lastNumber = ConvertWordToDigit(last);

                    int value = (10 * firstNumber) + lastNumber;

                    calibrationValues.Add(value);
                }
            }

            return calibrationValues;
        }

        public int GetCalibrationSum(string filename)
        {
            var data = File.ReadAllLines(filename);
            var calibrationValues = ReadCalibration(data);

            return calibrationValues.Sum();
        }

        private int ConvertWordToDigit(string word)
        {
            var map = new Dictionary<string, int>()
            {
                //{ "zero", 0 },
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },

                //{ "0", 0 },
                { "1", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 }
            };

            return map[word];
        }
    }
}


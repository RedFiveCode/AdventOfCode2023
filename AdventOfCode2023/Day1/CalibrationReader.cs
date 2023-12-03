using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    public class CalibrationReader
    {
        public IEnumerable<int> ReadCalibration(string filename)
        {
            var data = File.ReadAllLines(filename);

            return ReadCalibration(data);
        }

        public int GetCalibrationSum(string filename)
        {
            var data = File.ReadAllLines(filename);
            var calibrationValue = ReadCalibration(data);

            return calibrationValue.Sum();
        }

        public IEnumerable<int> ReadCalibration(string[] data)
        {
            var calibrationValues = new List<int>();

            foreach (var line in data)
            {
                var numbersInCurrentLine = line.ToCharArray()
                    .Where(ch => char.IsDigit(ch))
                    .Select(ch => Int32.Parse(ch.ToString()))
                    .ToList();

                if (numbersInCurrentLine.Any())
                {
                    var first = numbersInCurrentLine.First();
                    var last = (numbersInCurrentLine.Last()); // calibrationValues.Add(numbersInCurrentLine.First());

                    int value = (10 * first) + last;

                    calibrationValues.Add(value);
                }
            }

            return calibrationValues;
        }

        public IEnumerable<int> ReadCalibration2(string[] data)
        {
            var calibrationValues = new List<int>();

            var regex = new Regex(@"(\d)");

            foreach (var line in data)
            {
                var matchResult = regex.Match(line);

                if (matchResult.Success)
                {
                    if (matchResult.Groups.Count > 0)
                    {
                        var first = matchResult.Groups[0].Value;
                        var last = matchResult.Groups[matchResult.Groups.Count - 1].Value;

                        calibrationValues.Add(Int32.Parse(first));
                        calibrationValues.Add(Int32.Parse(last)); // last could also be first if just one item in list
                    }
                }
            }

            return calibrationValues;
        }
    }
}


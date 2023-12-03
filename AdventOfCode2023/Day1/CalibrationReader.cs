using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    }
}


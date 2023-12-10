using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    public class GameReader
    {
        public List<Game> Read(string filename)
        {
            var data = File.ReadAllLines(filename);

            return Read(data);
        }

        public List<Game> Read(string[] data)
        {
            return data.Select(line => {

                // "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"

                var id = ParseGameId(line);

                // "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
                var payload = GetPayload(line);

                // { "3 blue, 4 red", "1 red, 2 green, 6 blue", "2 green" }
                var rounds = GetRounds(payload);

                var roundItems = rounds.Select(r => ParseRound(r)).ToList();

                return new Game(id, roundItems);
            }).ToList();
        }

        private IEnumerable<string> GetRounds(string payload)
        {
            return payload.Split(';');
        }

        private string GetPayload(string line)
        {
            // "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
            //     ->  "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
            var regex = new Regex(@"^Game (\d+): ");

            return regex.Replace(line, string.Empty);
        }

        private int ParseGameId(string line)
        {
            var regex = new Regex(@"Game (\d+):");

            var match = regex.Match(line);
            if (match.Success)
            {
                return Int32.Parse(match.Groups[1].Value);
            }

            return -1;
        }

        private Round ParseRound(string round)
        {
            // "1 red, 2 green, 6 blue" or "3 blue, 4 red"

            var regex = new Regex(@"((\d+) (red|green|blue))+");

            var matches = regex.Matches(round);
            if (matches.Any())
            {
                int red = 0;
                int green = 0;
                int blue = 0;

                foreach (var m in matches.ToList())
                {
                    var count = Int32.Parse(m.Groups[2].Value);
                    var colour = m.Groups[3].Value;
                    
                    if (colour == "red")
                    {
                        red = count;
                    }
                    else if (colour == "green")
                    {
                        green = count;
                    }
                    else if (colour == "blue")
                    {
                        blue = count;
                    }
                }

                return new Round(red, green, blue);
            }

            return null;
        }
    }
}

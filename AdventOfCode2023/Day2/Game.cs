using System.Diagnostics;

namespace Day2
{
    [DebuggerDisplay("Id={Id}, Count={Rounds.Count}")]
    public class Game
    {
        public Game(int id, List<Round> rounds)
        {
            Id = id;
            Rounds = rounds;
        }

        public int Id { get; private set; }

        public List<Round> Rounds { get; private set; }

        public bool IsPossible(int expectedRed, int expectedGreen, int expectedBlue)
        {
            return Rounds.All(r => r.Red <= expectedRed && r.Green <= expectedGreen && r.Blue <= expectedBlue);
        }

        public Round GetFewestCubeCounts()
        {
            int minimumRed = Rounds.Select(r => r.Red).Max();
            int minimumGreen = Rounds.Select(r => r.Green).Max();
            int minimumBlue = Rounds.Select(r => r.Blue).Max();

            return new Round(minimumRed, minimumGreen, minimumBlue);
        }

        public int GetPowerSum()
        {
            var fewest = GetFewestCubeCounts();
            return GetPower(fewest);
        }

        private int GetPower(Round round)
        {
            return round.Red * round.Green * round.Blue;
        }
    }
}

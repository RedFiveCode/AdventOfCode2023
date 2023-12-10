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
    }
}

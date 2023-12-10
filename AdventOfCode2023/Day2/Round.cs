using System.Diagnostics;

namespace Day2
{
    [DebuggerDisplay("Red={Red}, Green={Green}, Blue={Blue}")]
    public class Round
    {
        public Round(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }
    }
}

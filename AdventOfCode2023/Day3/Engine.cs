namespace Day3
{
    public class Engine
    {
        public Engine(List<EnginePart> parts)
        {
            Parts = new List<EnginePart>(parts);
            PartNumbers = parts.Select(p => p.PartNumber).ToList();
        }

        public List<EnginePart> Parts { get; private set; }

        public List<int> PartNumbers { get; private set; }

        public int GetPartNumberSum()
        {
            return PartNumbers.Sum();
        }
    }
}

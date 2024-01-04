namespace Day3
{
    public class SymbolProcessor
    {
        public List<Gear> GetGears(List<Symbol> symbols)
        {
            var enginePartSymbols = symbols.Where(s => s.Type == Symbol.SymbolType.Part).ToList();
            var cogSymbols = symbols.Where(s => s.Type == Symbol.SymbolType.Cog).ToList();

            var gears = new List<Gear>();

            // want enginePartSymbols near cogSymbols

            foreach (var cog in cogSymbols)
            {
                var nearByEnginePartSymbols = enginePartSymbols.Where(p => p.IsNear(cog)).ToList();

                // need two parts to make a gear
                if (nearByEnginePartSymbols.Count == 2)
                {
                    var first = int.Parse(nearByEnginePartSymbols[0].Value);
                    var second = int.Parse(nearByEnginePartSymbols[1].Value);

                    gears.Add(new Gear(first, second, nearByEnginePartSymbols[0].Row, nearByEnginePartSymbols[0].Column));
                }
            }

            return gears;
        }

        private bool IsNear(Symbol part, Symbol cog)
        {
            if (part.Type != Symbol.SymbolType.Part)
            {
                throw new ArgumentException($"Symbol '{part.Value}' is not a Part");
            }

            if (part.Type != Symbol.SymbolType.Cog)
            {
                throw new ArgumentException($"Symbol '{part.Value}' is not a Cog");
            }

            return part.IsNear(cog);
        }
    }
}

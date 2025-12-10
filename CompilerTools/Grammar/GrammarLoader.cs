using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerTools.Grammar
{
    public static class GrammarLoader
    {
        public static GrammarModel Load(string path)
        {
            var g = new GrammarModel();
            var lines = File.ReadAllLines(path);

            foreach (var raw in lines)
            {
                var line = raw.Trim();

                if (line.Length == 0 || line.StartsWith("#"))
                    continue;

                if (!line.Contains("->"))
                    continue;

                var parts = line.Split("->", StringSplitOptions.RemoveEmptyEntries);

                var left = parts[0].Trim();
                var alternatives = parts[1].Split('|');

                foreach (var alt in alternatives)
                {
                    var symbols = alt.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    g.AddProduction(left, new List<string>(symbols));
                }
            }

            // Assume Program é o símbolo inicial
            g.StartSymbol = g.GetOrCreateNonTerminal("Program");

            return g;
        }
    }
}

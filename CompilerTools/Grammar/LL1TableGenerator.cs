using System;
using System.Collections.Generic;
using System.Linq;

namespace CompilerTools.Grammar
{
    public class LL1TableGenerator
    {
        public Dictionary<(string NonTerminal, string Terminal), Production> Table
            = new();

        GrammarModel G;
        FirstFollowGenerator FF;

        public LL1TableGenerator(GrammarModel g, FirstFollowGenerator ff)
        {
            G = g;
            FF = ff;
        }

        public void Build()
        {
            foreach (var p in G.Productions)
            {
                var A = p.Left.Name;

                var firstSet = FIRSTOfProduction(p);

                foreach (var t in firstSet.Where(t => t != "ε"))
                {
                    var key = (A, t);

                    if (Table.ContainsKey(key))
                    {
                        Console.WriteLine($"[CONFLITO LL(1)] {A}, {t}");
                    }
                    else
                        Table[key] = p;
                }

                if (firstSet.Contains("ε"))
                {
                    foreach (var t in FF.FOLLOW[A])
                    {
                        var key = (A, t);

                        if (!Table.ContainsKey(key))
                            Table[key] = p;
                    }
                }
            }
        }

        private HashSet<string> FIRSTOfProduction(Production p)
        {
            if (p.Right.Count == 0)
                return new() { "ε" };

            var set = new HashSet<string>();

            foreach (var X in p.Right)
            {
                if (X.IsTerminal)
                {
                    set.Add(X.Name);
                    return set;
                }

                set.UnionWith(FF.FIRST[X.Name].Where(s => s != "ε"));

                if (!FF.FIRST[X.Name].Contains("ε"))
                    return set;
            }

            set.Add("ε");
            return set;
        }
    }
}

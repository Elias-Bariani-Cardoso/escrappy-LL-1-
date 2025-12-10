using System.Collections.Generic;
using System.Linq;

namespace CompilerTools.Grammar
{
    public class FirstFollowGenerator
    {
        public Dictionary<string, HashSet<string>> FIRST = new();
        public Dictionary<string, HashSet<string>> FOLLOW = new();

        GrammarModel G;

        public FirstFollowGenerator(GrammarModel g)
        {
            G = g;

            foreach (var nt in G.NonTerminals.Keys)
            {
                FIRST[nt] = new();
                FOLLOW[nt] = new();
            }

            FOLLOW[g.StartSymbol.Name].Add("$");
        }

        public void ComputeFIRST()
        {
            bool changed = true;

            while (changed)
            {
                changed = false;

                foreach (var p in G.Productions)
                {
                    var A = p.Left.Name;

                    if (p.Right.Count == 0)
                    {
                        if (FIRST[A].Add("ε"))
                            changed = true;
                        continue;
                    }

                    for (int i = 0; i < p.Right.Count; i++)
                    {
                        var X = p.Right[i];

                        if (X.IsTerminal)
                        {
                            if (FIRST[A].Add(X.Name))
                                changed = true;

                            break;
                        }

                        int before = FIRST[A].Count;

                        FIRST[A].UnionWith(FIRST[X.Name].Where(s => s != "ε"));

                        if (FIRST[A].Count != before)
                            changed = true;

                        if (!FIRST[X.Name].Contains("ε"))
                            break;

                        if (i == p.Right.Count - 1)
                        {
                            if (FIRST[A].Add("ε"))
                                changed = true;
                        }
                    }
                }
            }
        }

        public void ComputeFOLLOW()
        {
            bool changed = true;

            while (changed)
            {
                changed = false;

                foreach (var p in G.Productions)
                {
                    var A = p.Left.Name;

                    for (int i = 0; i < p.Right.Count; i++)
                    {
                        var B = p.Right[i];
                        if (B.IsTerminal)
                            continue;

                        var trailer = new HashSet<string>();

                        if (i + 1 < p.Right.Count)
                        {
                            var beta = p.Right.Skip(i + 1).ToList();
                            var firstBeta = FIRSTSequence(beta);

                            foreach (var t in firstBeta.Where(s => s != "ε"))
                                trailer.Add(t);

                            if (firstBeta.Contains("ε"))
                                trailer.UnionWith(FOLLOW[A]);
                        }
                        else
                        {
                            trailer.UnionWith(FOLLOW[A]);
                        }

                        int before = FOLLOW[B.Name].Count;

                        FOLLOW[B.Name].UnionWith(trailer);

                        if (FOLLOW[B.Name].Count != before)
                            changed = true;
                    }
                }
            }
        }

        private HashSet<string> FIRSTSequence(List<Symbol> seq)
        {
            var set = new HashSet<string>();

            if (seq.Count == 0)
            {
                set.Add("ε");
                return set;
            }

            foreach (var X in seq)
            {
                if (X.IsTerminal)
                {
                    set.Add(X.Name);
                    return set;
                }

                set.UnionWith(FIRST[X.Name].Where(s => s != "ε"));

                if (!FIRST[X.Name].Contains("ε"))
                    return set;
            }

            set.Add("ε");
            return set;
        }
    }
}

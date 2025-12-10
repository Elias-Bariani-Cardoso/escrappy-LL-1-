using System.Collections.Generic;
using System.Linq;

namespace CompilerTools.Grammar
{
    public static class LeftFactoring
    {
        public static void Apply(GrammarModel g)
        {
            bool changed = true;

            while (changed)
            {
                changed = false;

                var groups = g.Productions
                    .GroupBy(p => p.Left.Name)
                    .ToDictionary(gp => gp.Key, gp => gp.ToList());

                foreach (var A in groups.Keys)
                {
                    var prods = groups[A];

                    var prefixGroups = prods
                        .Where(p => p.Right.Count > 0)
                        .GroupBy(p => p.Right[0].Name)
                        .Where(gp => gp.Count() > 1)
                        .ToList();

                    if (!prefixGroups.Any())
                        continue;

                    var grp = prefixGroups.First();
                    var A_ = g.GetOrCreateNonTerminal(A + "_F");

                    g.Productions.RemoveAll(p => p.Left.Name == A);

                    g.Productions.Add(new Production(
                        g.NonTerminals[A],
                        new() { grp.First().Right[0], A_ }
                    ));

                    foreach (var p in grp)
                        g.Productions.Add(new Production(A_, p.Right.Skip(1).ToList()));

                    foreach (var p in prods.Where(p => !grp.Contains(p)))
                        g.Productions.Add(p);

                    changed = true;
                    break;
                }
            }
        }
    }
}

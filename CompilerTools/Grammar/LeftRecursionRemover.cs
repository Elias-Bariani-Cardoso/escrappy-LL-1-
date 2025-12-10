using System.Collections.Generic;
using System.Linq;

namespace CompilerTools.Grammar
{
    public static class LeftRecursionRemover
    {
        public static void Remove(GrammarModel g)
        {
            foreach (var A in g.NonTerminals.Keys.ToList())
            {
                var prods = g.Productions.Where(p => p.Left.Name == A).ToList();

                var alpha = new List<List<Symbol>>();
                var beta = new List<List<Symbol>>();

                foreach (var p in prods)
                {
                    if (p.Right.Count > 0 && p.Right[0].Name == A)
                        alpha.Add(p.Right.Skip(1).ToList());
                    else
                        beta.Add(p.Right);
                }

                if (alpha.Count == 0)
                    continue;

                var A_ = g.GetOrCreateNonTerminal(A + "'");

                g.Productions.RemoveAll(p => p.Left.Name == A);

                foreach (var b in beta)
                    g.Productions.Add(new Production(
                        g.NonTerminals[A],
                        b.Concat(new[] { A_ }).ToList()
                    ));

                foreach (var a in alpha)
                    g.Productions.Add(new Production(
                        A_,
                        a.Concat(new[] { A_ }).ToList()
                    ));

                g.Productions.Add(new Production(A_, new())); // ε
            }
        }
    }
}

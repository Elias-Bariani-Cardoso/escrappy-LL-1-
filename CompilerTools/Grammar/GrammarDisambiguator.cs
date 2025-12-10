using System.Collections.Generic;
using System.Linq;

namespace CompilerTools.Grammar
{
    public static class GrammarDisambiguator
    {
        public static void Apply(ref GrammarModel g)
        {
            if (!g.NonTerminals.ContainsKey("Expr"))
                return;

            var Expr = g.GetOrCreateNonTerminal("Expr");
            var ExprP = g.GetOrCreateNonTerminal("ExprP");
            var Term = g.GetOrCreateNonTerminal("Term");
            var TermP = g.GetOrCreateNonTerminal("TermP");
            var Factor = g.GetOrCreateNonTerminal("Factor");

            var PLUS = g.GetOrCreateTerminal("+");
            var STAR = g.GetOrCreateTerminal("*");

            // Remove rules ambíguas antigas
            g.Productions.RemoveAll(p =>
                p.Left.Name == "Expr" ||
                p.Left.Name == "Term"
            );

            // Expr → Term Expr'
            g.Productions.Add(new Production(Expr, new() { Term, ExprP }));

            // Expr' → + Term Expr' | ε
            g.Productions.Add(new Production(ExprP, new() { PLUS, Term, ExprP }));
            g.Productions.Add(new Production(ExprP, new())); // ε

            // Term → Factor Term'
            g.Productions.Add(new Production(Term, new() { Factor, TermP }));

            // Term' → * Factor Term' | ε
            g.Productions.Add(new Production(TermP, new() { STAR, Factor, TermP }));
            g.Productions.Add(new Production(TermP, new())); // ε
        }
    }
}

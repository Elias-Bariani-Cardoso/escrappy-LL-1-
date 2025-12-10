using System.Collections.Generic;

namespace CompilerTools.Grammar
{
    public static class GrammarPatches
    {
        public static void Apply(GrammarModel g)
        {
            // Ajuste para ReturnStmt ambíguo
            g.Productions.RemoveAll(p => p.Left.Name == "ReturnStmt");

            var ReturnStmt = g.GetOrCreateNonTerminal("ReturnStmt");
            var ReturnTail = g.GetOrCreateNonTerminal("ReturnTail");

            var RETURN = g.GetOrCreateTerminal("return");

            g.Productions.Add(new Production(ReturnStmt, new() { RETURN, ReturnTail }));

            // ReturnTail -> Expr | ε
            g.Productions.Add(new Production(ReturnTail, new() { g.GetOrCreateNonTerminal("Expr") }));
            g.Productions.Add(new Production(ReturnTail, new())); // ε
        }
    }
}

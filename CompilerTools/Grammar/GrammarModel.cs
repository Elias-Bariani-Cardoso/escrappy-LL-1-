using System;
using System.Collections.Generic;
using System.Linq;

namespace CompilerTools.Grammar
{
    public class Symbol
    {
        public string Name { get; }
        public bool IsTerminal { get; }

        public Symbol(string name, bool isTerminal)
        {
            Name = name;
            IsTerminal = isTerminal;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Production
    {
        public Symbol Left { get; }
        public List<Symbol> Right { get; }

        public Production(Symbol left, List<Symbol> right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            if (Right.Count == 0)
                return $"{Left.Name} -> ε";

            return $"{Left.Name} -> {string.Join(" ", Right)}";
        }
    }

    public class GrammarModel
    {
        public Dictionary<string, Symbol> Terminals = new();
        public Dictionary<string, Symbol> NonTerminals = new();
        public List<Production> Productions = new();

        public Symbol StartSymbol;

        public Symbol GetOrCreateNonTerminal(string name)
        {
            if (!NonTerminals.ContainsKey(name))
                NonTerminals[name] = new Symbol(name, false);

            return NonTerminals[name];
        }

        public Symbol GetOrCreateTerminal(string name)
        {
            if (!Terminals.ContainsKey(name))
                Terminals[name] = new Symbol(name, true);

            return Terminals[name];
        }

        public Production AddProduction(string left, List<string> right)
        {
            var L = GetOrCreateNonTerminal(left);
            var R = new List<Symbol>();

            foreach (var token in right)
            {
                if (token == "ε")
                    continue;

                bool isNT = char.IsUpper(token[0]);
                R.Add(isNT ? GetOrCreateNonTerminal(token) : GetOrCreateTerminal(token));
            }

            var p = new Production(L, R);
            Productions.Add(p);
            return p;
        }
    }
}

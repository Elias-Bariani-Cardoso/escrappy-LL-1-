namespace EscrappyCompiler.Parsing;

using EscrappyCompiler.Lexing;

public enum SymbolKind
{
    Terminal,
    NonTerminal,
    Epsilon,
    EndOfInput
}

public readonly struct Symbol
{
    public SymbolKind Kind { get; }
    public TokenType Terminal { get; }
    public NonTerminal NonTerminal { get; }

    private Symbol(SymbolKind kind, TokenType terminal, NonTerminal nonTerminal)
    {
        Kind = kind;
        Terminal = terminal;
        NonTerminal = nonTerminal;
    }

    public static Symbol T(TokenType t) => new(SymbolKind.Terminal, t, default);
    public static Symbol N(NonTerminal n) => new(SymbolKind.NonTerminal, default, n);
    public static Symbol Epsilon() => new(SymbolKind.Epsilon, default, default);
    public static Symbol End() => new(SymbolKind.EndOfInput, TokenType.EndOfFile, default);
}

public sealed class Production
{
    public NonTerminal Left { get; }
    public IReadOnlyList<Symbol> Right { get; }

    public Production(NonTerminal left, params Symbol[] right)
    {
        Left = left;
        Right = right;
    }
}

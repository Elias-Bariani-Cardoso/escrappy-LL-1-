using EscrappyCompiler.Lexing;

namespace EscrappyCompiler.Parsing;

public sealed class Parser
{
    private readonly List<Token> _tokens;
    private int _position;
    private readonly ParsingTable _table = new();
    private readonly Stack<Symbol> _stack = new();

    public Parser(IEnumerable<Token> tokens)
    {
        _tokens = tokens.ToList();
    }

    private Token Current => _position < _tokens.Count
        ? _tokens[_position]
        : _tokens[^1]; // último (EOF)

    public bool Parse(bool trace = true)
    {
        _stack.Clear();
        _stack.Push(Symbol.End());
        _stack.Push(Symbol.N(Grammar.StartSymbol));

        while (_stack.Count > 0)
        {
            var top = _stack.Peek();
            var lookahead = Current;

            if (trace)
                PrintStep(top, lookahead);

            switch (top.Kind)
            {
                case SymbolKind.Terminal:
                    if (lookahead.Type == top.Terminal)
                    {
                        _stack.Pop();
                        _position++; // consome token
                    }
                    else
                    {
                        Console.WriteLine($"Erro sintático: esperado {top.Terminal}, encontrado {lookahead.Type} em {lookahead.Line},{lookahead.Column}");
                        return false;
                    }
                    break;

                case SymbolKind.NonTerminal:
                    if (_table.TryGetProduction(top.NonTerminal, lookahead.Type, out var production))
                    {
                        _stack.Pop();
                        // empilha a produção da direita para a esquerda
                        var right = production.Right;
                        if (right.Count == 1 && right[0].Kind == SymbolKind.Epsilon)
                        {
                            // não empilha nada para ε
                        }
                        else
                        {
                            for (int i = right.Count - 1; i >= 0; i--)
                                _stack.Push(right[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Erro sintático: nenhuma produção para {top.NonTerminal} com lookahead {lookahead.Type} em {lookahead.Line},{lookahead.Column}");
                        return false;
                    }
                    break;

                case SymbolKind.EndOfInput:
                    if (lookahead.Type == TokenType.EndOfFile)
                    {
                        _stack.Pop();
                        return true; // aceito
                    }
                    Console.WriteLine($"Erro sintático: esperado EOF, encontrado {lookahead.Type}");
                    return false;

                case SymbolKind.Epsilon:
                    _stack.Pop();
                    break;
            }
        }

        return true;
    }

    private void PrintStep(Symbol top, Token lookahead)
    {
        var stackContent = string.Join(" ",
            _stack.Reverse().Select(s =>
                s.Kind switch
                {
                    SymbolKind.Terminal => s.Terminal.ToString(),
                    SymbolKind.NonTerminal => s.NonTerminal.ToString(),
                    SymbolKind.EndOfInput => "$",
                    SymbolKind.Epsilon => "ε",
                    _ => "?"
                }));

        Console.WriteLine($"Pilha: {stackContent} | Lookahead: {lookahead.Type} ('{lookahead.Lexeme}')");
    }
}

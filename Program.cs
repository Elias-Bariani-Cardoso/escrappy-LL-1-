using EscrappyCompiler.Lexing;
using EscrappyCompiler.Parsing;

string path = args.Length > 0 ? args[0] : "Samples/sample1.scr";

if (!File.Exists(path))
{
    Console.WriteLine($"Arquivo não encontrado: {path}");
    return;
}

string source = File.ReadAllText(path);

// LÉXICO
var lexer = new Lexer(source);
var tokens = lexer.Tokenize().ToList();

// verifica erro léxico antes de qualquer coisa
var lexError = tokens.FirstOrDefault(t => t.Type == TokenType.Error);
if (lexError != null)
{
    Console.WriteLine("Erro léxico:");
    Console.WriteLine(
        $"  Linha {lexError.Line}, Coluna {lexError.Column}: {lexError.Lexeme}");
    return;
}

Console.WriteLine("Tokens:");
foreach (var token in tokens)
    Console.WriteLine(token);

Console.WriteLine();
Console.WriteLine("Parsing (LL(1))");

// SINTÁTICO
var parser = new Parser(tokens);
Console.WriteLine("Tabela[Statement, Identifier] = " +
    (new ParsingTable().TryGetProduction(NonTerminal.Statement, TokenType.Identifier, out var p) ?
     Array.IndexOf(Grammar.Productions.ToArray(), p) : -1));

bool ok = parser.Parse(trace: true);

Console.WriteLine();
Console.WriteLine(ok ? "Programa aceito." : "Programa rejeitado.");

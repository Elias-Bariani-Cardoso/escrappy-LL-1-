using EscrappyCompiler.Lexing;

namespace EscrappyCompiler.Parsing;

public sealed class ParsingTable
{
    // chave: (Não-terminal, Terminal lookahead) -> índice da produção em Grammar.Productions
    private readonly Dictionary<(NonTerminal, TokenType), int> _table = new();

    public ParsingTable()
    {
        Build();
    }

    private void Build()
    {
        // Program -> StatementList EOF  (0)
        _table[(NonTerminal.Program, TokenType.IntType)] = 0;
        _table[(NonTerminal.Program, TokenType.If)] = 0;
        _table[(NonTerminal.Program, TokenType.While)] = 0;
        _table[(NonTerminal.Program, TokenType.Print)] = 0;
        _table[(NonTerminal.Program, TokenType.Identifier)] = 0;
        _table[(NonTerminal.Program, TokenType.EndOfFile)] = 0;

        // StatementList -> Statement StatementList | ε
        _table[(NonTerminal.StatementList, TokenType.IntType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.If)] = 1;
        _table[(NonTerminal.StatementList, TokenType.While)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Print)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Identifier)] = 1;

        _table[(NonTerminal.StatementList, TokenType.EndOfFile)] = 2;
        _table[(NonTerminal.StatementList, TokenType.RParen)] = 2;

        // Statement -> VarDecl ';' | IfStmt | WhileStmt | PrintStmt ';' | AssignStmt ';' | Expr ';'
        _table[(NonTerminal.Statement, TokenType.IntType)] = 3; // VarDecl ';'
        _table[(NonTerminal.Statement, TokenType.If)] = 4; // IfStmt
        _table[(NonTerminal.Statement, TokenType.While)] = 5; // WhileStmt
        _table[(NonTerminal.Statement, TokenType.Print)] = 6; // PrintStmt ';'
        _table[(NonTerminal.Statement, TokenType.Identifier)] = 7; // AssignStmt ';'

        // VarDecl -> INT ID   (9)
        _table[(NonTerminal.VarDecl, TokenType.IntType)] = 9;

        // IfStmt (10)
        _table[(NonTerminal.IfStmt, TokenType.If)] = 10;

        // WhileStmt (11)
        _table[(NonTerminal.WhileStmt, TokenType.While)] = 11;

        // PrintStmt (12)
        _table[(NonTerminal.PrintStmt, TokenType.Print)] = 12;

        // Expr -> RelExpr      (13)
        _table[(NonTerminal.Expr, TokenType.IntLiteral)] = 13;
        _table[(NonTerminal.Expr, TokenType.Identifier)] = 13;
        _table[(NonTerminal.Expr, TokenType.LParen)] = 13;

        // RelExpr -> AddExpr RelPrime   (14)
        _table[(NonTerminal.RelExpr, TokenType.IntLiteral)] = 14;
        _table[(NonTerminal.RelExpr, TokenType.Identifier)] = 14;
        _table[(NonTerminal.RelExpr, TokenType.LParen)] = 14;

        // RelPrime
        // 15..20: operadores relacionais
        _table[(NonTerminal.RelPrime, TokenType.Less)] = 15;
        _table[(NonTerminal.RelPrime, TokenType.LessEqual)] = 16;
        _table[(NonTerminal.RelPrime, TokenType.Greater)] = 17;
        _table[(NonTerminal.RelPrime, TokenType.GreaterEqual)] = 18;
        _table[(NonTerminal.RelPrime, TokenType.EqualEqual)] = 19;
        _table[(NonTerminal.RelPrime, TokenType.NotEqual)] = 20;
        // 21: RelPrime -> ε   FOLLOW(RelExpr) ≈ { ';', ')', '(' }
        _table[(NonTerminal.RelPrime, TokenType.Semicolon)] = 21;
        _table[(NonTerminal.RelPrime, TokenType.RParen)] = 21;
        _table[(NonTerminal.RelPrime, TokenType.LParen)] = 21;

        // AddExpr -> Term ExprPrime    (22)
        _table[(NonTerminal.AddExpr, TokenType.IntLiteral)] = 22;
        _table[(NonTerminal.AddExpr, TokenType.Identifier)] = 22;
        _table[(NonTerminal.AddExpr, TokenType.LParen)] = 22;

        // ExprPrime
        // 23: '+' Term ExprPrime
        // 24: '-' Term ExprPrime
        // 25: ε
        _table[(NonTerminal.ExprPrime, TokenType.Plus)] = 23;
        _table[(NonTerminal.ExprPrime, TokenType.Minus)] = 24;

        _table[(NonTerminal.ExprPrime, TokenType.Semicolon)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.RParen)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.LParen)] = 25;

        _table[(NonTerminal.ExprPrime, TokenType.Less)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.LessEqual)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.Greater)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.GreaterEqual)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.EqualEqual)] = 25;
        _table[(NonTerminal.ExprPrime, TokenType.NotEqual)] = 25;

        // Term -> Factor TermPrime   (26)
        _table[(NonTerminal.Term, TokenType.IntLiteral)] = 26;
        _table[(NonTerminal.Term, TokenType.Identifier)] = 26;
        _table[(NonTerminal.Term, TokenType.LParen)] = 26;

        // TermPrime
        // 27: '*' Factor TermPrime
        // 28: '/' Factor TermPrime
        // 29: ε
        _table[(NonTerminal.TermPrime, TokenType.Mul)] = 27;
        _table[(NonTerminal.TermPrime, TokenType.Div)] = 28;

        _table[(NonTerminal.TermPrime, TokenType.Plus)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.Minus)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.Semicolon)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.RParen)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.LParen)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.Less)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.LessEqual)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.Greater)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.GreaterEqual)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.EqualEqual)] = 29;
        _table[(NonTerminal.TermPrime, TokenType.NotEqual)] = 29;

        // Factor
        // 30: INT_LITERAL
        // 31: ID
        // 32: '(' Expr ')'
        _table[(NonTerminal.Factor, TokenType.IntLiteral)] = 30;
        _table[(NonTerminal.Factor, TokenType.Identifier)] = 31;
        _table[(NonTerminal.Factor, TokenType.LParen)] = 32;

        // AssignStmt -> Identifier Assign Expr   (33)
        _table[(NonTerminal.AssignStmt, TokenType.Identifier)] = 33;

        // ElsePart
        // 34: ELSEIF '(' Expr ')' '(' StatementList ')' ElsePart
        // 35: ELSE '(' StatementList ')'
        // 36: ε
        _table[(NonTerminal.ElsePart, TokenType.ElseIf)] = 34;
        _table[(NonTerminal.ElsePart, TokenType.Else)] = 35;

        // FOLLOW(ElsePart) = FOLLOW(IfStmt) ≈ FIRST(Statement) ∪ { EOF, RParen }
        _table[(NonTerminal.ElsePart, TokenType.IntType)] = 36;
        _table[(NonTerminal.ElsePart, TokenType.If)] = 36;
        _table[(NonTerminal.ElsePart, TokenType.While)] = 36;
        _table[(NonTerminal.ElsePart, TokenType.Print)] = 36;
        _table[(NonTerminal.ElsePart, TokenType.Identifier)] = 36;
        _table[(NonTerminal.ElsePart, TokenType.EndOfFile)] = 36;
        _table[(NonTerminal.ElsePart, TokenType.RParen)] = 36;
    }

    public bool TryGetProduction(NonTerminal nt, TokenType lookahead, out Production production)
    {
        if (_table.TryGetValue((nt, lookahead), out int index))
        {
            production = Grammar.Productions[index];
            return true;
        }

        production = null!;
        return false;
    }
}

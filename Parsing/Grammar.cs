using EscrappyCompiler.Lexing;

namespace EscrappyCompiler.Parsing;

public static class Grammar
{
    public static readonly NonTerminal StartSymbol = NonTerminal.Program;

    public static readonly IReadOnlyList<Production> Productions = new[]
    {
        //  0
        // Program -> StatementList EOF
        new Production(
            NonTerminal.Program,
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.EndOfFile)
        ),

        //  1
        // StatementList -> Statement StatementList
        new Production(
            NonTerminal.StatementList,
            Symbol.N(NonTerminal.Statement),
            Symbol.N(NonTerminal.StatementList)
        ),

        //  2
        // StatementList -> ε
        new Production(
            NonTerminal.StatementList,
            Symbol.Epsilon()
        ),

        //  3
        // Statement -> VarDecl ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.VarDecl),
            Symbol.T(TokenType.Semicolon)
        ),

        //  4
        // Statement -> IfStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.IfStmt)
        ),

        //  5
        // Statement -> WhileStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.WhileStmt)
        ),

        //  6
        // Statement -> PrintStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.PrintStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  7
        // Statement -> AssignStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.AssignStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  8
        // Statement -> Expr ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.Semicolon)
        ),

        //  9
        // VarDecl -> INT ID
        new Production(
            NonTerminal.VarDecl,
            Symbol.T(TokenType.IntType),
            Symbol.T(TokenType.Identifier)
        ),

        // 10
        // IfStmt -> IF '(' Expr ')' '(' StatementList ')' ElsePart
        new Production(
            NonTerminal.IfStmt,
            Symbol.T(TokenType.If),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen),
            Symbol.N(NonTerminal.ElsePart)
        ),

        // 11
        // WhileStmt -> WHILE '(' Expr ')' '(' StatementList ')'
        new Production(
            NonTerminal.WhileStmt,
            Symbol.T(TokenType.While),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen)
        ),

        // 12
        // PrintStmt -> PRINT Expr
        new Production(
            NonTerminal.PrintStmt,
            Symbol.T(TokenType.Print),
            Symbol.N(NonTerminal.Expr)
        ),

        // EXPRESSÕES COM COMPARAÇÃO

        // 13
        // Expr -> RelExpr
        new Production(
            NonTerminal.Expr,
            Symbol.N(NonTerminal.RelExpr)
        ),

        // 14
        // RelExpr -> AddExpr RelPrime
        new Production(
            NonTerminal.RelExpr,
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 15
        // RelPrime -> '<' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.Less),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 16
        // RelPrime -> '<=' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.LessEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 17
        // RelPrime -> '>' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.Greater),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 18
        // RelPrime -> '>=' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.GreaterEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 19
        // RelPrime -> '==' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.EqualEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 20
        // RelPrime -> '<>' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.NotEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 21
        // RelPrime -> ε
        new Production(
            NonTerminal.RelPrime,
            Symbol.Epsilon()
        ),

        // 22
        // AddExpr -> Term ExprPrime
        new Production(
            NonTerminal.AddExpr,
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 23
        // ExprPrime -> '+' Term ExprPrime
        new Production(
            NonTerminal.ExprPrime,
            Symbol.T(TokenType.Plus),
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 24
        // ExprPrime -> '-' Term ExprPrime
        new Production(
            NonTerminal.ExprPrime,
            Symbol.T(TokenType.Minus),
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 25
        // ExprPrime -> ε
        new Production(
            NonTerminal.ExprPrime,
            Symbol.Epsilon()
        ),

        // 26
        // Term -> Factor TermPrime
        new Production(
            NonTerminal.Term,
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 27
        // TermPrime -> '*' Factor TermPrime
        new Production(
            NonTerminal.TermPrime,
            Symbol.T(TokenType.Mul),
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 28
        // TermPrime -> '/' Factor TermPrime
        new Production(
            NonTerminal.TermPrime,
            Symbol.T(TokenType.Div),
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 29
        // TermPrime -> ε
        new Production(
            NonTerminal.TermPrime,
            Symbol.Epsilon()
        ),

        // 30
        // Factor -> INT_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.IntLiteral)
        ),

        // 31
        // Factor -> ID
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.Identifier)
        ),

        // 32
        // Factor -> '(' Expr ')'
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen)
        ),

        // 33
        // AssignStmt -> Identifier Assign Expr
        new Production(
            NonTerminal.AssignStmt,
            Symbol.T(TokenType.Identifier),
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Expr)
        ),

        // 34
        // ElsePart -> ELSEIF '(' Expr ')' '(' StatementList ')' ElsePart
        new Production(
            NonTerminal.ElsePart,
            Symbol.T(TokenType.ElseIf),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen),
            Symbol.N(NonTerminal.ElsePart)
        ),

        // 35
        // ElsePart -> ELSE '(' StatementList ')'
        new Production(
            NonTerminal.ElsePart,
            Symbol.T(TokenType.Else),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen)
        ),

        // 36
        // ElsePart -> ε
        new Production(
            NonTerminal.ElsePart,
            Symbol.Epsilon()
        )
    };
}

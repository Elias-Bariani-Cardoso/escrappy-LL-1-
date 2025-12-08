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
        // Statement -> DoStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.DoStmt)
        ),

        //  7
        // Statement -> ForStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.ForStmt)
        ),

        //  8
        // Statement -> PrintStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.PrintStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  9
        // Statement -> AssignStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.AssignStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  10
        // Statement -> Expr ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.Semicolon)
        ),

        //  11
        // Statement -> FetchStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.FetchStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  12
        // Statement -> SelectStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.SelectStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  13
        // Statement -> UpdateStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.UpdateStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  14
        // Statement -> SaveStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.SaveStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        //  15
        // Statement -> FuncDecl
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.FuncDecl)
        ),

        //  16
        // Statement -> ReturnStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.ReturnStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 17
        // VarDecl -> Type Identifier VarDeclPart
        new Production(
            NonTerminal.VarDecl,
            Symbol.N(NonTerminal.Type),
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.VarDeclPart)
        ),

        // 18
        // VarDeclPart -> ArrayDim
        new Production(
            NonTerminal.VarDeclPart,
            Symbol.N(NonTerminal.ArrayDim)
        ),

        // 19
        // ArrayDim -> '[' IntLiteral ']'
        new Production(
            NonTerminal.ArrayDim,
            Symbol.T(TokenType.LBracket),
            Symbol.T(TokenType.IntLiteral),
            Symbol.T(TokenType.RBracket)
        ),

        // 20
        // ArrayDim -> ε
        new Production(
            NonTerminal.ArrayDim,
            Symbol.Epsilon()
        ),

        // 21
        // Type -> INT | BOOL | FLOAT | CHAR | STRING | BIT | VOID
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.IntType)
        ),
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.BoolType)
        ),
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.FloatType)
        ),
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.CharType)
        ),
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.StringType)
        ),
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.BitType)
        ),
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.VoidType)
        ),

        // 28
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

        // 29
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

        // 30
        // DoStmt -> DO '(' StatementList ')' WHILE '(' Expr ')' ';'
        new Production(
            NonTerminal.DoStmt,
            Symbol.T(TokenType.Do),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.While),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.Semicolon)
        ),

        // 31
        // ForStmt -> FOR '(' AssignStmt ';' Expr ';' AssignStmt ')' '(' StatementList ')'
        new Production(
            NonTerminal.ForStmt,
            Symbol.T(TokenType.For),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.AssignStmt),
            Symbol.T(TokenType.Semicolon),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.Semicolon),
            Symbol.N(NonTerminal.AssignStmt),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen)
        ),

        // 32
        // PrintStmt -> PRINT Expr
        new Production(
            NonTerminal.PrintStmt,
            Symbol.T(TokenType.Print),
            Symbol.N(NonTerminal.Expr)
        ),

                // 33
        // FetchStmt -> FETCH Identifier FROM Identifier
        new Production(
            NonTerminal.FetchStmt,
            Symbol.T(TokenType.Fetch),
            Symbol.T(TokenType.Identifier),
            Symbol.T(TokenType.From),
            Symbol.T(TokenType.Identifier)
        ),

        // 34
        // SelectStmt -> SELECT ColumnList FROM Identifier Conditions
        new Production(
            NonTerminal.SelectStmt,
            Symbol.T(TokenType.Select),
            Symbol.N(NonTerminal.ColumnList),
            Symbol.T(TokenType.From),
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.Conditions)
        ),

        // 35
        // ColumnList -> '*'
        new Production(
            NonTerminal.ColumnList,
            Symbol.T(TokenType.Mul)
        ),

        // 36
        // ColumnList -> Identifier ColumnListPrime
        new Production(
            NonTerminal.ColumnList,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.ColumnListPrime)
        ),

        // 37
        // ColumnListPrime -> ',' ColumnList
        new Production(
            NonTerminal.ColumnListPrime,
            Symbol.T(TokenType.Comma),
            Symbol.N(NonTerminal.ColumnList)
        ),

        // 38
        // ColumnListPrime -> ε
        new Production(
            NonTerminal.ColumnListPrime,
            Symbol.Epsilon()
        ),

        // 39
        // Conditions -> WHERE Expr
        new Production(
            NonTerminal.Conditions,
            Symbol.T(TokenType.Where),
            Symbol.N(NonTerminal.Expr)
        ),

        // 40
        // Conditions -> ε
        new Production(
            NonTerminal.Conditions,
            Symbol.Epsilon()
        ),

        // 41
        // UpdateStmt -> UPDATE Identifier SET Identifier Assign Expr
        new Production(
            NonTerminal.UpdateStmt,
            Symbol.T(TokenType.Update),
            Symbol.T(TokenType.Identifier),
            Symbol.T(TokenType.Set),
            Symbol.T(TokenType.Identifier),
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Expr)
        ),

        // 42
        // SaveStmt -> SAVE Identifier
        new Production(
            NonTerminal.SaveStmt,
            Symbol.T(TokenType.Save),
            Symbol.T(TokenType.Identifier)
        ),

        // 43
        // FuncDecl -> FUNC Identifier '(' ParamList ')' Assign Type '(' StatementList ')'
        new Production(
            NonTerminal.FuncDecl,
            Symbol.T(TokenType.Func),
            Symbol.T(TokenType.Identifier),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.ParamList),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Type),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen)
        ),

        // 44
        // ParamList -> Param ParamListPrime
        new Production(
            NonTerminal.ParamList,
            Symbol.N(NonTerminal.Param),
            Symbol.N(NonTerminal.ParamListPrime)
        ),

        // 45
        // ParamList -> ε
        new Production(
            NonTerminal.ParamList,
            Symbol.Epsilon()
        ),

        // 46
        // Param -> Type Identifier
        new Production(
            NonTerminal.Param,
            Symbol.N(NonTerminal.Type),
            Symbol.T(TokenType.Identifier)
        ),

        // 47
        // ParamListPrime -> ',' Param ParamListPrime
        new Production(
            NonTerminal.ParamListPrime,
            Symbol.T(TokenType.Comma),
            Symbol.N(NonTerminal.Param),
            Symbol.N(NonTerminal.ParamListPrime)
        ),

        // 48
        // ParamListPrime -> ε
        new Production(
            NonTerminal.ParamListPrime,
            Symbol.Epsilon()
        ),

        // 49
        // ReturnStmt -> RETURN Expr
        new Production(
            NonTerminal.ReturnStmt,
            Symbol.T(TokenType.Return),
            Symbol.N(NonTerminal.Expr)
        ),

        // 50
        // ReturnStmt -> RETURN
        new Production(
            NonTerminal.ReturnStmt,
            Symbol.T(TokenType.Return)
        ),

        // EXPRESSÕES LÓGICAS E COMPARAÇÃO

        // 51
        // Expr -> LogicTerm LogicExprPrime
        new Production(
            NonTerminal.Expr,
            Symbol.N(NonTerminal.LogicTerm),
            Symbol.N(NonTerminal.LogicExprPrime)
        ),

        // 52
        // LogicExprPrime -> OR LogicTerm LogicExprPrime
        new Production(
            NonTerminal.LogicExprPrime,
            Symbol.T(TokenType.Or),
            Symbol.N(NonTerminal.LogicTerm),
            Symbol.N(NonTerminal.LogicExprPrime)
        ),

        // 53
        // LogicExprPrime -> ε
        new Production(
            NonTerminal.LogicExprPrime,
            Symbol.Epsilon()
        ),

        // 54
        // LogicTerm -> RelExpr LogicTermPrime
        new Production(
            NonTerminal.LogicTerm,
            Symbol.N(NonTerminal.RelExpr),
            Symbol.N(NonTerminal.LogicTermPrime)
        ),

        // 55
        // LogicTermPrime -> AND RelExpr LogicTermPrime
        new Production(
            NonTerminal.LogicTermPrime,
            Symbol.T(TokenType.And),
            Symbol.N(NonTerminal.RelExpr),
            Symbol.N(NonTerminal.LogicTermPrime)
        ),

        // 56
        // LogicTermPrime -> ε
        new Production(
            NonTerminal.LogicTermPrime,
            Symbol.Epsilon()
        ),

        // 57
        // RelExpr -> AddExpr RelPrime
        new Production(
            NonTerminal.RelExpr,
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 58
        // RelPrime -> '<' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.Less),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 59
        // RelPrime -> '<=' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.LessEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 60
        // RelPrime -> '>' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.Greater),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 61
        // RelPrime -> '>=' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.GreaterEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 62
        // RelPrime -> '==' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.EqualEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 63
        // RelPrime -> '<>' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.NotEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 64
        // RelPrime -> ε
        new Production(
            NonTerminal.RelPrime,
            Symbol.Epsilon()
        ),

        // 65
        // AddExpr -> Term ExprPrime
        new Production(
            NonTerminal.AddExpr,
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 66
        // ExprPrime -> '+' Term ExprPrime
        new Production(
            NonTerminal.ExprPrime,
            Symbol.T(TokenType.Plus),
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 67
        // ExprPrime -> '-' Term ExprPrime
        new Production(
            NonTerminal.ExprPrime,
            Symbol.T(TokenType.Minus),
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 68
        // ExprPrime -> ε
        new Production(
            NonTerminal.ExprPrime,
            Symbol.Epsilon()
        ),

        // 69
        // Term -> Factor TermPrime
        new Production(
            NonTerminal.Term,
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 70
        // TermPrime -> '*' Factor TermPrime
        new Production(
            NonTerminal.TermPrime,
            Symbol.T(TokenType.Mul),
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 71
        // TermPrime -> '/' Factor TermPrime
        new Production(
            NonTerminal.TermPrime,
            Symbol.T(TokenType.Div),
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 72
        // TermPrime -> ε
        new Production(
            NonTerminal.TermPrime,
            Symbol.Epsilon()
        ),

        // 73
        // Factor -> INT_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.IntLiteral)
        ),

        // 74
        // Factor -> BOOL_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.BoolLiteral)
        ),

        // 75
        // Factor -> FLOAT_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.FloatLiteral)
        ),

        // 76
        // Factor -> CHAR_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.CharLiteral)
        ),

        // 77
        // Factor -> STRING_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.StringLiteral)
        ),

                // 78
        // Factor -> Identifier FactorArray
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.FactorArray)
        ),

        // 79
        // FactorArray -> '(' CallArgs ')'  (função call)
        new Production(
            NonTerminal.FactorArray,
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.CallArgs),
            Symbol.T(TokenType.RParen)
        ),

        // 80
        // FactorArray -> '[' Expr ']'  (array access)
        new Production(
            NonTerminal.FactorArray,
            Symbol.T(TokenType.LBracket),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RBracket)
        ),

        // 81
        // FactorArray -> ε  (just variable)
        new Production(
            NonTerminal.FactorArray,
            Symbol.Epsilon()
        ),

        // 82
        // Factor -> '(' Expr ')'
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen)
        ),

        // 83
        // Factor -> NOT Factor
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.Not),
            Symbol.N(NonTerminal.Factor)
        ),

        // 84
        // CallArgs -> Expr CallArgsPrime
        new Production(
            NonTerminal.CallArgs,
            Symbol.N(NonTerminal.Expr),
            Symbol.N(NonTerminal.CallArgsPrime)
        ),

        // 85
        // CallArgs -> ε
        new Production(
            NonTerminal.CallArgs,
            Symbol.Epsilon()
        ),

        // 86
        // CallArgsPrime -> ',' Expr CallArgsPrime
        new Production(
            NonTerminal.CallArgsPrime,
            Symbol.T(TokenType.Comma),
            Symbol.N(NonTerminal.Expr),
            Symbol.N(NonTerminal.CallArgsPrime)
        ),

        // 87
        // CallArgsPrime -> ε
        new Production(
            NonTerminal.CallArgsPrime,
            Symbol.Epsilon()
        ),

        // 88
        // AssignStmt -> Identifier AssignPart
        new Production(
            NonTerminal.AssignStmt,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.AssignPart)
        ),

        // 89
        // AssignPart -> '[' Expr ']' Assign Expr
        new Production(
            NonTerminal.AssignPart,
            Symbol.T(TokenType.LBracket),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RBracket),
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Expr)
        ),

        // 90
        // AssignPart -> Assign Expr
        new Production(
            NonTerminal.AssignPart,
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Expr)
        ),

        // 91
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

        // 92
        // ElsePart -> ELSE '(' StatementList ')'
        new Production(
            NonTerminal.ElsePart,
            Symbol.T(TokenType.Else),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen)
        ),

        // 93
        // ElsePart -> ε
        new Production(
            NonTerminal.ElsePart,
            Symbol.Epsilon()
        )
    };
}

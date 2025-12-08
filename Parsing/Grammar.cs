using EscrappyCompiler.Lexing;

namespace EscrappyCompiler.Parsing;

public static class Grammar
{
    public static readonly NonTerminal StartSymbol = NonTerminal.Program;

    public static readonly IReadOnlyList<Production> Productions = new[]
    {
        // 0
        // Program -> StatementList EOF
        new Production(
            NonTerminal.Program,
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.EndOfFile)
        ),

        // 1
        // StatementList -> Statement StatementList
        new Production(
            NonTerminal.StatementList,
            Symbol.N(NonTerminal.Statement),
            Symbol.N(NonTerminal.StatementList)
        ),

        // 2
        // StatementList -> ε
        new Production(
            NonTerminal.StatementList,
            Symbol.Epsilon()
        ),

        // 3
        // Statement -> VarDecl ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.VarDecl),
            Symbol.T(TokenType.Semicolon)
        ),

        // 4
        // Statement -> IfStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.IfStmt)
        ),

        // 5
        // Statement -> WhileStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.WhileStmt)
        ),

        // 6
        // Statement -> DoStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.DoStmt)
        ),

        // 7
        // Statement -> ForStmt
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.ForStmt)
        ),

        // 8
        // Statement -> PrintStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.PrintStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 9
        // Statement -> Identifier StatementTail
        new Production(
            NonTerminal.Statement,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.StatementTail)
        ),

        // 10
        // Statement -> Expr ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.Semicolon)
        ),

        // 11
        // Statement -> FetchStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.FetchStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 12
        // Statement -> SelectStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.SelectStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 13
        // Statement -> UpdateStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.UpdateStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 14
        // Statement -> SaveStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.SaveStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 15
        // Statement -> FuncDecl
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.FuncDecl)
        ),

        // 16
        // Statement -> ReturnStmt ';'
        new Production(
            NonTerminal.Statement,
            Symbol.N(NonTerminal.ReturnStmt),
            Symbol.T(TokenType.Semicolon)
        ),

        // 17
        // StatementTail -> '(' CallArgs ')' ';'   (call statement: hello();)
        new Production(
            NonTerminal.StatementTail,
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.CallArgs),
            Symbol.T(TokenType.RParen),
            Symbol.T(TokenType.Semicolon)
        ),

        // 18
        // StatementTail -> AssignPart ';'         (assign: x = Expr; ou x[Expr] = Expr;)
        new Production(
            NonTerminal.StatementTail,
            Symbol.N(NonTerminal.AssignPart),
            Symbol.T(TokenType.Semicolon)
        ),

        // 19
        // VarDecl -> Type Identifier VarDeclPart
        new Production(
            NonTerminal.VarDecl,
            Symbol.N(NonTerminal.Type),
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.VarDeclPart)
        ),

        // 20
        // VarDeclPart -> ArrayDim
        new Production(
            NonTerminal.VarDeclPart,
            Symbol.N(NonTerminal.ArrayDim)
        ),

        // 21
        // ArrayDim -> '[' IntLiteral ']'
        new Production(
            NonTerminal.ArrayDim,
            Symbol.T(TokenType.LBracket),
            Symbol.T(TokenType.IntLiteral),
            Symbol.T(TokenType.RBracket)
        ),

        // 22
        // ArrayDim -> ε
        new Production(
            NonTerminal.ArrayDim,
            Symbol.Epsilon()
        ),

        // 23
        // Type -> INT
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.IntType)
        ),

        // 24
        // Type -> BOOL
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.BoolType)
        ),

        // 25
        // Type -> FLOAT
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.FloatType)
        ),

        // 26
        // Type -> CHAR
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.CharType)
        ),

        // 27
        // Type -> STRING
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.StringType)
        ),

        // 28
        // Type -> BIT
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.BitType)
        ),

        // 29
        // Type -> VOID
        new Production(
            NonTerminal.Type,
            Symbol.T(TokenType.VoidType)
        ),

        // 30
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

        // 31
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

        // 32
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

        // 33
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

        // 34
        // PrintStmt -> PRINT Expr
        new Production(
            NonTerminal.PrintStmt,
            Symbol.T(TokenType.Print),
            Symbol.N(NonTerminal.Expr)
        ),

        // 35
        // FetchStmt -> FETCH Identifier FROM Identifier
        new Production(
            NonTerminal.FetchStmt,
            Symbol.T(TokenType.Fetch),
            Symbol.T(TokenType.Identifier),
            Symbol.T(TokenType.From),
            Symbol.T(TokenType.Identifier)
        ),

        // 36
        // SelectStmt -> SELECT ColumnList FROM Identifier Conditions
        new Production(
            NonTerminal.SelectStmt,
            Symbol.T(TokenType.Select),
            Symbol.N(NonTerminal.ColumnList),
            Symbol.T(TokenType.From),
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.Conditions)
        ),

        // 37
        // ColumnList -> '*'
        new Production(
            NonTerminal.ColumnList,
            Symbol.T(TokenType.Mul)
        ),

        // 38
        // ColumnList -> Identifier ColumnListPrime
        new Production(
            NonTerminal.ColumnList,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.ColumnListPrime)
        ),

        // 39
        // ColumnListPrime -> ',' ColumnList
        new Production(
            NonTerminal.ColumnListPrime,
            Symbol.T(TokenType.Comma),
            Symbol.N(NonTerminal.ColumnList)
        ),

        // 40
        // ColumnListPrime -> ε
        new Production(
            NonTerminal.ColumnListPrime,
            Symbol.Epsilon()
        ),

        // 41
        // Conditions -> WHERE Expr
        new Production(
            NonTerminal.Conditions,
            Symbol.T(TokenType.Where),
            Symbol.N(NonTerminal.Expr)
        ),

        // 42
        // Conditions -> ε
        new Production(
            NonTerminal.Conditions,
            Symbol.Epsilon()
        ),

        // 43
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

        // 44
        // SaveStmt -> SAVE Identifier
        new Production(
            NonTerminal.SaveStmt,
            Symbol.T(TokenType.Save),
            Symbol.T(TokenType.Identifier)
        ),

        // 45
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

        // 46
        // ParamList -> Param ParamListPrime
        new Production(
            NonTerminal.ParamList,
            Symbol.N(NonTerminal.Param),
            Symbol.N(NonTerminal.ParamListPrime)
        ),

        // 47
        // ParamList -> ε
        new Production(
            NonTerminal.ParamList,
            Symbol.Epsilon()
        ),

        // 48
        // Param -> Type Identifier
        new Production(
            NonTerminal.Param,
            Symbol.N(NonTerminal.Type),
            Symbol.T(TokenType.Identifier)
        ),

        // 49
        // ParamListPrime -> ',' Param ParamListPrime
        new Production(
            NonTerminal.ParamListPrime,
            Symbol.T(TokenType.Comma),
            Symbol.N(NonTerminal.Param),
            Symbol.N(NonTerminal.ParamListPrime)
        ),

        // 50
        // ParamListPrime -> ε
        new Production(
            NonTerminal.ParamListPrime,
            Symbol.Epsilon()
        ),

        // 51
        // ReturnStmt -> RETURN Expr
        new Production(
            NonTerminal.ReturnStmt,
            Symbol.T(TokenType.Return),
            Symbol.N(NonTerminal.Expr)
        ),

        // 52
        // ReturnStmt -> RETURN
        new Production(
            NonTerminal.ReturnStmt,
            Symbol.T(TokenType.Return)
        ),

        // EXPRESSÕES LÓGICAS E COMPARAÇÃO

        // 53
        // Expr -> LogicTerm LogicExprPrime
        new Production(
            NonTerminal.Expr,
            Symbol.N(NonTerminal.LogicTerm),
            Symbol.N(NonTerminal.LogicExprPrime)
        ),

        // 54
        // LogicExprPrime -> OR LogicTerm LogicExprPrime
        new Production(
            NonTerminal.LogicExprPrime,
            Symbol.T(TokenType.Or),
            Symbol.N(NonTerminal.LogicTerm),
            Symbol.N(NonTerminal.LogicExprPrime)
        ),

        // 55
        // LogicExprPrime -> ε
        new Production(
            NonTerminal.LogicExprPrime,
            Symbol.Epsilon()
        ),

        // 56
        // LogicTerm -> RelExpr LogicTermPrime
        new Production(
            NonTerminal.LogicTerm,
            Symbol.N(NonTerminal.RelExpr),
            Symbol.N(NonTerminal.LogicTermPrime)
        ),

        // 57
        // LogicTermPrime -> AND RelExpr LogicTermPrime
        new Production(
            NonTerminal.LogicTermPrime,
            Symbol.T(TokenType.And),
            Symbol.N(NonTerminal.RelExpr),
            Symbol.N(NonTerminal.LogicTermPrime)
        ),

        // 58
        // LogicTermPrime -> ε
        new Production(
            NonTerminal.LogicTermPrime,
            Symbol.Epsilon()
        ),

        // 59
        // RelExpr -> AddExpr RelPrime
        new Production(
            NonTerminal.RelExpr,
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 60
        // RelPrime -> '<' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.Less),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 61
        // RelPrime -> '<=' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.LessEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 62
        // RelPrime -> '>' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.Greater),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 63
        // RelPrime -> '>=' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.GreaterEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 64
        // RelPrime -> '==' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.EqualEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 65
        // RelPrime -> '<>' AddExpr RelPrime
        new Production(
            NonTerminal.RelPrime,
            Symbol.T(TokenType.NotEqual),
            Symbol.N(NonTerminal.AddExpr),
            Symbol.N(NonTerminal.RelPrime)
        ),

        // 66
        // RelPrime -> ε
        new Production(
            NonTerminal.RelPrime,
            Symbol.Epsilon()
        ),

        // 67
        // AddExpr -> Term ExprPrime
        new Production(
            NonTerminal.AddExpr,
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 68
        // ExprPrime -> '+' Term ExprPrime
        new Production(
            NonTerminal.ExprPrime,
            Symbol.T(TokenType.Plus),
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 69
        // ExprPrime -> '-' Term ExprPrime
        new Production(
            NonTerminal.ExprPrime,
            Symbol.T(TokenType.Minus),
            Symbol.N(NonTerminal.Term),
            Symbol.N(NonTerminal.ExprPrime)
        ),

        // 70
        // ExprPrime -> ε
        new Production(
            NonTerminal.ExprPrime,
            Symbol.Epsilon()
        ),

        // 71
        // Term -> Factor TermPrime
        new Production(
            NonTerminal.Term,
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 72
        // TermPrime -> '*' Factor TermPrime
        new Production(
            NonTerminal.TermPrime,
            Symbol.T(TokenType.Mul),
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 73
        // TermPrime -> '/' Factor TermPrime
        new Production(
            NonTerminal.TermPrime,
            Symbol.T(TokenType.Div),
            Symbol.N(NonTerminal.Factor),
            Symbol.N(NonTerminal.TermPrime)
        ),

        // 74
        // TermPrime -> ε
        new Production(
            NonTerminal.TermPrime,
            Symbol.Epsilon()
        ),

        // 75
        // Factor -> INT_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.IntLiteral)
        ),

        // 76
        // Factor -> BOOL_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.BoolLiteral)
        ),

        // 77
        // Factor -> FLOAT_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.FloatLiteral)
        ),

        // 78
        // Factor -> CHAR_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.CharLiteral)
        ),

        // 79
        // Factor -> STRING_LITERAL
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.StringLiteral)
        ),

        // 80
        // Factor -> Identifier FactorArray
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.FactorArray)
        ),

        // 81
        // FactorArray -> '(' CallArgs ')'  (função call)
        new Production(
            NonTerminal.FactorArray,
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.CallArgs),
            Symbol.T(TokenType.RParen)
        ),

        // 82
        // FactorArray -> '[' Expr ']'  (array access)
        new Production(
            NonTerminal.FactorArray,
            Symbol.T(TokenType.LBracket),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RBracket)
        ),

        // 83
        // FactorArray -> ε  (just variable)
        new Production(
            NonTerminal.FactorArray,
            Symbol.Epsilon()
        ),

        // 84
        // Factor -> '(' Expr ')'
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RParen)
        ),

        // 85
        // Factor -> NOT Factor
        new Production(
            NonTerminal.Factor,
            Symbol.T(TokenType.Not),
            Symbol.N(NonTerminal.Factor)
        ),

        // 86
        // CallArgs -> Expr CallArgsPrime
        new Production(
            NonTerminal.CallArgs,
            Symbol.N(NonTerminal.Expr),
            Symbol.N(NonTerminal.CallArgsPrime)
        ),

        // 87
        // CallArgs -> ε
        new Production(
            NonTerminal.CallArgs,
            Symbol.Epsilon()
        ),

        // 88
        // CallArgsPrime -> ',' Expr CallArgsPrime
        new Production(
            NonTerminal.CallArgsPrime,
            Symbol.T(TokenType.Comma),
            Symbol.N(NonTerminal.Expr),
            Symbol.N(NonTerminal.CallArgsPrime)
        ),

        // 89
        // CallArgsPrime -> ε
        new Production(
            NonTerminal.CallArgsPrime,
            Symbol.Epsilon()
        ),

        // 90
        // AssignStmt -> Identifier AssignPart
        new Production(
            NonTerminal.AssignStmt,
            Symbol.T(TokenType.Identifier),
            Symbol.N(NonTerminal.AssignPart)
        ),

        // 91
        // AssignPart -> '[' Expr ']' Assign Expr
        new Production(
            NonTerminal.AssignPart,
            Symbol.T(TokenType.LBracket),
            Symbol.N(NonTerminal.Expr),
            Symbol.T(TokenType.RBracket),
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Expr)
        ),

        // 92
        // AssignPart -> Assign Expr
        new Production(
            NonTerminal.AssignPart,
            Symbol.T(TokenType.Assign),
            Symbol.N(NonTerminal.Expr)
        ),

        // 93
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

        // 94
        // ElsePart -> ELSE '(' StatementList ')'
        new Production(
            NonTerminal.ElsePart,
            Symbol.T(TokenType.Else),
            Symbol.T(TokenType.LParen),
            Symbol.N(NonTerminal.StatementList),
            Symbol.T(TokenType.RParen)
        ),

        // 95
        // ElsePart -> ε
        new Production(
            NonTerminal.ElsePart,
            Symbol.Epsilon()
        )
    };
}

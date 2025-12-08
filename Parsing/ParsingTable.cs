using EscrappyCompiler.Lexing;

namespace EscrappyCompiler.Parsing;

public sealed class ParsingTable
{
    private readonly Dictionary<(NonTerminal, TokenType), int> _table = new();

    public ParsingTable()
    {
        Build();
    }

    private void Build()
    {
        // Program -> StatementList EOF (0)
        _table[(NonTerminal.Program, TokenType.IntType)] = 0;
        _table[(NonTerminal.Program, TokenType.BoolType)] = 0;
        _table[(NonTerminal.Program, TokenType.FloatType)] = 0;
        _table[(NonTerminal.Program, TokenType.CharType)] = 0;
        _table[(NonTerminal.Program, TokenType.StringType)] = 0;
        _table[(NonTerminal.Program, TokenType.BitType)] = 0;
        _table[(NonTerminal.Program, TokenType.VoidType)] = 0;
        _table[(NonTerminal.Program, TokenType.If)] = 0;
        _table[(NonTerminal.Program, TokenType.While)] = 0;
        _table[(NonTerminal.Program, TokenType.Do)] = 0;
        _table[(NonTerminal.Program, TokenType.For)] = 0;
        _table[(NonTerminal.Program, TokenType.Print)] = 0;
        _table[(NonTerminal.Program, TokenType.Fetch)] = 0;
        _table[(NonTerminal.Program, TokenType.Select)] = 0;
        _table[(NonTerminal.Program, TokenType.Update)] = 0;
        _table[(NonTerminal.Program, TokenType.Save)] = 0;
        _table[(NonTerminal.Program, TokenType.Func)] = 0;
        _table[(NonTerminal.Program, TokenType.Identifier)] = 0;
        _table[(NonTerminal.Program, TokenType.Return)] = 0;
        _table[(NonTerminal.Program, TokenType.EndOfFile)] = 0;

        // StatementList -> Statement StatementList (1) | ε (2)
        _table[(NonTerminal.StatementList, TokenType.IntType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.BoolType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.FloatType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.CharType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.StringType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.BitType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.VoidType)] = 1;
        _table[(NonTerminal.StatementList, TokenType.If)] = 1;
        _table[(NonTerminal.StatementList, TokenType.While)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Do)] = 1;
        _table[(NonTerminal.StatementList, TokenType.For)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Print)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Fetch)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Select)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Update)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Save)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Func)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Identifier)] = 1;
        _table[(NonTerminal.StatementList, TokenType.Return)] = 1;
        _table[(NonTerminal.StatementList, TokenType.EndOfFile)] = 2;
        _table[(NonTerminal.StatementList, TokenType.RParen)] = 2;

        // Statement -> VarDecl ';' (3) | IfStmt (4) | WhileStmt (5) | DoStmt (6) | ForStmt (7)
        //           | PrintStmt ';' (8) | Identifier StatementTail (9) | Expr ';' (10)
        //           | FetchStmt ';' (11) | SelectStmt ';' (12) | UpdateStmt ';' (13)
        //           | SaveStmt ';' (14) | FuncDecl (15) | ReturnStmt ';' (16)
        _table[(NonTerminal.Statement, TokenType.IntType)] = 3;
        _table[(NonTerminal.Statement, TokenType.BoolType)] = 3;
        _table[(NonTerminal.Statement, TokenType.FloatType)] = 3;
        _table[(NonTerminal.Statement, TokenType.CharType)] = 3;
        _table[(NonTerminal.Statement, TokenType.StringType)] = 3;
        _table[(NonTerminal.Statement, TokenType.BitType)] = 3;
        _table[(NonTerminal.Statement, TokenType.VoidType)] = 3;
        _table[(NonTerminal.Statement, TokenType.If)] = 4;
        _table[(NonTerminal.Statement, TokenType.While)] = 5;
        _table[(NonTerminal.Statement, TokenType.Do)] = 6;
        _table[(NonTerminal.Statement, TokenType.For)] = 7;
        _table[(NonTerminal.Statement, TokenType.Print)] = 8;
        _table[(NonTerminal.Statement, TokenType.Identifier)] = 9;
        _table[(NonTerminal.Statement, TokenType.IntLiteral)] = 10;
        _table[(NonTerminal.Statement, TokenType.BoolLiteral)] = 10;
        _table[(NonTerminal.Statement, TokenType.FloatLiteral)] = 10;
        _table[(NonTerminal.Statement, TokenType.CharLiteral)] = 10;
        _table[(NonTerminal.Statement, TokenType.StringLiteral)] = 10;
        _table[(NonTerminal.Statement, TokenType.LParen)] = 10;
        _table[(NonTerminal.Statement, TokenType.Not)] = 10;
        _table[(NonTerminal.Statement, TokenType.Fetch)] = 11;
        _table[(NonTerminal.Statement, TokenType.Select)] = 12;
        _table[(NonTerminal.Statement, TokenType.Update)] = 13;
        _table[(NonTerminal.Statement, TokenType.Save)] = 14;
        _table[(NonTerminal.Statement, TokenType.Func)] = 15;
        _table[(NonTerminal.Statement, TokenType.Return)] = 16;

        // StatementTail -> '(' CallArgs ')' ';' (17) | AssignPart ';' (18)
        _table[(NonTerminal.StatementTail, TokenType.LParen)] = 17;
        _table[(NonTerminal.StatementTail, TokenType.LBracket)] = 18;
        _table[(NonTerminal.StatementTail, TokenType.Assign)] = 18;

        // VarDecl -> Type Identifier VarDeclPart (19)
        _table[(NonTerminal.VarDecl, TokenType.IntType)] = 19;
        _table[(NonTerminal.VarDecl, TokenType.BoolType)] = 19;
        _table[(NonTerminal.VarDecl, TokenType.FloatType)] = 19;
        _table[(NonTerminal.VarDecl, TokenType.CharType)] = 19;
        _table[(NonTerminal.VarDecl, TokenType.StringType)] = 19;
        _table[(NonTerminal.VarDecl, TokenType.BitType)] = 19;
        _table[(NonTerminal.VarDecl, TokenType.VoidType)] = 19;

        // VarDeclPart -> ArrayDim (20)
        _table[(NonTerminal.VarDeclPart, TokenType.LBracket)] = 20;
        _table[(NonTerminal.VarDeclPart, TokenType.Semicolon)] = 20;

        // ArrayDim -> '[' IntLiteral ']' (21) | ε (22)
        _table[(NonTerminal.ArrayDim, TokenType.LBracket)] = 21;
        _table[(NonTerminal.ArrayDim, TokenType.Semicolon)] = 22;

        // Type -> INT (23) | BOOL (24) | FLOAT (25) | CHAR (26) | STRING (27) | BIT (28) | VOID (29)
        _table[(NonTerminal.Type, TokenType.IntType)] = 23;
        _table[(NonTerminal.Type, TokenType.BoolType)] = 24;
        _table[(NonTerminal.Type, TokenType.FloatType)] = 25;
        _table[(NonTerminal.Type, TokenType.CharType)] = 26;
        _table[(NonTerminal.Type, TokenType.StringType)] = 27;
        _table[(NonTerminal.Type, TokenType.BitType)] = 28;
        _table[(NonTerminal.Type, TokenType.VoidType)] = 29;

        // IfStmt -> IF '(' Expr ')' '(' StatementList ')' ElsePart (30)
        _table[(NonTerminal.IfStmt, TokenType.If)] = 30;

        // WhileStmt -> WHILE '(' Expr ')' '(' StatementList ')' (31)
        _table[(NonTerminal.WhileStmt, TokenType.While)] = 31;

        // DoStmt -> DO '(' StatementList ')' WHILE '(' Expr ')' ';' (32)
        _table[(NonTerminal.DoStmt, TokenType.Do)] = 32;

        // ForStmt -> FOR '(' AssignStmt ';' Expr ';' AssignStmt ')' '(' StatementList ')' (33)
        _table[(NonTerminal.ForStmt, TokenType.For)] = 33;

        // PrintStmt -> PRINT Expr (34)
        _table[(NonTerminal.PrintStmt, TokenType.Print)] = 34;

        // FetchStmt -> FETCH Identifier FROM Identifier (35)
        _table[(NonTerminal.FetchStmt, TokenType.Fetch)] = 35;

        // SelectStmt -> SELECT ColumnList FROM Identifier Conditions (36)
        _table[(NonTerminal.SelectStmt, TokenType.Select)] = 36;

        // ColumnList -> '*' (37) | Identifier ColumnListPrime (38)
        _table[(NonTerminal.ColumnList, TokenType.Mul)] = 37;
        _table[(NonTerminal.ColumnList, TokenType.Identifier)] = 38;

        // ColumnListPrime -> ',' ColumnList (39) | ε (40)
        _table[(NonTerminal.ColumnListPrime, TokenType.Comma)] = 39;
        _table[(NonTerminal.ColumnListPrime, TokenType.From)] = 40;
        _table[(NonTerminal.ColumnListPrime, TokenType.Where)] = 40;

        // Conditions -> WHERE Expr (41) | ε (42)
        _table[(NonTerminal.Conditions, TokenType.Where)] = 41;
        _table[(NonTerminal.Conditions, TokenType.Semicolon)] = 42;
        _table[(NonTerminal.Conditions, TokenType.RParen)] = 42;

        // UpdateStmt -> UPDATE Identifier SET Identifier Assign Expr (43)
        _table[(NonTerminal.UpdateStmt, TokenType.Update)] = 43;

        // SaveStmt -> SAVE Identifier (44)
        _table[(NonTerminal.SaveStmt, TokenType.Save)] = 44;

        // FuncDecl -> FUNC Identifier '(' ParamList ')' Assign Type '(' StatementList ')' (45)
        _table[(NonTerminal.FuncDecl, TokenType.Func)] = 45;

        // ParamList -> Param ParamListPrime (46) | ε (47)
        _table[(NonTerminal.ParamList, TokenType.IntType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.BoolType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.FloatType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.CharType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.StringType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.BitType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.VoidType)] = 46;
        _table[(NonTerminal.ParamList, TokenType.RParen)] = 47;

        // Param -> Type Identifier (48)
        _table[(NonTerminal.Param, TokenType.IntType)] = 48;
        _table[(NonTerminal.Param, TokenType.BoolType)] = 48;
        _table[(NonTerminal.Param, TokenType.FloatType)] = 48;
        _table[(NonTerminal.Param, TokenType.CharType)] = 48;
        _table[(NonTerminal.Param, TokenType.StringType)] = 48;
        _table[(NonTerminal.Param, TokenType.BitType)] = 48;
        _table[(NonTerminal.Param, TokenType.VoidType)] = 48;

        // ParamListPrime -> ',' Param ParamListPrime (49) | ε (50)
        _table[(NonTerminal.ParamListPrime, TokenType.Comma)] = 49;
        _table[(NonTerminal.ParamListPrime, TokenType.RParen)] = 50;

        // ReturnStmt -> RETURN Expr (51) | RETURN (52)
        _table[(NonTerminal.ReturnStmt, TokenType.Return)] = 51;

        // EXPRESSÕES

        // Expr -> LogicTerm LogicExprPrime (53)
        _table[(NonTerminal.Expr, TokenType.IntLiteral)] = 53;
        _table[(NonTerminal.Expr, TokenType.BoolLiteral)] = 53;
        _table[(NonTerminal.Expr, TokenType.FloatLiteral)] = 53;
        _table[(NonTerminal.Expr, TokenType.CharLiteral)] = 53;
        _table[(NonTerminal.Expr, TokenType.StringLiteral)] = 53;
        _table[(NonTerminal.Expr, TokenType.Identifier)] = 53;
        _table[(NonTerminal.Expr, TokenType.LParen)] = 53;
        _table[(NonTerminal.Expr, TokenType.Not)] = 53;

        // LogicExprPrime -> OR LogicTerm LogicExprPrime (54) | ε (55)
        _table[(NonTerminal.LogicExprPrime, TokenType.Or)] = 54;
        _table[(NonTerminal.LogicExprPrime, TokenType.Semicolon)] = 55;
        _table[(NonTerminal.LogicExprPrime, TokenType.RParen)] = 55;
        _table[(NonTerminal.LogicExprPrime, TokenType.RBracket)] = 55;
        _table[(NonTerminal.LogicExprPrime, TokenType.Comma)] = 55;

        // LogicTerm -> RelExpr LogicTermPrime (56)
        _table[(NonTerminal.LogicTerm, TokenType.IntLiteral)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.BoolLiteral)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.FloatLiteral)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.CharLiteral)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.StringLiteral)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.Identifier)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.LParen)] = 56;
        _table[(NonTerminal.LogicTerm, TokenType.Not)] = 56;

        // LogicTermPrime -> AND RelExpr LogicTermPrime (57) | ε (58)
        _table[(NonTerminal.LogicTermPrime, TokenType.And)] = 57;
        _table[(NonTerminal.LogicTermPrime, TokenType.Or)] = 58;
        _table[(NonTerminal.LogicTermPrime, TokenType.Semicolon)] = 58;
        _table[(NonTerminal.LogicTermPrime, TokenType.RParen)] = 58;
        _table[(NonTerminal.LogicTermPrime, TokenType.RBracket)] = 58;
        _table[(NonTerminal.LogicTermPrime, TokenType.Comma)] = 58;

        // RelExpr -> AddExpr RelPrime (59)
        _table[(NonTerminal.RelExpr, TokenType.IntLiteral)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.BoolLiteral)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.FloatLiteral)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.CharLiteral)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.StringLiteral)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.Identifier)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.LParen)] = 59;
        _table[(NonTerminal.RelExpr, TokenType.Not)] = 59;

        // RelPrime -> '<' AddExpr RelPrime (60) | '<=' (61) | '>' (62) | '>=' (63) | '==' (64) | '<>' (65) | ε (66)
        _table[(NonTerminal.RelPrime, TokenType.Less)] = 60;
        _table[(NonTerminal.RelPrime, TokenType.LessEqual)] = 61;
        _table[(NonTerminal.RelPrime, TokenType.Greater)] = 62;
        _table[(NonTerminal.RelPrime, TokenType.GreaterEqual)] = 63;
        _table[(NonTerminal.RelPrime, TokenType.EqualEqual)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.NotEqual)] = 65;
        _table[(NonTerminal.RelPrime, TokenType.And)] = 66;
        _table[(NonTerminal.RelPrime, TokenType.Or)] = 66;
        _table[(NonTerminal.RelPrime, TokenType.Semicolon)] = 66;
        _table[(NonTerminal.RelPrime, TokenType.RParen)] = 66;
        _table[(NonTerminal.RelPrime, TokenType.RBracket)] = 66;
        _table[(NonTerminal.RelPrime, TokenType.Comma)] = 66;

        // AddExpr -> Term ExprPrime (67)
        _table[(NonTerminal.AddExpr, TokenType.IntLiteral)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.BoolLiteral)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.FloatLiteral)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.CharLiteral)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.StringLiteral)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.Identifier)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.LParen)] = 67;
        _table[(NonTerminal.AddExpr, TokenType.Not)] = 67;

        // ExprPrime -> '+' Term ExprPrime (68) | '-' Term ExprPrime (69) | ε (70)
        _table[(NonTerminal.ExprPrime, TokenType.Plus)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.Minus)] = 69;
        _table[(NonTerminal.ExprPrime, TokenType.Less)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.LessEqual)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.Greater)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.GreaterEqual)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.EqualEqual)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.NotEqual)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.And)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.Or)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.Semicolon)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.RParen)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.RBracket)] = 70;
        _table[(NonTerminal.ExprPrime, TokenType.Comma)] = 70;

        // Term -> Factor TermPrime (71)
        _table[(NonTerminal.Term, TokenType.IntLiteral)] = 71;
        _table[(NonTerminal.Term, TokenType.BoolLiteral)] = 71;
        _table[(NonTerminal.Term, TokenType.FloatLiteral)] = 71;
        _table[(NonTerminal.Term, TokenType.CharLiteral)] = 71;
        _table[(NonTerminal.Term, TokenType.StringLiteral)] = 71;
        _table[(NonTerminal.Term, TokenType.Identifier)] = 71;
        _table[(NonTerminal.Term, TokenType.LParen)] = 71;
        _table[(NonTerminal.Term, TokenType.Not)] = 71;

        // TermPrime -> '*' Factor TermPrime (72) | '/' Factor TermPrime (73) | ε (74)
        _table[(NonTerminal.TermPrime, TokenType.Mul)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Div)] = 73;
        _table[(NonTerminal.TermPrime, TokenType.Plus)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.Minus)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.Less)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.LessEqual)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.Greater)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.GreaterEqual)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.EqualEqual)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.NotEqual)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.And)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.Or)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.Semicolon)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.RParen)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.RBracket)] = 74;
        _table[(NonTerminal.TermPrime, TokenType.Comma)] = 74;

        // Factor -> INT_LITERAL (75) | BOOL_LITERAL (76) | FLOAT_LITERAL (77) | CHAR_LITERAL (78) | STRING_LITERAL (79)
        //        | Identifier FactorArray (80) | '(' Expr ')' (84) | NOT Factor (85)
        _table[(NonTerminal.Factor, TokenType.IntLiteral)] = 75;
        _table[(NonTerminal.Factor, TokenType.BoolLiteral)] = 76;
        _table[(NonTerminal.Factor, TokenType.FloatLiteral)] = 77;
        _table[(NonTerminal.Factor, TokenType.CharLiteral)] = 78;
        _table[(NonTerminal.Factor, TokenType.StringLiteral)] = 79;
        _table[(NonTerminal.Factor, TokenType.Identifier)] = 80;
        _table[(NonTerminal.Factor, TokenType.LParen)] = 84;
        _table[(NonTerminal.Factor, TokenType.Not)] = 85;

        // FactorArray -> '(' CallArgs ')' (81) | '[' Expr ']' (82) | ε (83)
        _table[(NonTerminal.FactorArray, TokenType.LParen)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.LBracket)] = 82;
        _table[(NonTerminal.FactorArray, TokenType.Plus)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Minus)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Mul)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Div)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Less)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.LessEqual)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Greater)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.GreaterEqual)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.EqualEqual)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.NotEqual)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.And)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Or)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Semicolon)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.RParen)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.RBracket)] = 83;
        _table[(NonTerminal.FactorArray, TokenType.Comma)] = 83;

        // CallArgs -> Expr CallArgsPrime (86) | ε (87)
        _table[(NonTerminal.CallArgs, TokenType.IntLiteral)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.BoolLiteral)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.FloatLiteral)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.CharLiteral)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.StringLiteral)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.Identifier)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.LParen)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.Not)] = 86;
        _table[(NonTerminal.CallArgs, TokenType.RParen)] = 87;

        // CallArgsPrime -> ',' Expr CallArgsPrime (88) | ε (89)
        _table[(NonTerminal.CallArgsPrime, TokenType.Comma)] = 88;
        _table[(NonTerminal.CallArgsPrime, TokenType.RParen)] = 89;

        // AssignStmt -> Identifier AssignPart (90)
        _table[(NonTerminal.AssignStmt, TokenType.Identifier)] = 90;

        // AssignPart -> '[' Expr ']' Assign Expr (91) | Assign Expr (92)
        _table[(NonTerminal.AssignPart, TokenType.LBracket)] = 91;
        _table[(NonTerminal.AssignPart, TokenType.Assign)] = 92;

        // ElsePart -> ELSEIF '(' Expr ')' '(' StatementList ')' ElsePart (93) | ELSE '(' StatementList ')' (94) | ε (95)
        _table[(NonTerminal.ElsePart, TokenType.ElseIf)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Else)] = 94;
        _table[(NonTerminal.ElsePart, TokenType.IntType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.BoolType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.FloatType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.CharType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.StringType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.BitType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.VoidType)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.If)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.While)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Do)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.For)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Print)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Fetch)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Select)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Update)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Save)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Func)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Return)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.Identifier)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.EndOfFile)] = 95;
        _table[(NonTerminal.ElsePart, TokenType.RParen)] = 95;
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

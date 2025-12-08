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
        // Program -> StatementList EOF  (0)
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

        // Statement -> VarDecl ';' (3) | IfStmt (4) | ... | FuncDecl (15) | ReturnStmt (16)
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
        _table[(NonTerminal.Statement, TokenType.Fetch)] = 11;
        _table[(NonTerminal.Statement, TokenType.Select)] = 12;
        _table[(NonTerminal.Statement, TokenType.Update)] = 13;
        _table[(NonTerminal.Statement, TokenType.Save)] = 14;
        _table[(NonTerminal.Statement, TokenType.Func)] = 15;
        _table[(NonTerminal.Statement, TokenType.Return)] = 16;

        // VarDecl -> Type Identifier VarDeclPart (17)
        _table[(NonTerminal.VarDecl, TokenType.IntType)] = 17;
        _table[(NonTerminal.VarDecl, TokenType.BoolType)] = 17;
        _table[(NonTerminal.VarDecl, TokenType.FloatType)] = 17;
        _table[(NonTerminal.VarDecl, TokenType.CharType)] = 17;
        _table[(NonTerminal.VarDecl, TokenType.StringType)] = 17;
        _table[(NonTerminal.VarDecl, TokenType.BitType)] = 17;
        _table[(NonTerminal.VarDecl, TokenType.VoidType)] = 17;

        // VarDeclPart -> ArrayDim (18)
        _table[(NonTerminal.VarDeclPart, TokenType.LBracket)] = 19;
        _table[(NonTerminal.VarDeclPart, TokenType.Semicolon)] = 20;

        // ArrayDim -> '[' IntLiteral ']' (19) | ε (20)
        _table[(NonTerminal.ArrayDim, TokenType.LBracket)] = 19;
        _table[(NonTerminal.ArrayDim, TokenType.Semicolon)] = 20;

        // Type -> INT (21) | BOOL (22) | FLOAT (23) | CHAR (24) | STRING (25) | BIT (26) | VOID (27)
        _table[(NonTerminal.Type, TokenType.IntType)] = 21;
        _table[(NonTerminal.Type, TokenType.BoolType)] = 22;
        _table[(NonTerminal.Type, TokenType.FloatType)] = 23;
        _table[(NonTerminal.Type, TokenType.CharType)] = 24;
        _table[(NonTerminal.Type, TokenType.StringType)] = 25;
        _table[(NonTerminal.Type, TokenType.BitType)] = 26;
        _table[(NonTerminal.Type, TokenType.VoidType)] = 27;

        // IfStmt -> IF '(' Expr ')' '(' StatementList ')' ElsePart (28)
        _table[(NonTerminal.IfStmt, TokenType.If)] = 28;

        // WhileStmt -> WHILE '(' Expr ')' '(' StatementList ')' (29)
        _table[(NonTerminal.WhileStmt, TokenType.While)] = 29;

        // DoStmt -> DO '(' StatementList ')' WHILE '(' Expr ')' ';' (30)
        _table[(NonTerminal.DoStmt, TokenType.Do)] = 30;

        // ForStmt -> FOR '(' AssignStmt ';' Expr ';' AssignStmt ')' '(' StatementList ')' (31)
        _table[(NonTerminal.ForStmt, TokenType.For)] = 31;

        // PrintStmt -> PRINT Expr (32)
        _table[(NonTerminal.PrintStmt, TokenType.Print)] = 32;

        // FetchStmt -> FETCH Identifier FROM Identifier (33)
        _table[(NonTerminal.FetchStmt, TokenType.Fetch)] = 33;

        // SelectStmt -> SELECT ColumnList FROM Identifier Conditions (34)
        _table[(NonTerminal.SelectStmt, TokenType.Select)] = 34;

        // ColumnList -> '*' (35) | Identifier ColumnListPrime (36)
        _table[(NonTerminal.ColumnList, TokenType.Mul)] = 35;
        _table[(NonTerminal.ColumnList, TokenType.Identifier)] = 36;

        // ColumnListPrime -> ',' ColumnList (37) | ε (38)
        _table[(NonTerminal.ColumnListPrime, TokenType.Comma)] = 37;
        _table[(NonTerminal.ColumnListPrime, TokenType.From)] = 38;
        _table[(NonTerminal.ColumnListPrime, TokenType.Where)] = 38;

        // Conditions -> WHERE Expr (39) | ε (40)
        _table[(NonTerminal.Conditions, TokenType.Where)] = 39;
        _table[(NonTerminal.Conditions, TokenType.Semicolon)] = 40;
        _table[(NonTerminal.Conditions, TokenType.RParen)] = 40;

        // UpdateStmt -> UPDATE Identifier SET Identifier Assign Expr (41)
        _table[(NonTerminal.UpdateStmt, TokenType.Update)] = 41;

        // SaveStmt -> SAVE Identifier (42)
        _table[(NonTerminal.SaveStmt, TokenType.Save)] = 42;

        // FuncDecl -> FUNC Identifier '(' ParamList ')' Assign Type '(' StatementList ')' (43)
        _table[(NonTerminal.FuncDecl, TokenType.Func)] = 43;

        // ParamList -> Param ParamListPrime (44) | ε (45)
        _table[(NonTerminal.ParamList, TokenType.IntType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.BoolType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.FloatType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.CharType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.StringType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.BitType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.VoidType)] = 44;
        _table[(NonTerminal.ParamList, TokenType.RParen)] = 45;

        // Param -> Type Identifier (46)
        _table[(NonTerminal.Param, TokenType.IntType)] = 46;
        _table[(NonTerminal.Param, TokenType.BoolType)] = 46;
        _table[(NonTerminal.Param, TokenType.FloatType)] = 46;
        _table[(NonTerminal.Param, TokenType.CharType)] = 46;
        _table[(NonTerminal.Param, TokenType.StringType)] = 46;
        _table[(NonTerminal.Param, TokenType.BitType)] = 46;
        _table[(NonTerminal.Param, TokenType.VoidType)] = 46;

        // ParamListPrime -> ',' Param ParamListPrime (47) | ε (48)
        _table[(NonTerminal.ParamListPrime, TokenType.Comma)] = 47;
        _table[(NonTerminal.ParamListPrime, TokenType.RParen)] = 48;

        // ReturnStmt -> RETURN Expr (49) | RETURN (50)
        _table[(NonTerminal.ReturnStmt, TokenType.Return)] = 49; // será ajustado dinamicamente

        // EXPRESSÕES

        // Expr -> LogicTerm LogicExprPrime (51)
        _table[(NonTerminal.Expr, TokenType.IntLiteral)] = 51;
        _table[(NonTerminal.Expr, TokenType.BoolLiteral)] = 51;
        _table[(NonTerminal.Expr, TokenType.FloatLiteral)] = 51;
        _table[(NonTerminal.Expr, TokenType.CharLiteral)] = 51;
        _table[(NonTerminal.Expr, TokenType.StringLiteral)] = 51;
        _table[(NonTerminal.Expr, TokenType.Identifier)] = 51;
        _table[(NonTerminal.Expr, TokenType.LParen)] = 51;
        _table[(NonTerminal.Expr, TokenType.Not)] = 51;

        // LogicExprPrime -> OR LogicTerm LogicExprPrime (52) | ε (53)
        _table[(NonTerminal.LogicExprPrime, TokenType.Or)] = 52;
        _table[(NonTerminal.LogicExprPrime, TokenType.Semicolon)] = 53;
        _table[(NonTerminal.LogicExprPrime, TokenType.RParen)] = 53;
        _table[(NonTerminal.LogicExprPrime, TokenType.LParen)] = 53;
        _table[(NonTerminal.LogicExprPrime, TokenType.RBracket)] = 53;
        _table[(NonTerminal.LogicExprPrime, TokenType.Comma)] = 53;

        // LogicTerm -> RelExpr LogicTermPrime (54)
        _table[(NonTerminal.LogicTerm, TokenType.IntLiteral)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.BoolLiteral)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.FloatLiteral)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.CharLiteral)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.StringLiteral)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.Identifier)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.LParen)] = 54;
        _table[(NonTerminal.LogicTerm, TokenType.Not)] = 54;

        // LogicTermPrime -> AND RelExpr LogicTermPrime (55) | ε (56)
        _table[(NonTerminal.LogicTermPrime, TokenType.And)] = 55;
        _table[(NonTerminal.LogicTermPrime, TokenType.Or)] = 56;
        _table[(NonTerminal.LogicTermPrime, TokenType.Semicolon)] = 56;
        _table[(NonTerminal.LogicTermPrime, TokenType.RParen)] = 56;
        _table[(NonTerminal.LogicTermPrime, TokenType.LParen)] = 56;
        _table[(NonTerminal.LogicTermPrime, TokenType.RBracket)] = 56;
        _table[(NonTerminal.LogicTermPrime, TokenType.Comma)] = 56;

        // RelExpr -> AddExpr RelPrime (57)
        _table[(NonTerminal.RelExpr, TokenType.IntLiteral)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.BoolLiteral)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.FloatLiteral)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.CharLiteral)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.StringLiteral)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.Identifier)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.LParen)] = 57;
        _table[(NonTerminal.RelExpr, TokenType.Not)] = 57;
        // RelPrime -> '<' AddExpr RelPrime (58) | '<=' (59) | '>' (60) | '>=' (61) | '==' (62) | '<>' (63) | ε (64)
        _table[(NonTerminal.RelPrime, TokenType.Less)] = 58;
        _table[(NonTerminal.RelPrime, TokenType.LessEqual)] = 59;
        _table[(NonTerminal.RelPrime, TokenType.Greater)] = 60;
        _table[(NonTerminal.RelPrime, TokenType.GreaterEqual)] = 61;
        _table[(NonTerminal.RelPrime, TokenType.EqualEqual)] = 62;
        _table[(NonTerminal.RelPrime, TokenType.NotEqual)] = 63;

        _table[(NonTerminal.RelPrime, TokenType.And)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.Or)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.Semicolon)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.RParen)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.RBracket)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.Comma)] = 64;
        _table[(NonTerminal.RelPrime, TokenType.LParen)] = 64;

        // AddExpr -> Term ExprPrime (65)
        _table[(NonTerminal.AddExpr, TokenType.IntLiteral)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.BoolLiteral)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.FloatLiteral)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.CharLiteral)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.StringLiteral)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.Identifier)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.LParen)] = 65;
        _table[(NonTerminal.AddExpr, TokenType.Not)] = 65;

        // ExprPrime -> '+' Term ExprPrime (66) | '-' Term ExprPrime (67) | ε (68)
        _table[(NonTerminal.ExprPrime, TokenType.Plus)] = 66;
        _table[(NonTerminal.ExprPrime, TokenType.Minus)] = 67;

        _table[(NonTerminal.ExprPrime, TokenType.Less)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.LessEqual)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.Greater)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.GreaterEqual)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.EqualEqual)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.NotEqual)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.And)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.Or)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.Semicolon)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.RParen)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.RBracket)] = 68;
        _table[(NonTerminal.ExprPrime, TokenType.Comma)] = 68;

        // Term -> Factor TermPrime (69)
        _table[(NonTerminal.Term, TokenType.IntLiteral)] = 69;
        _table[(NonTerminal.Term, TokenType.BoolLiteral)] = 69;
        _table[(NonTerminal.Term, TokenType.FloatLiteral)] = 69;
        _table[(NonTerminal.Term, TokenType.CharLiteral)] = 69;
        _table[(NonTerminal.Term, TokenType.StringLiteral)] = 69;
        _table[(NonTerminal.Term, TokenType.Identifier)] = 69;
        _table[(NonTerminal.Term, TokenType.LParen)] = 69;
        _table[(NonTerminal.Term, TokenType.Not)] = 69;

        // TermPrime -> '*' Factor TermPrime (70) | '/' Factor TermPrime (71) | ε (72)
        _table[(NonTerminal.TermPrime, TokenType.Mul)] = 70;
        _table[(NonTerminal.TermPrime, TokenType.Div)] = 71;

        _table[(NonTerminal.TermPrime, TokenType.Plus)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Minus)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Less)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.LessEqual)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Greater)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.GreaterEqual)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.EqualEqual)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.NotEqual)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.And)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Or)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Semicolon)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.RParen)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.RBracket)] = 72;
        _table[(NonTerminal.TermPrime, TokenType.Comma)] = 72;

        // Factor -> INT_LITERAL (73) | BOOL_LITERAL (74) | FLOAT_LITERAL (75) | CHAR_LITERAL (76) | STRING_LITERAL (77)
        // | Identifier FactorArray (78) | '(' Expr ')' (82) | NOT Factor (83)
        _table[(NonTerminal.Factor, TokenType.IntLiteral)] = 73;
        _table[(NonTerminal.Factor, TokenType.BoolLiteral)] = 74;
        _table[(NonTerminal.Factor, TokenType.FloatLiteral)] = 75;
        _table[(NonTerminal.Factor, TokenType.CharLiteral)] = 76;
        _table[(NonTerminal.Factor, TokenType.StringLiteral)] = 77;
        _table[(NonTerminal.Factor, TokenType.Identifier)] = 78;
        _table[(NonTerminal.Factor, TokenType.LParen)] = 82;
        _table[(NonTerminal.Factor, TokenType.Not)] = 83;

        // FactorArray -> '(' CallArgs ')' (79) | '[' Expr ']' (80) | ε (81)
        _table[(NonTerminal.FactorArray, TokenType.LParen)] = 79;
        _table[(NonTerminal.FactorArray, TokenType.LBracket)] = 80;

        // ε para todos os outros lookaheads de FactorArray
        _table[(NonTerminal.FactorArray, TokenType.Plus)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Minus)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Mul)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Div)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Less)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.LessEqual)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Greater)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.GreaterEqual)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.EqualEqual)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.NotEqual)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.And)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Or)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Semicolon)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.RParen)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.RBracket)] = 81;
        _table[(NonTerminal.FactorArray, TokenType.Comma)] = 81;

        // AssignStmt -> Identifier AssignPart (88)
        _table[(NonTerminal.AssignStmt, TokenType.Identifier)] = 88;

        // AssignPart -> '[' Expr ']' Assign Expr (89) | Assign Expr (90)
        _table[(NonTerminal.AssignPart, TokenType.LBracket)] = 89;
        _table[(NonTerminal.AssignPart, TokenType.Assign)] = 90;

        // ElsePart -> ELSEIF '(' Expr ')' '(' StatementList ')' ElsePart (91) | ELSE '(' StatementList ')' (92) | ε (93)
        _table[(NonTerminal.ElsePart, TokenType.ElseIf)] = 91;
        _table[(NonTerminal.ElsePart, TokenType.Else)] = 92;

        _table[(NonTerminal.ElsePart, TokenType.IntType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.BoolType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.FloatType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.CharType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.StringType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.BitType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.VoidType)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.If)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.While)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Do)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.For)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Print)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Fetch)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Select)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Update)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Save)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Func)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Return)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.Identifier)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.EndOfFile)] = 93;
        _table[(NonTerminal.ElsePart, TokenType.RParen)] = 93;

        // CallArgs -> Expr CallArgsPrime (84) | ε (85)
        _table[(NonTerminal.CallArgs, TokenType.IntLiteral)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.BoolLiteral)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.FloatLiteral)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.CharLiteral)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.StringLiteral)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.Identifier)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.LParen)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.Not)] = 84;
        _table[(NonTerminal.CallArgs, TokenType.RParen)] = 85;

        // CallArgsPrime -> ',' Expr CallArgsPrime (86) | ε (87)
        _table[(NonTerminal.CallArgsPrime, TokenType.Comma)] = 86;
        _table[(NonTerminal.CallArgsPrime, TokenType.RParen)] = 87;

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


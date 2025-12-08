namespace EscrappyCompiler.Parsing;

public enum NonTerminal
{
    Program,
    StatementList,
    Statement,
    VarDecl,
    VarDeclPart,        // → INT x[10]; ou INT x;
    ArrayDim,           // → '[' INT ']' ou ε
    Type,
    IfStmt,
    WhileStmt,
    DoStmt,
    ForStmt,
    PrintStmt,
    FetchStmt,          // → FETCH novo
    SelectStmt,         // → SELECT novo
    UpdateStmt,         // → UPDATE novo
    SaveStmt,           // → SAVE novo
    FuncDecl,           // → FUNC novo
    ParamList,          // → parâmetros de função
    ParamListPrime,     // → ',' ParamList | ε
    Param,              // → Type Identifier
    ReturnStmt,         // → RETURN novo
    Expr,
    LogicExprPrime,
    LogicTerm,
    LogicTermPrime,
    RelExpr,
    RelPrime,
    AddExpr,
    ExprPrime,
    Term,
    TermPrime,
    Factor,
    FactorArray,        // → '[' Expr ']' ou ε (acesso a array)
    AssignStmt,
    AssignPart,         // ← NOVO: '[' Expr ']' = Expr ou = Expr
    ElsePart,

    // Extras para SELECT/UPDATE
    ColumnList,         // → Identifier ou *
    ColumnListPrime,    // → ',' ColumnList | ε
    Conditions,          // → WHERE Expr ou ε

    CallArgs,       // lista de argumentos em chamada de função
    CallArgsPrime,  // ',' Expr CallArgsPrime | ε
    CallStmt
}

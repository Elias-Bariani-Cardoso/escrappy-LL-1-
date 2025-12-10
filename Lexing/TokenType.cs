namespace EscrappyCompiler.Lexing;

public enum TokenType
{
    // Símbolos simples
    Semicolon, Dot, LParen, RParen, LBracket, RBracket, Comma,
    Assign, Mul, Plus, Minus, Tilde, Div, Mod,
    ShiftLeft, ShiftRight, Pipe,
    Less, LessEqual, Greater, GreaterEqual, EqualEqual, NotEqual,

    // Operadores lógicos / palavras-chave
    And, Or, Not,
    Fetch, Select, Update, Save, Set, Regex, Print, Func, Return,
    If, Else, ElseIf, Where,
    While, Do, For,
    In, From,
    Arrow,

    // Tipos
    VoidType, BitType, BoolType, IntType, FloatType, CharType, StringType,

    // Literais / identificadores
    VoidLiteral, BoolLiteral, IntLiteral, FloatLiteral, CharLiteral, StringLiteral,
    Identifier, Error,

    // Especiais
    EndOfFile,
}

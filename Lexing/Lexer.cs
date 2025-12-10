using System.Text;

namespace EscrappyCompiler.Lexing;

public sealed class Lexer
{
    private readonly string _source;
    private int _index;
    private int _line = 1;
    private int _column = 1;

    private char Current => _index < _source.Length ? _source[_index] : '\0';

    public Lexer(string source)
    {
        _source = source;
    }

    public IEnumerable<Token> Tokenize()
    {
        var tokens = new List<Token>();

        Token token;
        do
        {
            token = NextToken();
            tokens.Add(token);
        }
        while (token.Type != TokenType.EndOfFile);

        return tokens;
    }

    private Token NextToken()
    {
        if (_index >= _source.Length)
            return new Token(TokenType.EndOfFile, string.Empty, _line, _column);

        // pular espaços
        while (char.IsWhiteSpace(Current))
        {
            Advance();
            if (_index >= _source.Length)
                return new Token(TokenType.EndOfFile, string.Empty, _line, _column);
        }

        int startLine = _line;
        int startColumn = _column;
        char c = Current;

        // comentário: -- até o fim da linha
        if (c == '-' && Peek() == '-')
        {
            while (Current != '\n' && Current != '\0')
                Advance();
            return NextToken();
        }

        // símbolos
        switch (c)
        {
            case ';': Advance(); return MakeToken(TokenType.Semicolon, startLine, startColumn, ";");
            case '.': Advance(); return MakeToken(TokenType.Dot,      startLine, startColumn, ".");
            case '(': Advance(); return MakeToken(TokenType.LParen,   startLine, startColumn, "(");
            case ')': Advance(); return MakeToken(TokenType.RParen,   startLine, startColumn, ")");
            case '[': Advance(); return MakeToken(TokenType.LBracket, startLine, startColumn, "[");
            case ']': Advance(); return MakeToken(TokenType.RBracket, startLine, startColumn, "]");
            case ',': Advance(); return MakeToken(TokenType.Comma,    startLine, startColumn, ",");
            case '+': Advance(); return MakeToken(TokenType.Plus,     startLine, startColumn, "+");
            case '-': Advance(); return MakeToken(TokenType.Minus,    startLine, startColumn, "-");
            case '*': Advance(); return MakeToken(TokenType.Mul,      startLine, startColumn, "*");
            case '/': Advance(); return MakeToken(TokenType.Div,      startLine, startColumn, "/");
            case '%': Advance(); return MakeToken(TokenType.Mod,      startLine, startColumn, "%");
            case '~': Advance(); return MakeToken(TokenType.Tilde,    startLine, startColumn, "~");
            case '|': Advance(); return MakeToken(TokenType.Pipe,     startLine, startColumn, "|");
            case '<':
                if (Peek() == '=') { Advance(); Advance(); return MakeToken(TokenType.LessEqual,    startLine, startColumn, "<="); }
                if (Peek() == '>') { Advance(); Advance(); return MakeToken(TokenType.NotEqual,     startLine, startColumn, "<>"); }
                if (Peek() == '<') { Advance(); Advance(); return MakeToken(TokenType.ShiftLeft,    startLine, startColumn, "<<"); }
                Advance();
                return MakeToken(TokenType.Less, startLine, startColumn, "<");
            case '>':
                if (Peek() == '=') { Advance(); Advance(); return MakeToken(TokenType.GreaterEqual, startLine, startColumn, ">="); }
                if (Peek() == '>') { Advance(); Advance(); return MakeToken(TokenType.ShiftRight,   startLine, startColumn, ">>"); }
                Advance();
                return MakeToken(TokenType.Greater, startLine, startColumn, ">");
            case '=':
                if (Peek() == '=') { Advance(); Advance(); return MakeToken(TokenType.EqualEqual,   startLine, startColumn, "=="); }
                Advance();
                return MakeToken(TokenType.Assign, startLine, startColumn, "=");
            case '"':
                return LexString(startLine, startColumn);
            case '\'':
                return LexChar(startLine, startColumn);
        }

        // números (INT ou FLOAT)
        if (char.IsDigit(c) || ((c == '+' || c == '-') && char.IsDigit(Peek())))
            return LexNumber(startLine, startColumn);

        // identificador / palavra-chave
        // → PRIMEIRO CARACTERE: apenas letra (sem "_")
        if (char.IsLetter(c))
            return LexIdentifierOrKeyword(startLine, startColumn);

        // caractere inesperado: trate como erro léxico explícito
        // em vez de chamar isso de Identifier
        char invalid = c;
        Advance();
        return MakeToken(
            TokenType.Error,
            startLine,
            startColumn,
            $"Caractere inválido '{invalid}'"
        );
        // ou, se preferir não lançar exceção:
        // return MakeToken(TokenType.Unknown, startLine, startColumn, invalid.ToString());
    }

    private void Advance()
    {
        if (Current == '\n')
        {
            _line++;
            _column = 1;
        }
        else
        {
            _column++;
        }
        _index++;
    }

    private char Peek(int offset = 1)
    {
        int pos = _index + offset;
        return pos < _source.Length ? _source[pos] : '\0';
    }

    private Token MakeToken(TokenType type, int line, int column, string lexeme) =>
        new(type, lexeme, line, column);

    private Token LexIdentifierOrKeyword(int startLine, int startColumn)
    {
        var sb = new StringBuilder();

        // CORPO DO IDENTIFICADOR: letra ou dígito, SEM "_"
        while (char.IsLetterOrDigit(Current))
        {
            sb.Append(Current);
            Advance();
        }

        string text = sb.ToString();

        return text switch
        {
            "FETCH"  => MakeToken(TokenType.Fetch,    startLine, startColumn, text),
            "SELECT" => MakeToken(TokenType.Select,   startLine, startColumn, text),
            "UPDATE" => MakeToken(TokenType.Update,   startLine, startColumn, text),
            "SAVE"   => MakeToken(TokenType.Save,     startLine, startColumn, text),
            "SET"    => MakeToken(TokenType.Set,      startLine, startColumn, text),
            "REGEX"  => MakeToken(TokenType.Regex,    startLine, startColumn, text),
            "PRINT"  => MakeToken(TokenType.Print,    startLine, startColumn, text),
            "FUNC"   => MakeToken(TokenType.Func,     startLine, startColumn, text),
            "RETURN" => MakeToken(TokenType.Return,   startLine, startColumn, text),

            "IF"     => MakeToken(TokenType.If,       startLine, startColumn, text),
            "ELSE"   => MakeToken(TokenType.Else,     startLine, startColumn, text),
            "ELSEIF" => MakeToken(TokenType.ElseIf,   startLine, startColumn, text),
            "WHERE"  => MakeToken(TokenType.Where,    startLine, startColumn, text),

            "WHILE"  => MakeToken(TokenType.While,    startLine, startColumn, text),
            "DO"     => MakeToken(TokenType.Do,       startLine, startColumn, text),
            "FOR"    => MakeToken(TokenType.For,      startLine, startColumn, text),

            "IN"     => MakeToken(TokenType.In,       startLine, startColumn, text),
            "FROM"   => MakeToken(TokenType.From,     startLine, startColumn, text),

            "VOID"   => MakeToken(TokenType.VoidType, startLine, startColumn, text),
            "BIT"    => MakeToken(TokenType.BitType,  startLine, startColumn, text),
            "BOOL"   => MakeToken(TokenType.BoolType, startLine, startColumn, text),
            "INT"    => MakeToken(TokenType.IntType,  startLine, startColumn, text),
            "FLOAT"  => MakeToken(TokenType.FloatType,startLine, startColumn, text),
            "CHAR"   => MakeToken(TokenType.CharType, startLine, startColumn, text),
            "STRING" => MakeToken(TokenType.StringType,startLine,startColumn, text),

            "null"   => MakeToken(TokenType.VoidLiteral, startLine, startColumn, text),
            "true" or "false"
                     => MakeToken(TokenType.BoolLiteral, startLine, startColumn, text),

            "NOT"    => MakeToken(TokenType.Not,      startLine, startColumn, text),
            "AND"    => MakeToken(TokenType.And,      startLine, startColumn, text),
            "OR"     => MakeToken(TokenType.Or,       startLine, startColumn, text),

            _        => MakeToken(TokenType.Identifier, startLine, startColumn, text)
        };
    }

    private Token LexNumber(int startLine, int startColumn)
    {
        var sb = new StringBuilder();

        if (Current == '+' || Current == '-')
        {
            sb.Append(Current);
            Advance();
        }

        while (char.IsDigit(Current))
        {
            sb.Append(Current);
            Advance();
        }

        bool isFloat = false;
        if (Current == '.' && char.IsDigit(Peek()))
        {
            isFloat = true;
            sb.Append(Current);
            Advance();
            while (char.IsDigit(Current))
            {
                sb.Append(Current);
                Advance();
            }
        }

        string text = sb.ToString();
        return isFloat
            ? MakeToken(TokenType.FloatLiteral, startLine, startColumn, text)
            : MakeToken(TokenType.IntLiteral,   startLine, startColumn, text);
    }

    private Token LexString(int startLine, int startColumn)
    {
        Advance(); // consume opening "
        var sb = new StringBuilder();

        while (Current != '"' && Current != '\0' && Current != '\n')
        {
            sb.Append(Current);
            Advance();
        }

        if (Current == '"')
            Advance(); // closing "

        string text = sb.ToString();
        return MakeToken(TokenType.StringLiteral, startLine, startColumn, text);
    }

    private Token LexChar(int startLine, int startColumn)
    {
        Advance(); // consume opening '
        char ch = Current;
        Advance();
        if (Current == '\'')
            Advance(); // closing '

        return MakeToken(TokenType.CharLiteral, startLine, startColumn, ch.ToString());
    }
}

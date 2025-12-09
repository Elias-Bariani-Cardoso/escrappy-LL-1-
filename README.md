# EscrappyCompiler

> **Analisador Léxico e Sintático Preditivo LL(1)**

Este repositório documenta a implementação das fases iniciais do compilador **EscrappyCompiler**, com foco no **Analisador Léxico (Scanner)** e no **Analisador Sintático Preditivo LL(1)**. O projeto segue diretrizes clássicas de construção de compiladores: gramática livre de recursão à esquerda, fatoração quando necessário, e definição explícita de precedência/associatividade.

---

## 📌 Visão geral

O protótipo atual reconhece e valida as seguintes estruturas da linguagem *EscrappyCompiler*:

* **Bloco Principal**: declaração do bloco de execução `main`.
* **Declaração de Variáveis**: tipos básicos (`int`, `float`, `double`, etc.).
* **Estruturas Condicionais**: `if` / `else`.
* **Instruções de Loop**: `while`, `do/while`, `for` (reconhecimento sintático).
* **Expressões**: operações aritméticas e lógicas (não-terminais como `AddExpr`, `LogicExpr`).

---

## 🛠️ Implementação dos Analisadores

### 1. Analisador Léxico (Scanner)

* **Responsabilidade**: transformar o código-fonte em uma sequência de tokens.
* **Implementação**: o scanner pode ser implementado de forma pura (manual) ou usando ferramentas como **Flex**. A escolha está indicada no repositório (pasta `lexer/`).
* **Saída**: cadeia de tokens (token stream) usada pelo parser.
* **Critérios de avaliação**: identificação correta de lexemas, classes (identifiers, keywords, literals, operators, delimiters) e definição das expressões regulares.

**Exemplo de tokens esperados:**

```
Identifier(x)  Assign(=)  IntLiteral(10)  Semicolon(;)
Identifier(hello)  LParen(()  RParen())  Semicolon(;)
```

---

### 2. Analisador Sintático LL(1)

* **Implementação**: parser escrito de forma pura (programática), implementando o algoritmo LL(1) com tabela precomputada.
* **Adaptação da gramática**:

  * Eliminação de ambiguidade quando necessário.
  * Inclusão explícita de associatividade/precedência para operadores.
  * Eliminação de recursividade à esquerda (relatório: *nenhuma encontrada*).
  * Fatoração para tornar a gramática compatível com LL(1).

---

## 🔬 Análise Formal LL(1)

A construção correta da **Tabela LL(1)** depende da computação dos conjuntos **FIRST** e **FOLLOW** para cada não-terminal.

### 1. Métricas da Gramática (versão adaptada)

* **Total de Produções**: 96
* **Total de Não-Terminais**: 43
* **Entradas na Tabela LL(1)**: 299

> Observação: os números são referentes à gramática usada no protótipo. Consulte `Grammar_Analysis_Report.txt` para a listagem completa.

### 2. Conjuntos FIRST e FOLLOW (exemplo)

* **FIRST(Expr)** = `{ BoolLiteral, Identifier, LParen, Not, ... }`
* **FOLLOW(Expr)** = `{ Comma, RBracket, RParen, Semicolon, ... }`

> Consulte o relatório formal para tabelas completas `FIRST/FOLLOW`.

### 3. Conflitos Identificados

O objetivo é uma tabela LL(1) **sem conflitos**. Durante a adaptação, foram encontrados dois conflitos iniciais:

* **Principal** — `(Statement, Identifier)` — *RESOLVIDO*: aplicou-se fatoração usando `StatementTail` (Produção 9) para distinguir entre chamada de função (`CallStmt`) e atribuição/declaração (`AssignPart`).
* **Secundário** — `(ReturnStmt, Return)` — *PENDENTE*: conflito entre `RETURN Expr` e `RETURN` (retorno sem expressão). Atualmente a implementação usa a Produção [51] por padrão; solução definitiva exige refatoração da gramática ou lookahead adicional (LL(2)).

---

## ✅ Testes de Parsing

O parser foi validado com várias cadeias de tokens (amostras aceitas):

* `x = 10;`
* `hello();`
* `arr[0] = 1;`
* `x = add(x, add(3, 4));`
* `arr[0] = add(arr[1], 10);`

Casos de erro sintático devem produzir mensagens de erro claras com indicação de **token**, **linha** e **coluna**.

---

## 💻 Como executar

> Exemplo genérico — ajuste conforme a linguagem/implementação presente no repositório.

1. Clone o repositório:

```bash
git clone https://github.com/SeuUsuario/EscrappyCompiler.git
cd EscrappyCompiler
```

2. Compilar o Scanner/Parser:

* **Se usar Flex/Bison**:

```bash
flex lexer.l
bison -d parser.y
gcc lex.yy.c parser.tab.c -o escrappycompiler
```

* **Se implementação pura (Java/C# etc.)**:

```bash
# Java
javac -d bin src/**/*.java
# .NET
dotnet build
```

3. Executar a análise em um arquivo de teste:

```bash
# exemplo genérico
./escrappycompiler < testes/exemplo1.escrappy
```

**Saída esperada**: sequências de tokens seguidas pela mensagem `Parsing ACEITO` — ou, em caso de falha, relatório de erro sintático com linha/coluna e token inesperado.

---

## 🧑‍🤝‍🧑 Equipe

* **[Elias]** — Análise Léxica (Scanner)
* **[Diogo]** — Design da Gramática e Análise Formal LL(1)
* **[Davi tuma]** — Pilha e Tabela
* **[Paulo Ricardo]** — Testes, Documentação e Relatórios
* **[Marcos Silva]** - Implementação do Algoritmo LL(1)
* 

> Substitua `[Membro X]` pelos nomes reais dos colaboradores.

---

## 📎 Arquivos importantes no repositório

* `lexer/` — regras do scanner (flex) ou implementações manuais.
* `parser/` — código do parser LL(1) e tabela.
* `grammar/Grammar_Analysis_Report.txt` — relatório formal com `FIRST/FOLLOW`, métricas e conflitos.
* `tests/` — casos de teste (aceitos e rejeitados).

---

## 🔧 Boas práticas e recomendações

* Versione frequentemente a gramática (ex.: `grammar/grammar_v1.txt`, `grammar/grammar_v2.txt`).
* Mantenha o scanner e parser desacoplados — exponha a interface `TokenStream`.
* Gere mensagens de erro amigáveis e recuperáveis quando possível (error productions ou sincronização por `FOLLOW`).


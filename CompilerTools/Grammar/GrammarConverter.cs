using System;

namespace CompilerTools.Grammar
{
    public class GrammarConverter
    {
        private GrammarModel Grammar;

        public GrammarExport? Export { get; private set; }

        public GrammarConverter(string grammarFile)
        {
            Grammar = GrammarLoader.Load(grammarFile);
        }

        public void RunPipeline()
        {
            Console.WriteLine("[1] Removendo Ambiguidade (Associatividade e Precedência)...");
            GrammarDisambiguator.Apply(ref Grammar);

            Console.WriteLine("[2] Aplicando Patches Específicos...");
            GrammarPatches.Apply(Grammar);

            Console.WriteLine("[3] Removendo Recursão à Esquerda...");
            LeftRecursionRemover.Remove(Grammar);

            Console.WriteLine("[4] Aplicando Fatoração (Left-Factoring)...");
            LeftFactoring.Apply(Grammar);

            Console.WriteLine("[5] Calculando FIRST / FOLLOW...");
            var ff = new FirstFollowGenerator(Grammar);
            ff.ComputeFIRST();
            ff.ComputeFOLLOW();

            Console.WriteLine("[6] Construindo Tabela LL(1)...");
            var table = new LL1TableGenerator(Grammar, ff);
            table.Build();

            Export = new GrammarExport(Grammar, ff, table);

            Console.WriteLine("[✔] Conversão LL(1) concluída!");
        }
    }
}

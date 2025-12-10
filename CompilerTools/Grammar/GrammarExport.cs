using System.IO;
using System.Linq;

namespace CompilerTools.Grammar
{
    public class GrammarExport
    {
        private GrammarModel G;
        private FirstFollowGenerator FF;
        private LL1TableGenerator T;

        public GrammarExport(
            GrammarModel g,
            FirstFollowGenerator ff,
            LL1TableGenerator tbl)
        {
            G = g;
            FF = ff;
            T = tbl;
        }

        public void ExportAll(string path)
        {
            Directory.CreateDirectory(path);

            ExportGrammar(Path.Combine(path, "Grammar_Final.txt"));
            ExportFirst(Path.Combine(path, "FIRST.csv"));
            ExportFollow(Path.Combine(path, "FOLLOW.csv"));
            ExportLL1(Path.Combine(path, "LL1_Table.csv"));
        }

        private void ExportGrammar(string file)
        {
            using var sw = new StreamWriter(file);
            foreach (var p in G.Productions)
                sw.WriteLine(p);
        }

        private void ExportFirst(string file)
        {
            using var sw = new StreamWriter(file);
            sw.WriteLine("NonTerminal,FIRST");

            foreach (var kv in FF.FIRST)
                sw.WriteLine($"{kv.Key},\"{string.Join(",", kv.Value)}\"");
        }

        private void ExportFollow(string file)
        {
            using var sw = new StreamWriter(file);
            sw.WriteLine("NonTerminal,FOLLOW");

            foreach (var kv in FF.FOLLOW)
                sw.WriteLine($"{kv.Key},\"{string.Join(",", kv.Value)}\"");
        }

        private void ExportLL1(string file)
        {
            using var sw = new StreamWriter(file);

            sw.WriteLine("NonTerminal,Terminal,Production");

            foreach (var kv in T.Table)
                sw.WriteLine($"{kv.Key.NonTerminal},{kv.Key.Terminal},\"{kv.Value}\"");
        }
    }
}

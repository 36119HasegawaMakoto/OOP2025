using System.Text.RegularExpressions;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {

            var lines = File.ReadAllLines("sample.txt");

            var newlines = lines.Select(s => Regex.Replace(s,@"\b[V|v]ersion\s*=\s*""v4\.0""", @"version=""v5.0""")).ToArray();

            File.WriteAllLines("samplleChange.txt",newlines);

            //確認用
            var text = File.ReadAllText("samplleChange.txt");
            Console.WriteLine(text);


        }
    }
}

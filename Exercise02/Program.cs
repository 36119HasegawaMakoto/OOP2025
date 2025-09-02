using System.Text.RegularExpressions;
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            string filePath = "sample.txt";
            Pick3DigitNumber(filePath);

        }

        private static void Pick3DigitNumber(string filePath) {
            foreach (var line in File.ReadLines(filePath)) {
                var matches = Regex.Matches(line, @"\b[a-zA-Z]+\b");
                foreach (Match m in matches) {
                    //結果の表示
                    Console.WriteLine(m.Value);
                }
            }
        }
    }
}

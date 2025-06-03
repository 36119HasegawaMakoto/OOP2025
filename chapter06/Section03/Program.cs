using System.Text;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            //var language = new[] { "c#", "java", "python", "Ruby" };
            //var separator = "=";
            //var result = String.Join(separator, language);
            //Console.WriteLine(result);

            //StringBuilderクラスを利用
            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            //文字列連結
            String str = "";
            foreach (var word in GetWords()) {
                str += word;
            }
            Console.WriteLine(str);
        }

        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}

using System.Text.RegularExpressions;
namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var text = "1024バイト、8バイト文字、バイト、キロバイト";
            var pattern = @"(\d+)バイト";
            var replaced = Regex.Replace(text, pattern, "$1byte");
            Console.WriteLine(replaced);
        }
    }
}

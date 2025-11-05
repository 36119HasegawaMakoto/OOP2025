using System.Threading.Tasks;

namespace Exercise01_Console {
    internal class Program {
        static async Task Main(string[] args) {
            var filepath = "走れメロス.txt";
            await foreach (var line in File.ReadLinesAsync(filepath)) {
                Console.WriteLine(line);
            }
        }
    }
}

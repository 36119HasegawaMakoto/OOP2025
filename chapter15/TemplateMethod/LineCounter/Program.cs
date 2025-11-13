using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("パスの入力して");
            string filepath = Console.ReadLine();
            TextProcessor.Run<LineCounterProcessor>(filepath);
        }
    }
}

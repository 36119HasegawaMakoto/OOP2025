using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var filePath = "Greeting.txt";
            if (File.Exists(filePath)) {
                using var reader = new StreamReader(filePath, Encoding.UTF8);
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                }                
            }
        }
    }
}

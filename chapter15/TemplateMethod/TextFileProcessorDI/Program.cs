namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            var service = new LineCoumterService();
            var processor = new TextFileProcessor(service);
            Console.Write("パスの入力");
            processor.Run(Console.ReadLine());
        }
    }            
}

using System.Text;

namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //var service = new LineCoumterService();
            //var service =  new LineOutputService();
            var service = new LineTOHalfNumberService();
            var processor = new TextFileProcessor(service);
            Console.Write("パスの入力");
            processor.Run(Console.ReadLine());
        }
    }            
}

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //10-1-1
            //    var filePath = "Greeting.txt";
            //    int count = 0;
            //    using var reader = new StreamReader(filePath);
            //    while (!reader.EndOfStream) {
            //        string line = reader.ReadLine();
            //        if (line.Contains(" Class ")) {
            //            count++;
            //        }
            //        Console.WriteLine(count);
            //    }

            //10-1-2

            //var filePath = "Greeting.txt";
            //int count = 0;
            //var lines = File.ReadAllLines(filePath);
            //foreach (var item in lines) {
            //    if (item.Contains(" Class ")) {
            //        count++;
            //    }
            //}

            //10-1-3

            var filePath = "Greeting.txt";
            int count = 0;
            var lines = File.ReadLines(filePath);
            foreach (var item in lines) {
                if (item.Contains(" Class ")) {
                    count++;
                }
            }
        }
    }
}

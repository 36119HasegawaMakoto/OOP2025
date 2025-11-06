namespace Section05 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("並列処理あり");
            Parallel.For(0, 100, i => {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep(1000);
                Console.WriteLine($"処理{i}終了");
            });

            Console.WriteLine("並列処理なし");

            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep( 1000 );
                Console.WriteLine($"処理{i}終了");
            }
        }
    }
}

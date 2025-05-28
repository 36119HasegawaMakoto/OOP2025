namespace LingSample {
    internal class Program {
        static void Main(string[] args) {

            var numbers = Enumerable.Range(1, 100);

            //合計値を出力
            Console.WriteLine(numbers.Sum());
            //平均
            Console.WriteLine(numbers.Average());
            //偶数合計
            Console.WriteLine(numbers.Where(n => n % 2 ==0).Sum());
            //偶数のでっかい値
            Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());
            //8の倍数の合計
            Console.WriteLine(numbers.Where(n => n % 8 == 0).Sum());



            //foreach (var num in numbers) {
            //    Console.WriteLine(num);
            //}



        }
    }
}

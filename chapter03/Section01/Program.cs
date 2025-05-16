namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            //Console.Write("カウントしたい数値:");
           // int count = int.Parse(Console.ReadLine());

            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            Console.WriteLine(Count( numbers, delegate(int n) { return n % 2 == 0; }) );
            
        }
        static int Count(int[] numbers,Predicate<int> judge) {
            var count = 0;
            foreach (var n in numbers) {
                //引数で受け取ったメソッドを呼び出す
                if (judge(n) == true) {
                    count++;
                }
            }
            return count;
        }
    }
}

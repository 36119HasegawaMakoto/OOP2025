namespace Section01 {
    internal class Program {

        public delegate bool Judgement(int value); //デリゲードの宣言


        static void Main(string[] args) {
            //Console.Write("カウントしたい数値:");
           // int count = int.Parse(Console.ReadLine());

            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            Judgement judge = IsEven;
            Console.WriteLine(Count( numbers, judge));
            
        }
        //メソッドへ渡す処理
        static bool IsEven(int n) {
            return n % 2 == 0;
        }

        static int Count(int[] numbers,Judgement judge) {
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

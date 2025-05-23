
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1();
            Console.WriteLine("---");
            Exercise2();
            Console.WriteLine("---");
            Exercise3();
        }

        private static void Exercise1() {
            Console.Write("一番の値入力してね：");
            string num = Console.ReadLine();
            if (int.TryParse(num, out var number)) {
                if (number <= -1) {
                    Console.WriteLine(number);
                }
                if (number >= 0 && number < 100) {
                    Console.WriteLine(number * 2);
                }
                if (number >= 100 && number < 500) {
                    Console.WriteLine(number * 3);
                }
                if (number >= 500) {
                    Console.WriteLine(number);
                }
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
            }

        private static void Exercise2() {

        }

        private static void Exercise3() {

        }
    }
}

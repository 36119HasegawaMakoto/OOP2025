
using System;

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
            Console.Write("1番の値入力してね：");
            var num = Console.ReadLine();
            if (int.TryParse(num, out var number)) {
                if (number < 0) {
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
            Console.Write("2番の値入力してね：");
            var num = Console.ReadLine();
            if (int.TryParse(num, out var number)) {
                switch (number) {
                    case < 0:
                        Console.WriteLine(number);
                        break;
                    case < 100:
                        Console.WriteLine(number * 2);
                        break;
                    case < 500:
                        Console.WriteLine(number * 3);
                        break;
                    default:
                        Console.WriteLine(number);
                        break;
                }
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise3() {
            Console.Write("3番の値入力してね：");
            var line = Console.ReadLine();
            if (int.TryParse(line, out var number)) {
                var text = number switch {
                    < 0 => number,
                    < 100 => number * 2,
                    < 500 => number * 3,
                    _ => number
                };
                Console.WriteLine(text);
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }
    }
}


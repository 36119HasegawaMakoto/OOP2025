using System.Globalization;
using System;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            if (String.Compare(str1, str2, ignoreCase: true) == 0) {
                Console.WriteLine("一致しています");
            } else {
                Console.WriteLine("ちがうよ");
            }
        }
    }
}

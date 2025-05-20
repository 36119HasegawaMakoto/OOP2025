
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var citiys = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(citiys);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(citiys);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(citiys);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(citiys);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了:");
            while (true) {
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) {
                    break;
                }
                Console.WriteLine(names.FindIndex(s => s == name));
            }
        }

        private static void Exercise2_2(List<string> names) {
            Console.WriteLine(names.Count(s => s.Contains('o')));
        }

        private static void Exercise2_3(List<string> names) {
            var selected = names.Where(s => s.Contains('o')).ToArray();
            foreach (var select in selected) {
                Console.WriteLine(select);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var obj = names.Where(s => s.StartsWith('B'))
                                .Select(s => new { s, s.Length });
            foreach(var data in obj) {
                Console.WriteLine(data.s + ":" + "文字数" + data.Length );
            }
        }
    }
}

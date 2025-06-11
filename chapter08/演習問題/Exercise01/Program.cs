
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var dict = new Dictionary<char, int>();
            foreach (var take in text.ToUpper()) {
                if ((take >= 'A' && take <= 'Z') ) {                    
                    if (dict.ContainsKey(take)) {
                        dict[take]++;
                    } else {
                        dict.Add(take, 1);
                    }
                }
            }
            foreach (var change in dict.OrderBy(s =>s.Key)) {
                Console.WriteLine($"'{change.Key}':{change.Value}");
            }
        }

        private static void Exercise2(string text) {
            var dict = new SortedDictionary<char, int>();
            foreach (var take in text.ToUpper()) {
                if ((take >= 'A' && take <= 'Z')) {
                    if (dict.ContainsKey(take)) {
                        dict[take]++;
                    } else {
                        dict.Add(take, 1);
                    }
                }
            }
            foreach (var change in dict) {
                Console.WriteLine($"'{change.Key}':{change.Value}");
            }
        }
    }
}

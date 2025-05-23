
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
            "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
            "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            //foreach文
            foreach (var item in langs) {
                if (item.Contains("S"))
                    Console.WriteLine(item);
            }
            
            //for文
            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains("S")) {
                    Console.WriteLine(langs[i]);
                }
            }
            //where文
            int hw = 0;
            while (hw < langs.Count) {
                if (langs[hw].Contains("S")) {
                    Console.WriteLine(langs[hw]);
                }
                hw++;
            }
        }

        private static void Exercise2(List<string> langs) {
            var foreac = langs.Where(s => s.Contains('S'));
            foreach (var item in foreac) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise3(List<string> langs) {

        }
    }
}

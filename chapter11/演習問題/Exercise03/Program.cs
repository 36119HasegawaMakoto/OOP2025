using System.Text.RegularExpressions;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            string[] texts = [
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable."
                ];

            //てんてーのやりかた

            //foreach (var line in texts) {
            //    var matches = Regex.Matches(line, @"\btime\b", RegexOptions.IgnoreCase);

            //    foreach (Match match2 in matches) {
            //        Console.WriteLine($"{line}, {match2.Index}");
            //    }
            //}

            //わいのやりかた
            Regex regex = new Regex(@"\btime\b", RegexOptions.IgnoreCase);

            foreach (var line in texts) {
                var matches = regex.Matches(line);
                if (matches.Count > 0) {
                    Console.WriteLine(line);
                    foreach (Match match in matches) {
                        Console.WriteLine($"'time' の開始位置: {match.Index}");
                    }
                }
            }
        }
    }
}

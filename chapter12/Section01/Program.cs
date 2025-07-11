using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //    var novels = new Novel[] {
            //    new Novel {
            //        Author = "アイザック・アシモフ",
            //        Title = "われはロボット",
            //        PublishedYear = 1950,
            //    },
            //    new Novel {
            //        Author = "ジョージ・オーウェル",
            //        Title = "一九八四年",
            //        PublishedYear = 1949,
            //    },
            //};

            //    var options = new JsonSerializerOptions {
            //        WriteIndented = true,
            //        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            //    };
            //    string jsonString = JsonSerializer.Serialize(novels, options);
            //    Console.WriteLine(jsonString);

            var text = File.ReadAllText("novelists.json");
            var novelist = JsonSerializer.Deserialize<List<Novelist>>(text);
            novelist?.ForEach(Console.WriteLine);

        }
    }

    public class Novel {
        public string Title { get; init; } = String.Empty;

        public string Author { get; init; } = String.Empty;

        public int PublishedYear { get; init; }
    }

}


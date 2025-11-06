using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static async Task Main(string[] args) {
            HttpClient hc = new HttpClient();
            hc.DefaultRequestHeaders.UserAgent.ParseAdd(
                "MyWikipediaCliant/1.0 (https://exsample.com; contact@example.com)");
            var text = await GetFromWikipediaAsync(hc, "ELDEN RING");
            Console.WriteLine(text);
        }
        //code14-13
        static async Task GetHtmlExsample(HttpClient httpClient) {
            var url = "https://www.yahoo.co.jp";
            var text = await httpClient.GetStringAsync(url);
            Console.WriteLine(text);
        }
        //code14-14
        static async Task<string> GetFromWikipediaAsync(HttpClient httpClient, string keyword) {
            // UriBuilderとFormUrlEncodedContentを使い、パラメーター付きのURLを組み立てる
            var builder = new UriBuilder("https://ja.wikipedia.org/w/api.php");
            var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
                ["action"] = "query",
                ["format"] = "json",
                ["prop"] = "extracts",
                ["redirects"] = "1",
                ["explaintext"] = "1",
                ["titles"] = keyword,
            });
            // JsonStringを取得する
            builder.Query = await content.ReadAsStringAsync();
            var jsonString = await httpClient.GetStringAsync(builder.Uri);

            // JsonStringをパースして、コンテンツ文字列を取得する
            return GetContentString(jsonString);
        }

        // JsonStringをパースして、コンテンツ文字列を取得する
        static string GetContentString(string jsonString) {
            var jsonNode = JsonNode.Parse(jsonString)!;
            var node = jsonNode["query"]!["pages"]!;
            var pagesElement = JsonSerializer.Deserialize<JsonElement>(node);
            var name = GetChildPropertyName(pagesElement);
            JsonElement contentElement = pagesElement.GetProperty(name);
            JsonElement extractElement = contentElement.GetProperty("extract");
            return extractElement.GetString() ?? "";
        }

        // element直下のキー名を取得する
        static string GetChildPropertyName(JsonElement element) {
            return element.EnumerateObject().First().Name;
        }

    }
}

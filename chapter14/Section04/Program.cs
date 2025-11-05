using System.Threading.Tasks;

namespace Section04 {
    internal class Program {
        static async Task Main(string[] args) {
            HttpClient hc = new HttpClient();

           await GetHtmlExsample(hc);
        }

        static async Task GetHtmlExsample(HttpClient httpClient) {
            var url = "https://www.yahoo.co.jp";
            var text = await httpClient.GetStringAsync(url);
            Console.WriteLine(text);
        }
    }
}

using System.Text;
using System.Text.RegularExpressions;

namespace Exercise05 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadLines("sample.html");
            var sb = new StringBuilder();
            foreach (var line in lines) {
                var s = Regex.Replace(line,
                             @"</?\s*([A-Z][A-Z0-9]*)\b>",
                              m => {
                                  //せんせのやり方
                                  //return string.Format("< {0}{1}{2}>"),m.Groups[1].Value,
                                  //      m.Groups[2].Value.ToLower(),
                                  //      m.Groups[3].Value);
                                  // キャプチャされたタグ名を小文字に変換
                                  var tagName = m.Groups[1].Value.ToLower();
                                  return m.Value.Replace(m.Groups[1].Value, tagName);
                              });
                sb.AppendLine(s);
            }
            File.WriteAllText("sampleOut.html", sb.ToString());

            //確認
            var text = File.ReadAllText("sampleOut.html");
            Console.WriteLine(text);

        }
    }
}

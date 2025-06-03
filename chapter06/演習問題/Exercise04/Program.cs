using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";            
            foreach (var pair in line.Split(';')) {
                var novel = pair.Split('=');
                Console.WriteLine($"{ToJapanese(novel[0])} : {novel[1]}");
            }
            //string[] word = line.Split(";");
            //for (int i = 0; i < 3; i++) {
            //    string[] novel = word[i].Split("=");
            //    Console.WriteLine($"{ToJapanese(novel[0])} : {novel[1]}");
            //}
        }
        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
                default:
                    return "エラー";
            }
            //新しい書き方
            //return key switch {
            //    "Novelist" => "作家",
            //    "BestWork" => "代表作",
            //    "Born" => "誕生年",
            //    => "引数keyは正しい値ではありません"
            //};
            

           
        }
    }
}
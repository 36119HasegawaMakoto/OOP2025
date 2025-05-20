namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
               "Tokyo",
               "New Delhi",
               "Bangkok",
               "London",
               "Paris",
               "Berlin",
               "Canberra",
               "Hong Kong",
           };

            var query = cities.Where(s => s.Length <= 5).ToArray();    //即時実行

            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");

            cities[0] = "Osaka";            //- cities[0]を変更 
            foreach (var item in query) {   //- 再度、queryの内容を取り出す
                Console.WriteLine(item);
            }




            /*    IEnumerable<string> query = cities
                //.Where(s => s.Length <= 5)//条件に合ったものを抽出
                //.Select(s => s.ToUpper());//別オブジェクトへ返還（新しい型へ射影する）
                .OrderBy(s => s[0]);

                foreach(var s in query) {
                    Console.WriteLine(s);
                }
    */
        }
    }
}

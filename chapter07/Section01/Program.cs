namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var books = Books.GetBooks();

            //本の平均金額を表示
            Console.WriteLine((int)books.Average(x => x.Price));
            //本のページ合計表示
            Console.WriteLine((int)books.Sum(x => x.Pages));
            //一番金額の安い書籍名と金額を表示
            var no3 = books.Where(x => x.Price == books.Min(b=>b.Price));
            foreach(var item in no3) {
                Console.WriteLine(item.Title + ":" + item.Price);
            }
            //一番ページが多い書籍名とページを表示
            var no4 = books.Where(x => x.Pages == books.Max(b => b.Pages));
            foreach (var item in no4) {
                Console.WriteLine(item.Title + ":" + item.Pages + "ページ");
            }
            //タイトルに「物語が」が含まれている書籍名をすべて表示
            var no5 = books.Where(s => s.Title.Contains("物語"));
            foreach (var item in no5) {
                Console.WriteLine(item.Title);
            }
        }
    }
}

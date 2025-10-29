namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var price = Library.Books
                .Where(b=>b.CategoryId == 1)
                .Max(b=>b.Price);
            Console.WriteLine(price);

            Console.WriteLine();

            var book = Library.Books
                .Where(b => b.PublishedYear >= 2021)
                .MinBy(b => b.Price);
            Console.WriteLine(book);

            Console.WriteLine();

            var average  = Library.Books.Average(x => x.Price);
            var aboves = Library.Books
                .Where(b => b.Price > average);
            foreach (var book1 in aboves) {
                Console.WriteLine(book1);
                
            }
            Console.WriteLine();
            //グルーピング
            var groups = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderByDescending(g => g.Key);
            foreach (var group in groups) {
                Console.WriteLine($"{group.Key}年");
                foreach (var book2 in group) {
                    Console.WriteLine($"  {book2}");
                }
            }
            Console.WriteLine();
            var selected = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(group=>group.MaxBy(b=>b.Price))
                .OrderBy(b=>b!.PublishedYear);
            foreach (var item in selected) {
                Console.WriteLine($"{book!.PublishedYear}年 {book!.Title} ({book!.Price})");
            }
            //p307
            Console.WriteLine();
            var book3 = Library.Books
                 .Join(Library.Categories,
                 book => book.CategoryId,
                 category => category.Id,
                 (book, category) => new {
                     book.Title,
                     Category = category.Name,
                     book.PublishedYear
                 })
                 .OrderBy(b => b.PublishedYear)
                 .ThenBy(b => b.Category);
            foreach (var book4 in book3) {
                Console.WriteLine($"{book4.Title},{book4.Category},{book4.PublishedYear}");
            }

        }
    
    }
}

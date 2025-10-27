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

        }
    }
}

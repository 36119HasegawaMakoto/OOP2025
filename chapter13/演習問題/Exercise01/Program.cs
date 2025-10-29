
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("(2)");
            Exercise1_2();
            Console.WriteLine();
            Console.WriteLine("(3)");
            Exercise1_3();
            Console.WriteLine();
            Console.WriteLine("(4)");
            Exercise1_4();
            Console.WriteLine();
            Console.WriteLine("(5)");
            Exercise1_5();
            Console.WriteLine();
            Console.WriteLine("(6)");
            Exercise1_6();
            Console.WriteLine();
            Console.WriteLine("(7)");
            Exercise1_7();
            Console.WriteLine();
            Console.WriteLine("(8)");
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var book = Library.Books
                .MaxBy(b => b.Price);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var book = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(x => new {
                    year = x.Key,
                    count = x.Count()
                })
                .ToDictionary(x=>x.year, x=> x.count);
            foreach (var item in book) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            
        }

        private static void Exercise1_4() {
            var book = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price);
            foreach (var item in book) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise1_5() {
            var book = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    book = book.CategoryId,
                    Category = category.Name,
                    year = book.PublishedYear
                });
            var books = book.Where(x => x.year == 2022)
                .Distinct();
            foreach (var item in books) {
                Console.WriteLine($"{item.Category}");
            }           
           
        }

        private static void Exercise1_6() {
            var book = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    Book = book.CategoryId,
                    Category = category.Name,
                    name = book.Title,
                })
                .GroupBy(x => x.Category)
                .OrderBy(x=>x.Key);
            foreach (var item in book) {
                Console.WriteLine($"#{item.Key}");
                foreach (var name in item) {
                    Console.WriteLine($"   {name.name}");
                }
            }
        }

        private static void Exercise1_7() {
            var book = Library.Books
               .Join(Library.Categories,
               book => book.CategoryId,
               category => category.Id,
               (book, category) => new {
                   Book = book.CategoryId,
                   Category = category.Name,
                   name = book.Title,
                   year = book.PublishedYear
               })
               .Where(x=>x.Category == "Development")
               .GroupBy(x => x.year);
            foreach (var item in book) {
                Console.WriteLine($"#{item.Key}");
                foreach (var name in item) {
                    Console.WriteLine($"   {name.name}");
                }
            }
        }

        private static void Exercise1_8() {
            var book = Library.Categories
               .GroupJoin(Library.Books,
               c => c.Id,
               b => b.CategoryId,
               (c, book) => new {
                   category = c.Name,
                   Books = book,
                   count = book.Count()
               })
               .Where(x => x.count >= 4);
            foreach (var item in book) {
                Console.WriteLine($"{item.category}");
            }
        }
    }
}

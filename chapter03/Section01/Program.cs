namespace Section01 {
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
            var exists = cities.Exists(s => s[0] == 'P');
            Console.WriteLine(exists);

            var find = cities.Find(s => s.Length == 6);
            Console.WriteLine(find);

            var findin = cities.FindIndex(s => s == "London");
            Console.WriteLine(findin);

            var findall = cities.FindAll(s => s.Length <= 5);
            foreach (var s in findall) {
                Console.WriteLine(s);
            }
            cities.ForEach(s => Console.WriteLine("都市名: " + s));

            var lowerList = cities.ConvertAll(s => s.ToLower());
            lowerList.ForEach(s => Console.WriteLine(s));

            var upperList = cities.ConvertAll(s => s.ToUpper());
            upperList.ForEach(s => Console.WriteLine(s));
        }
    }
}

namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"date\sales.csv");
            var amountsPerStore = sales.GetPerStoreSales();
            foreach (var obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");

            }
        }
       
    }
}

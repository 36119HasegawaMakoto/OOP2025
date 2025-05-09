namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter sales = new SalesCounter(@"date\sales.csv");
            IDictionary<string, int> amountsPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");

            }
        }
       
    }
}

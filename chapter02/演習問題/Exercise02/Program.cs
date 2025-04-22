namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            //１～１０
            PrintInchToMeterList(1, 10);

            //表の出力
            static void PrintInchToMeterList(int st, int en) {
                for (int inch = st; inch <= en; inch++) {
                    double meter = InchConverter.FromMeter(inch);
                    Console.WriteLine($"{inch}inch = {meter:0.0000}m");

                }
            }
        }
    }
}

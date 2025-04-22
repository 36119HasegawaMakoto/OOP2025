namespace DistanceConverter {
    internal class Program {
        //コマンドライン引数で指定された範囲のフィートとメートルの対応表を出力する
        static void Main(string[] args) {

            int st = int.Parse(args[1]);
            int en = int.Parse(args[2]);

            if (args.Length >= 1 && args[0] == "-tom") {
                PrintFeetToMeterList(st, en);
            } else {
                PrintMeterToFeetList(st, en);
            }
        }
        //フィートからメートルへの対応表を出力
        static void PrintFeetToMeterList(int st, int en) {
            for (int feet = st; feet <= en; feet++) {
                double meter = FeetConverter.FromMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }
        //メートルからフィートへの対応表を出力
        static void PrintMeterToFeetList(int st, int en) {
            for (int meter = st; meter <= en; meter++) {
                double feet = FeetConverter.ToMeter(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }
    }
}

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("***変換アプリ***");
            Console.WriteLine("1:インチからメートル");
            Console.WriteLine("2:メートルからインチ");
            Console.Write(">");
            //キーボード入力

            int start = int.Parse(Console.ReadLine());
            Console.Write("はじめ:");
            int st = int.Parse(Console.ReadLine());
            Console.Write("おわり:");
            int en = int.Parse(Console.ReadLine());
            //メートルかインチか判別
            if (start == 1) {
                PrintInchToMeterList(st, en);
            } else if (start == 2) {
                PrintMeterToInchList(st, en);
            } else {
                Console.WriteLine("１か２をにゅうりょくして");
            }

                //インチからメートル表の出力
                static void PrintInchToMeterList(int st, int en) {
                    for (int inch = st; inch <= en; inch++) {
                        double meter = InchConverter.FromMeter(inch);
                        Console.WriteLine($"{inch}inch = {meter:0.0000}m");

                    }
                }
            //メートルからインチ表の出力
            static void PrintMeterToInchList(int st, int en) {
                for (int meter = st; meter <= en; meter++) {
                    double inch = InchConverter.FromInch(meter);
                    Console.WriteLine($"{meter}m = {inch:0.0000}inch");


                }
            }
        }
    }
}

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karint = new Product(123, "かりんとう", 180);
            Product okasi = new Product(111, "おかし", 120);

            //税抜きの価格表示
            Console.WriteLine(karint.Name + "の税抜き価格は" + karint.Price + "円です");
            //消費税額の表示
            Console.WriteLine(karint.Name + "の消費税額は" + karint.GetTax() + "円です");
            //税込み価格の表示
            Console.WriteLine(karint.Name + "の税込み価格は" + karint.GetPriceIncludingTax() +"円です");

            Console.WriteLine(okasi.Name + "の税抜き価格は" + okasi.Price + "円です");
            Console.WriteLine(okasi.Name + "の消費税額は" + okasi.GetTax() + "円です");
            Console.WriteLine(okasi.Name + "の税込み価格は" + okasi.GetPriceIncludingTax() + "円です");


        }
    }
}

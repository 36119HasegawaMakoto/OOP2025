using System.Globalization;
using System.Runtime.Serialization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today = new DateTime(2025,7,12);//日付
            var now = DateTime.Now;//日付と時刻

            Console.WriteLine($"Today:{today}");
            Console.WriteLine($"Now:{now}");

            //自分の生年月日は何曜日かをプログラムを書いて調べる
            Console.WriteLine("日付を入力");
            Console.Write("西暦");
            var seireki = int.Parse(Console.ReadLine());            
            Console.Write("月");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日");
            var day = int.Parse(Console.ReadLine());
            //日付データに変換
            var tan = new DateTime(seireki, month, day);
            //なんか
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = tan.ToString("ggyy年M月d日", culture);
            Console.WriteLine($"{str}年{month}月{day}日{culture.DateTimeFormat.GetDayName(tan.DayOfWeek)}");
            //var tan = new DateTime(2006, 1, 25);
            //DayOfWeek weak = tan.DayOfWeek;
            //Console.WriteLine(weak);
            //うるう年の判定
            Console.Write("西暦入力:");
            var nen = int.Parse(Console.ReadLine());
            var uru = DateTime.IsLeapYear(nen);
            if (uru) {
                Console.WriteLine($"{nen}年はうるう年です");
            } else {
                Console.WriteLine($"{nen}年は平年です");
            }
        }
    }
}

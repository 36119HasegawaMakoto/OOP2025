using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);

        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            Console.WriteLine(string.Format(dateTime.ToString($"{dateTime:yyyy/MM/dd HH:mm}"))); 
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            Console.WriteLine(dateTime.ToString("yyyy年M月d日　HH時mm分ss秒"));
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            //西暦から和暦に
            var str = dateTime.ToString("gg y年 M月 d日", culture);
            //曜日求める
            var weak = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            Console.WriteLine($"{str}({weak})");

        }
    }
}

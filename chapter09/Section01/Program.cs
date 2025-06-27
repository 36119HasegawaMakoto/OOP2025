using System.Globalization;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var today =  DateTime.Today;//日付
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
            //西暦から和暦に
            var str = tan.ToString("ggyy年M月d日", culture);
            Console.WriteLine($"{str}年{month}月{day}日{culture.DateTimeFormat.GetDayName(tan.DayOfWeek)}");
            //var tan = new DateTime(2006, 1, 25);
            //DayOfWeek weak = tan.DayOfWeek;
            //Console.WriteLine(weak);

            //生まれてから何日目？
            TimeSpan diff = today.Date - tan.Date;
            Console.WriteLine($"生まれてから{diff.Days}日たってる");

            //あなたは19歳です
            int age = GetAge(tan, DateTime.Today);
            Console.WriteLine($"お前は{age}歳");

            //1月1日から何日目
            Console.WriteLine($"1月1日から{today.DayOfYear}にち立ってる");

            //うるう年の判定
            Console.Write("西暦入力:");
            var nen = int.Parse(Console.ReadLine());
            var uru = DateTime.IsLeapYear(nen);
            if (uru) {
                Console.WriteLine($"{nen}年はうるう年です");
            } else {
                Console.WriteLine($"{nen}年は平年です");
            }
            static int GetAge(DateTime birtday, DateTime targetDay) {
                var age = targetDay.Year - birtday.Year;
                if(targetDay < birtday.AddYears(age)) {
                    age--;
                }
                return age;
            }
        }
    }
}

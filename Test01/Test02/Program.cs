

namespace Test02 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin",
                "Canberra", "Hong Kong",
            };

            #region テスト用ドライバ
            Console.WriteLine("問題１：合計値");
            Exercise01(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題２：偶数の最大値");
            Exercise02(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題３：昇順");
            Exercise03(numbers);
            Console.WriteLine("\n\n-----");

            Console.WriteLine("問題４：10 以上 50 以下のみ");
            Exercise04(numbers);
            Console.WriteLine("\n\n-----");

            Console.WriteLine("問題５：小文字の'n'が含まれている都市数");
            Exercise05(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題６：全都市数");
            Exercise06(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題７：各都市をアルファベット順（昇順）に出力");
            Exercise07(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題８：各都市の文字数");
            Exercise08(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題９：各都市名と文字数を文字数の昇順");
            Exercise09(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題１０：６文字の都市名");
            Exercise10(cities);
            Console.WriteLine("\n-----");

            #endregion
        }


        //---------------------------------------
        // 以下の問題に書かれている内容を満たすようにプログラムを作成せよ。
        // 必要であればラムダ式とLINQを使用すること
        //---------------------------------------

        //問題１　合計値を表示（式形式で記述せよ）
        //　　　　出力結果【618】
        private static void Exercise01(int[] numbers) => Console.WriteLine(numbers.Sum());


        //問題２　偶数の最大値を表示（式形式で記述せよ）
        //　　　　出力結果【94】
        private static void Exercise02(int[] numbers) => Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());


        //問題３　昇順に並べて表示（遅延実行とする）
        //　　　　出力結果【12 14 17 20 31 35 40 48 53 76 87 91 94】
        private static void Exercise03(int[] numbers) {
            

        }

        //問題４　10以上50以下の数字のみを表示（即時実行でも可とする）
        //　　　　出力結果【12 14 20 40 35 31 17 48】
        private static void Exercise04(int[] numbers) {
            

        }

        //問題５　Countメソッドを使い、小文字の'n'が含まれている都市名がいくつあるかカウントして結果を表示
        //　　　　出力結果【5】
        private static void Exercise05(List<string> cities) {
            

        }

        //問題６　全都市数
        //　　　　出力結果【8】
        private static void Exercise06(List<string> cities) {
            

        }

        //問題７　各都市名をアルファベット順（昇順）に出力
        //　　　　出力結果
        //		  【Bangkok
        //          Berlin
        //          Canberra
        //          Hong Kong
        //          London
        //          New Delhi
        //          Paris
        //          Tokyo】
        private static void Exercise07(List<string> cities) {
            

        }

        //問題８　各都市の文字数
        //　　　　出力結果
        //　　　　【Tokyo : 5文字
        //　　　　  New Delhi : 9文字
        //　　　　  Bangkok : 7文字
        //　　　　  London : 6文字
        //　　　　  Paris : 5文字
        //　　　　  Berlin : 6文字
        //　　　　  Canberra : 8文字
        //　　　　  Hong Kong : 9文字】
        private static void Exercise08(List<string> cities) {
            



        }

        //問題９　各都市名と文字数を文字数の昇順で表示
        //　　　　出力結果
        //        【Tokyo : 5文字
        //          Paris : 5文字
        //          London : 6文字
        //          Berlin : 6文字
        //          Bangkok : 7文字
        //          Canberra : 8文字
        //          New Delhi : 9文字
        //          Hong Kong : 9文字】
        private static void Exercise09(List<string> cities) {
            



        }

        //問題１０　６文字の都市名を表示
        //　　　　出力結果
        //        【London
        //          Berlin】
        private static void Exercise10(List<string> cities) {
            


        }
    }
}

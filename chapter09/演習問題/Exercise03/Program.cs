using System.Diagnostics;
using System.Timers;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            //var tw = new TimeWatch();
            var tw = new Stopwatch();
            tw.Start();
            // スリープする
            Thread.Sleep(1000);
            tw.Stop();
            TimeSpan duration = tw.Elapsed;
            Console.WriteLine("処理時間は{0}ミリ秒でした", duration.TotalMilliseconds);

        }
    }

    class TimeWatch {
        private DateTime _time;
        
        public void Start() {
            //現在の時間を_timeに設定
            _time = DateTime.Now;

        }

        public TimeSpan Stop() {
            //経過時間を返却する
            var stop =  DateTime.Now - _time ;
            return stop; 
        }
    }
}

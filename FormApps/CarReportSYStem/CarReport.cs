using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class CarReport {

        public enum MakerGroup {
            なし,
            トヨタ,
            日産,
            本田,
            スバル,
            輸入車,
            その他,
        }

        public DateTime Date { get; set; }  //日付
        public string Author { get; set; } = string.Empty; //記録者
        public MakerGroup Maker { get; set; }//メーカー
        public string CarName { get; set; } = string.Empty; //車名
        public string Report { get; set; } = string.Empty;  //レポート
        public Image? Picture { get; set; }  //画像
    }
}

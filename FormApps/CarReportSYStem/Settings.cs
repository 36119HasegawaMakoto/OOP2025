using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {

        private static Settings instance;//自分自身のインスタンスを格納

        //設定した色情報を格納
        public int MainFormBackColor { get; set; }

        //コンストラクタ（pirvateすることによりnewできなくする）
        private Settings() {   }

        public static Settings GetInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}

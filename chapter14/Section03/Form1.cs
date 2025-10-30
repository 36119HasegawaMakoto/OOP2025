using System.Diagnostics;
using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(()=>DoLongTimeWork());
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";


        }
        //戻り値のある同期メソッド
        private long DoLongTimeWork() {
            var sw = Stopwatch.StartNew();
            System.Threading.Thread.Sleep(5000);
            sw.Stop();
            return sw.ElapsedMilliseconds;

        }
    }
}

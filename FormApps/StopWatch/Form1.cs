using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StopWatch {
    public partial class Form1 : Form {

        Stopwatch sw = new Stopwatch();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            lbTimeDisp.Text = "00:00:00.00";
            tmDispTimer.Interval = 1; //ms
        }

        //スタートボタンのイベントハンドラ
        private void btStart_Click(object sender, EventArgs e) {
            sw.Start();
            tmDispTimer.Start();    //画面更新用のタイマーをスタート
        }

        private void tmDispTimer_Tick(object sender, EventArgs e) {
            lbTimeDisp.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void btStop_Click(object sender, EventArgs e) {
            sw.Stop();
        }

        private void btReset_Click(object sender, EventArgs e) {
            sw.Reset();
        }

        private void button1_Click(object sender, EventArgs e) {
            listBox1.Items.Insert(0,lbTimeDisp.Text);
        }
    }
}

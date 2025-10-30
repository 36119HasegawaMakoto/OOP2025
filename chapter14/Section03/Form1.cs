using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await Task.Run(()=>DoLongTimeWork());
            toolStripStatusLabel1.Text = "èIóπ";
        }

        private void DoLongTimeWork() {
            System.Threading.Thread.Sleep(5000);
        }
    }
}

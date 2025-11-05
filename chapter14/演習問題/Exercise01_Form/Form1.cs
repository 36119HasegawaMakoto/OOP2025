using System.Text;

namespace Exercise01_Form {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            
        }
        private async void button1_Click(object sender, EventArgs e) {
            string filepath = "ëñÇÍÉÅÉçÉX.txt";
            var text = new StringBuilder();
            using (var reader = new StreamReader(filepath)) {
                string read;
                while ((read = await reader.ReadLineAsync()) != null) {
                    text.AppendLine(read);
                }
            }
            textBox1.Text = text.ToString();
        }
    }
}

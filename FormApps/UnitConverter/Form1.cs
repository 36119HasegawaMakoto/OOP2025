namespace UnitConverter {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void ConvertButton1_Click(object sender, EventArgs e) {
            int inputValie = int.Parse(tbBeforeConversion.Text);

            double outputValie = inputValie * 0.0254;

            tbAfterConversion.Text = outputValie.ToString();
        }
    }
}

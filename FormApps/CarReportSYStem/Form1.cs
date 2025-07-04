using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {
            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text,
                Maker = GetRadioBottonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            listCarReports.Add(carReport);
            setCbAuthor(carReport.Author);
            setcbCarName(carReport.CarName);
            InputItemsAllClear();

        }
        //入力項目全クリア
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            //既に登録済みか確認            
                if (!cbAuthor.Items.Contains(author)) {
                    //未登録なら登録　とうろくずみならなにもしない
                    cbAuthor.Items.Add(author);
                }
            }

        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setcbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                //未登録なら登録　とうろくずみならなにもしない
                cbCarName.Items.Add(carName);
            }
        }

        private CarReport.MakerGroup GetRadioBottonMaker() {
            if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            }
            if (rbHonda.Checked) {
                return CarReport.MakerGroup.本田;
            }
            if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            }
            if (rbImport.Checked) {
                return CarReport.MakerGroup.トヨタ;
            }
            if (rbImport.Checked) {
                return CarReport.MakerGroup.輸入車;
            }
            return CarReport.MakerGroup.その他;

        }

        private void dgvRecord_Click(object sender, EventArgs e) {

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioBottonMaker((CarReport.MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;

        }
        //指定したメーカーのラジオボタンをセット
        private void setRadioBottonMaker(CarReport.MakerGroup tragetMaker) {
            switch (tragetMaker) {
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.本田:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }
        //新規入力のイベントハンドラ
        private void btNewRecord_Click(object sender, EventArgs e) {

        }
        //修正ボタンのイベントハンドラ
        private void btRecordModify_Click(object sender, EventArgs e) {

        }
        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {

        }
    }
}

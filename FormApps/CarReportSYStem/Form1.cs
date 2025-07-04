using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }
        //�摜�J��
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }
        //�摜�폜�{�^��
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        //�ǉ�
        private void btRecordAdd_Click(object sender, EventArgs e) {
            tsslbMessage.Text = string.Empty;
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "�L�^�҂܂��͎Ԗ��������͂ł�";
                return;              
            }

            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text,
                Maker = getRadioBottonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            listCarReports.Add(carReport);
            setCbAuthor(carReport.Author);
            setcbCarName(carReport.CarName);
            inputItemsAllClear();

        }
        //���͍��ڑS�N���A
        private void inputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbAuthor(string author) {
            //���ɓo�^�ς݂��m�F            
            if (!cbAuthor.Items.Contains(author)) {
                //���o�^�Ȃ�o�^�@�Ƃ��낭���݂Ȃ�Ȃɂ����Ȃ�
                cbAuthor.Items.Add(author);
            }
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setcbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                //���o�^�Ȃ�o�^�@�Ƃ��낭���݂Ȃ�Ȃɂ����Ȃ�
                cbCarName.Items.Add(carName);
            }
        }

        private CarReport.MakerGroup getRadioBottonMaker() {
            if (rbNissan.Checked) {
                return CarReport.MakerGroup.���Y;
            }
            if (rbHonda.Checked) {
                return CarReport.MakerGroup.�{�c;
            }
            if (rbSubaru.Checked) {
                return CarReport.MakerGroup.�X�o��;
            }
            if (rbImport.Checked) {
                return CarReport.MakerGroup.�g���^;
            }
            if (rbImport.Checked) {
                return CarReport.MakerGroup.�A����;
            }
            return CarReport.MakerGroup.���̑�;

        }
        //�ꗗ�N���b�N
        private void dgvRecord_Click(object sender, EventArgs e) {
            //if (dgvRecord.CurrentRow is null) return;

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioBottonMaker((CarReport.MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;

        }
        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioBottonMaker(CarReport.MakerGroup tragetMaker) {
            switch (tragetMaker) {
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�{�c:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }
        //�V�K���͂̃C�x���g�n���h��
        private void btNewRecord_Click(object sender, EventArgs e) {
            inputItemsAllClear();
        }
        //�C���{�^���̃C�x���g�n���h��
        private void btRecordModify_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow != null) {
                var index = dgvRecord.CurrentRow.Index;
                listCarReports[index].Date = dtpDate.Value.Date;
                listCarReports[index].Author = cbAuthor.Text;
                listCarReports[index].Maker = getRadioBottonMaker();
                listCarReports[index].CarName = cbCarName.Text;
                listCarReports[index].Report = tbReport.Text;
                listCarReports[index].Picture = pbPicture.Image;
            }
            dgvRecord.Refresh();    //�f�[�^�O���b�h�r���[�̍X�V
        }
        //�폜�{�^���̃C�x���g�n���h��
        private void btRecordDelete_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow != null) {
                //�I������Ă���C���f�b�N�X���擾
                var index = dgvRecord.CurrentRow.Index;
                listCarReports.RemoveAt(index);



            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            inputItemsAllClear();
        }
    }
}

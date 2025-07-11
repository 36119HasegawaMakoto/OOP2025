using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();
        //�ݒ�N���X�̃C���X�^���X�𐶐�
        Settings setting = Settings.GetInstance();

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

        //���[�J�[�󂯎�郁�]�b�g
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
        //�t�H�[�����[�h
        private void Form1_Load(object sender, EventArgs e) {
            inputItemsAllClear();
            //���݂ɐF��ݒ�i�f�[�^�O���b�h�r���[�j
            dgvRecord.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.LawnGreen;
            //�ݒ�t�@�C����ǂݍ��ݔw�i�F��ݒ肷��i�t�V���A�����j
            if (File.Exists("setting.xlm")) {
                try {
                    var set = new XmlSerializer(typeof(Settings));
                    using (var reader = new StreamReader("setting.xml")) {
                        var data = set.Deserialize(reader) as Settings;
                        setting = data ?? setting;
                        //�w�i�F�ݒ�
                        this.BackColor = Color.FromArgb(setting.MainFormBackColor);
                        //�ݒ�N���X�̃C���X�^���X�ɂ����݂̐ݒ�F��ݒ�
                        //setting.MainFormBackColor = BackColor.ToArgb();                        
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�ݒ�t�@�C���Ǎ��G���[";
                    MessageBox.Show(ex.Message);//�킩��₷���G���[
                }
            } else {
                tsslbMessage.Text = "�ݒ�t�@�C��������܂���";
            }              
        }
        //�I��
        private void esmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        //���̃A�v���ɂ���
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }
        //�F�ύX
        private void esmiCollor_Click(object sender, EventArgs e) {
            if (cdCollar.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdCollar.Color;
                //�ݒ�t�@�C���֕ۑ�
                setting.MainFormBackColor = cdCollar.Color.ToArgb();    //�w�i�F��ݒ�C���X�^���X�֐ݒ�
            }
        }
        //�t�@�C���I�[�v������
        private void reportOpenFire() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(
                           ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;
                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        //�R���{�{�b�N�X�֓o�^
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setcbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }
            }
        }
        //�t�@�C���Z�[�u����
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                              sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message);//����̎�I�ȃG���[���o��
                }
            }
        }
        //�ۑ��{�^��
        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }
        //�J���{�^��
        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFire();
        }
        //�t�H�[����������Ă΂��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //�ݒ�t�@�C���֐F����ۑ����鏈���i�V���A�����j
            var serializer = new XmlSerializer(typeof(Settings)); 
            using (var writer = XmlWriter.Create("setting.xml")) {
                serializer.Serialize(writer, setting);
            }

        }
    }
}

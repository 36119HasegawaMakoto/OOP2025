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
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();
        //設定クラスのインスタンスを生成
        Settings setting = Settings.GetInstance();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }
        //画像開く
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }
        //画像削除ボタン
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        //追加
        private void btRecordAdd_Click(object sender, EventArgs e) {
            tsslbMessage.Text = string.Empty;
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者または車名が未入力です";
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
        //入力項目全クリア
        private void inputItemsAllClear() {
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

        //メーカー受け取るメゾット
        private CarReport.MakerGroup getRadioBottonMaker() {
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
        //一覧クリック
        private void dgvRecord_Click(object sender, EventArgs e) {
            //if (dgvRecord.CurrentRow is null) return;

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
            inputItemsAllClear();
        }
        //修正ボタンのイベントハンドラ
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
            dgvRecord.Refresh();    //データグリッドビューの更新
        }
        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow != null) {
                //選択されているインデックスを取得
                var index = dgvRecord.CurrentRow.Index;
                listCarReports.RemoveAt(index);
            }
        }
        //フォームロード
        private void Form1_Load(object sender, EventArgs e) {
            inputItemsAllClear();
            //交互に色を設定（データグリッドビュー）
            dgvRecord.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.LawnGreen;
            //設定ファイルを読み込み背景色を設定する（逆シリアル化）
            if (File.Exists("setting.xlm")) {
                try {
                    var set = new XmlSerializer(typeof(Settings));
                    using (var reader = new StreamReader("setting.xml")) {
                        var data = set.Deserialize(reader) as Settings;
                        setting = data ?? setting;
                        //背景色設定
                        this.BackColor = Color.FromArgb(setting.MainFormBackColor);
                        //設定クラスのインスタンスにも現在の設定色を設定
                        //setting.MainFormBackColor = BackColor.ToArgb();                        
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "設定ファイル読込エラー";
                    MessageBox.Show(ex.Message);//わかりやすいエラー
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }              
        }
        //終了
        private void esmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        //このアプリについて
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }
        //色変更
        private void esmiCollor_Click(object sender, EventArgs e) {
            if (cdCollar.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdCollar.Color;
                //設定ファイルへ保存
                setting.MainFormBackColor = cdCollar.Color.ToArgb();    //背景色を設定インスタンスへ設定
            }
        }
        //ファイルオープン処理
        private void reportOpenFire() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                           ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;
                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        //コンボボックスへ登録
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setcbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";
                }
            }
        }
        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                              sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);//より具体手的なエラーを出力
                }
            }
        }
        //保存ボタン
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }
        //開くボタン
        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFire();
        }
        //フォームが閉じたら呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理（シリアル化）
            var serializer = new XmlSerializer(typeof(Settings)); 
            using (var writer = XmlWriter.Create("setting.xml")) {
                serializer.Serialize(writer, setting);
            }

        }
    }
}

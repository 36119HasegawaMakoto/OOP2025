using System;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemDate> items;

        public Form1() {
            InitializeComponent();
            //�f�t�H���g
            bookmarks["�o��"] = "https://news.yahoo.co.jp/rss/topics/business.xml";
            bookmarks["�G���^��"] = "https://news.yahoo.co.jp/rss/topics/entertainment.xml";
            bookmarks["�X�|�[�c"] = "https://news.yahoo.co.jp/rss/topics/sports.xml";
            //�o�^
            foreach (var item in bookmarks) {
                tbUrl.Items.Add(item.Key);
            }
        }
        //�u�b�N�}�[�N�̃f�B�N�V���i���[
        private Dictionary<string, string> bookmarks = new Dictionary<string, string>();
        //�擾�{�^��
        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                try {
                    string xml = await hc.GetStringAsync(tbUrl.Text);
                    getUrl(xml);
                }
                //���C�ɓ���̔���
                catch (Exception) {
                    //���C�ɓ���̂��
                    foreach (var okini in bookmarks) {
                        if (tbUrl.Text == okini.Key) {
                            string xml = await hc.GetStringAsync(okini.Value);
                            getUrl(xml);
                        }
                    }
                }
            }
        }
        //�擾����
        private void getUrl(string xml) {
            XDocument xdoc = XDocument.Parse(xml);
            //RSS����͂��ĕK�v�ȗv�f���擾
            items = xdoc.Root.Descendants("item").Select(x => new ItemDate {
                Title = (string?)x.Element("title"),
                Link = (string?)x.Element("link"),
            }).ToList();
            //���X�g�{�b�N�X�Ƀ^�C�g����\��
            lbTitels.Items.Clear();
            items.ForEach(item => lbTitels.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));
        }
        //�^�C�g����I�������Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitels_Click(object sender, EventArgs e) {
            if ((lbTitels.SelectedItem != null) && lbTitels.SelectedIndex >= 0 && lbTitels.SelectedIndex < items.Count) {
                mvRssLink.Source = new Uri(items[lbTitels.SelectedIndex].Link);

            }
        }

        //�߂�
        private void btBack_Click(object sender, EventArgs e) {
            mvRssLink.GoBack();
        }
        //�i��
        private void btForward_Click(object sender, EventArgs e) {
            mvRssLink.GoForward();
        }
        //�u�O�}�o�^
        private void btBookmark_Click(object sender, EventArgs e) {
            if (tbBookMarkName.Text == "") {
                MessageBox.Show("���O����ā[�[�[�[�[");
                return;
            }
            //�o�^�ς݂��m�F
            if (!tbUrl.Items.Contains(tbBookMarkName.Text) && tbUrl.Text.Contains(".xml")) {
                bookmarks[tbBookMarkName.Text] = tbUrl.Text;
                tbUrl.Items.Add(tbBookMarkName.Text);
                MessageBox.Show("�o�^�ł�����");

                tbBookMarkName.Clear();
            } else {
                MessageBox.Show("URL���Ԉ���Ă邩���O������Ȃ�����");
            }
        }
        //�z�[���{�^��
        private void btHome_Click(object sender, EventArgs e) {
            mvRssLink.Source = new Uri("https://yahoo.co.jp");
        }
        //�}�X�N����
        private void GoFowerdbtEnableSet() {
            btBack.Enabled = mvRssLink.CanGoBack;
            btForward.Enabled = mvRssLink.CanGoForward;
        }
        //�}�X�N����
        private void mvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            GoFowerdbtEnableSet();
        }
        //�t�H�[�����[�h
        private void Form1_Load(object sender, EventArgs e) {
            GoFowerdbtEnableSet();
            lbTitels.DrawMode = DrawMode.OwnerDrawFixed;
        }
        //���C�ɓ���폜
        private void btDelete_Click(object sender, EventArgs e) {
            foreach (var dict in bookmarks) {
                if (dict.Key == tbBookMarkName.Text) {
                    tbUrl.Items.Remove(dict.Key);
                    MessageBox.Show($"{dict.Key}���폜���ꂽ��");
                    tbBookMarkName.Clear();
                    return;
                }
            }
            MessageBox.Show("���O��������Ȃ���");
            tbBookMarkName.Clear();
        }
        //�F�����݂ɕς�����
        private void lbTitels_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index < 0) return;
            // ��s�Ƌ����s�ŐF��ς���
            Color bgColor = (e.Index % 2 == 0) ? Color.LightGray : Color.White;
            // �w�i��h��Ԃ�
            using (SolidBrush bgBrush = new SolidBrush(bgColor)) {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }
            // �e�L�X�g�̐F
            Color textColor = Color.Black;
            // �I�𒆂̍��ڂ͐F��ς���
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                bgColor = SystemColors.Highlight;
                textColor = SystemColors.HighlightText;
                using (SolidBrush selBrush = new SolidBrush(bgColor)) {
                    e.Graphics.FillRectangle(selBrush, e.Bounds);
                }
            }
            // ���ڂ̃e�L�X�g���擾
            string text = lbTitels.Items[e.Index].ToString();
            // �e�L�X�g��`��
            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                e.Graphics.DrawString(text, e.Font, textBrush, e.Bounds.Left, e.Bounds.Top);
            }

        }
        //�����[�h
        private void btReroad_Click(object sender, EventArgs e) {
            if (mvRssLink.CoreWebView2 != null) {
                mvRssLink.Reload();
            }
        }
        //�I��
        private void endKey_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        //�F�ύX
        private void cdCorer_Click(object sender, EventArgs e) {
            if (cdCollar.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdCollar.Color;
            }
        }
    }
}


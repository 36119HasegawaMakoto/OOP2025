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
                //���C�ɓ���̔���
                catch (Exception) {
                    //���C�ɓ���̂��
                    foreach (var okini in bookmarks) {
                        if (tbUrl.Text == okini.Key) {
                            string xml = await hc.GetStringAsync(okini.Value);
                            XDocument xdoc = XDocument.Parse(xml);
                            items = xdoc.Root.Descendants("item").Select(x => new ItemDate {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                            lbTitels.Items.Clear();
                            items.ForEach(item => lbTitels.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));
                        }
                    }
                }
            }
        }
        //�^�C�g����I�������Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitels_Click(object sender, EventArgs e) {
            mvRssLink.Source = new Uri(items[lbTitels.SelectedIndex].Link);
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
            //�o�^�ς݂��m�F
            if (!tbUrl.Items.Contains(tbBookMarkName.Text)) {
                string name = tbBookMarkName.Text;
                string url = tbUrl.Text;
                bookmarks[name] = url;
                tbUrl.Items.Add(name);
                MessageBox.Show("�o�^�ł�����");

                tbBookMarkName.Clear();
            } else {
                MessageBox.Show("�Ⴄ���O�ɂ��Ă�");
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
        }
    }
}


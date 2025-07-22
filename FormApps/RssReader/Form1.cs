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
            //デフォルト
            bookmarks["経済"] = "https://news.yahoo.co.jp/rss/topics/business.xml";
            bookmarks["エンタメ"] = "https://news.yahoo.co.jp/rss/topics/entertainment.xml";
            bookmarks["スポーツ"] = "https://news.yahoo.co.jp/rss/topics/sports.xml";
            //登録
            foreach (var item in bookmarks) {
                tbUrl.Items.Add(item.Key);
            }
        }
        //ブックマークのディクショナリー
        private Dictionary<string, string> bookmarks = new Dictionary<string, string>();
        //取得ボタン
        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {
                try {
                    string xml = await hc.GetStringAsync(tbUrl.Text);
                    XDocument xdoc = XDocument.Parse(xml);
                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item").Select(x => new ItemDate {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link"),
                    }).ToList();
                    //リストボックスにタイトルを表示
                    lbTitels.Items.Clear();
                    items.ForEach(item => lbTitels.Items.Add(item.Title ?? "データなし"));
                }
                //お気に入りの判定
                catch (Exception) {
                    //お気に入りのやつ
                    foreach (var okini in bookmarks) {
                        if (tbUrl.Text == okini.Key) {
                            string xml = await hc.GetStringAsync(okini.Value);
                            XDocument xdoc = XDocument.Parse(xml);
                            items = xdoc.Root.Descendants("item").Select(x => new ItemDate {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                            lbTitels.Items.Clear();
                            items.ForEach(item => lbTitels.Items.Add(item.Title ?? "データなし"));
                        }
                    }
                }
            }
        }
        //タイトルを選択したときに呼ばれるイベントハンドラ
        private void lbTitels_Click(object sender, EventArgs e) {
            mvRssLink.Source = new Uri(items[lbTitels.SelectedIndex].Link);
        }

        //戻る
        private void btBack_Click(object sender, EventArgs e) {
            mvRssLink.GoBack();
        }
        //進む
        private void btForward_Click(object sender, EventArgs e) {
            mvRssLink.GoForward();
        }
        //ブグマ登録
        private void btBookmark_Click(object sender, EventArgs e) {
            //登録済みか確認
            if (!tbUrl.Items.Contains(tbBookMarkName.Text)) {
                string name = tbBookMarkName.Text;
                string url = tbUrl.Text;
                bookmarks[name] = url;
                tbUrl.Items.Add(name);
                MessageBox.Show("登録できたよ");

                tbBookMarkName.Clear();
            } else {
                MessageBox.Show("違う名前にしてね");
            }
        }
        //ホームボタン
        private void btHome_Click(object sender, EventArgs e) {
            mvRssLink.Source = new Uri("https://yahoo.co.jp");
        }
        //マスク処理
        private void GoFowerdbtEnableSet() {
            btBack.Enabled = mvRssLink.CanGoBack;
            btForward.Enabled = mvRssLink.CanGoForward;
        }
        //マスク処理
        private void mvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            GoFowerdbtEnableSet();
        }
        //フォームロード
        private void Form1_Load(object sender, EventArgs e) {
            GoFowerdbtEnableSet();
        }
    }
}


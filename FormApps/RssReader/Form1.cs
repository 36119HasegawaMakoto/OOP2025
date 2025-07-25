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
                    getUrl(xml);
                }
                //お気に入りの判定
                catch (Exception) {
                    //お気に入りのやつ
                    foreach (var okini in bookmarks) {
                        if (tbUrl.Text == okini.Key) {
                            string xml = await hc.GetStringAsync(okini.Value);
                            getUrl(xml);
                        }
                    }
                }
            }
        }
        //取得処理
        private void getUrl(string xml) {
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
        //タイトルを選択したときに呼ばれるイベントハンドラ
        private void lbTitels_Click(object sender, EventArgs e) {
            if ((lbTitels.SelectedItem != null) && lbTitels.SelectedIndex >= 0 && lbTitels.SelectedIndex < items.Count) {
                mvRssLink.Source = new Uri(items[lbTitels.SelectedIndex].Link);

            }
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
            if (tbBookMarkName.Text == "") {
                MessageBox.Show("名前入れてーーーーー");
                return;
            }
            //登録済みか確認
            if (!tbUrl.Items.Contains(tbBookMarkName.Text) && tbUrl.Text.Contains(".xml")) {
                bookmarks[tbBookMarkName.Text] = tbUrl.Text;
                tbUrl.Items.Add(tbBookMarkName.Text);
                MessageBox.Show("登録できたよ");

                tbBookMarkName.Clear();
            } else {
                MessageBox.Show("URLが間違ってるか名前がおんなじだよ");
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
            lbTitels.DrawMode = DrawMode.OwnerDrawFixed;
        }
        //お気に入り削除
        private void btDelete_Click(object sender, EventArgs e) {
            foreach (var dict in bookmarks) {
                if (dict.Key == tbBookMarkName.Text) {
                    tbUrl.Items.Remove(dict.Key);
                    MessageBox.Show($"{dict.Key}が削除されたよ");
                    tbBookMarkName.Clear();
                    return;
                }
            }
            MessageBox.Show("名前が見つからないよ");
            tbBookMarkName.Clear();
        }
        //色を交互に変えるやつ
        private void lbTitels_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index < 0) return;
            // 奇数行と偶数行で色を変える
            Color bgColor = (e.Index % 2 == 0) ? Color.LightGray : Color.White;
            // 背景を塗りつぶす
            using (SolidBrush bgBrush = new SolidBrush(bgColor)) {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }
            // テキストの色
            Color textColor = Color.Black;
            // 選択中の項目は色を変える
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                bgColor = SystemColors.Highlight;
                textColor = SystemColors.HighlightText;
                using (SolidBrush selBrush = new SolidBrush(bgColor)) {
                    e.Graphics.FillRectangle(selBrush, e.Bounds);
                }
            }
            // 項目のテキストを取得
            string text = lbTitels.Items[e.Index].ToString();
            // テキストを描画
            using (SolidBrush textBrush = new SolidBrush(textColor)) {
                e.Graphics.DrawString(text, e.Font, textBrush, e.Bounds.Left, e.Bounds.Top);
            }

        }
        //リロード
        private void btReroad_Click(object sender, EventArgs e) {
            if (mvRssLink.CoreWebView2 != null) {
                mvRssLink.Reload();
            }
        }
        //終了
        private void endKey_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        //色変更
        private void cdCorer_Click(object sender, EventArgs e) {
            if (cdCollar.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdCollar.Color;
            }
        }
    }
}


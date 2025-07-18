using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemDate> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {
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

        }

        //タイトルを選択したときに呼ばれるイベントハンドラ
        private void lbTitels_Click(object sender, EventArgs e) {
            int index = lbTitels.SelectedIndex;
            string selectedItem = lbTitels.Items[index].ToString();
            webView21.Source = new Uri(items[index].Link);

        }
    }
}


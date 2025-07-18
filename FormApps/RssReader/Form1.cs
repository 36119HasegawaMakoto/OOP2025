using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemDate> items;

        public Form1() {
            InitializeComponent();
        }

        private void btRssGet_Click(object sender, EventArgs e) {

            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);//rssの取得
                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item").Select(x => new ItemDate 
                                            { Title = (string)x.Element("title"), }).ToList();
                //リストボックスにタイトルを表示
                lbTitels.Items.Clear();
                foreach (var text in items) {
                    lbTitels.Items.Add(text.Title);

                }
            }
            
        }
    }
}

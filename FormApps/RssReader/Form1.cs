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
                XDocument xdoc = XDocument.Load(url);//rss�̎擾
                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item").Select(x => new ItemDate 
                                            { Title = (string)x.Element("title"), }).ToList();
                //���X�g�{�b�N�X�Ƀ^�C�g����\��
                lbTitels.Items.Clear();
                foreach (var text in items) {
                    lbTitels.Items.Add(text.Title);

                }
            }
            
        }
    }
}

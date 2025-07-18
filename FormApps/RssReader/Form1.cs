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
        //�擾�{�^��
        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {
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
                tbUrl.Items.Add(tbBookMarkName.Text);
            } else {
                MessageBox.Show("���O���d�����Ă��܂�");
            }
            

        }
    }
}


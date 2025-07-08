using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem
{
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e) {
            Close();
        }
        private void fmVersion_Load(object sender, EventArgs e) {
            var asm = Assembly.GetExecutingAssembly();
            var version = asm.GetName().Version;
            lbVersion.Text = string.Format($"{version?.Major}.{version?.Build}.{version?.Revision}");
        }
    }
}

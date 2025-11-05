using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise01_Wpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            string filepath = "走れメロス.txt";
            var text = new StringBuilder();
            using (var reader = new StreamReader(filepath)) {
                string read;
                while ((read = await reader.ReadLineAsync()) != null) {
                    text.AppendLine(read);
                }
            }
            textbox.Text = text.ToString();
        }
    }
}
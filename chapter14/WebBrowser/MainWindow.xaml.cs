using System.Net.Http;
using System.Security.Policy;
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
using System.Xml.Linq;

namespace WebBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            WebView.GoBack();
        }

        private void FowardButton_Click(object sender, RoutedEventArgs e) {
            WebView.GoForward();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e) {
            WebView.Source = new Uri(AddressBar.Text);
        }
    }
}
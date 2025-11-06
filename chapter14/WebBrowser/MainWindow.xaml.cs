using Microsoft.Web.WebView2.Core;
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
            InittializeAsync();
        }
        private async void InittializeAsync() {
            await WebView.EnsureCoreWebView2Async();

            WebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationString;
            WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }
        //読込完了したらプログレスバーを非表示
        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e) {
            LoadingBar.Visibility = Visibility.Collapsed;
            LoadingBar.IsIndeterminate = false;
        }
        //読込開始したらプログレスバーを表示
        private void CoreWebView2_NavigationString(object? sender, CoreWebView2NavigationStartingEventArgs e) {
            LoadingBar.Visibility = Visibility.Visible;
            LoadingBar.IsIndeterminate = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            if (WebView.CanGoBack) {
                WebView.GoBack();
            }                        
        }

        private void FowardButton_Click(object sender, RoutedEventArgs e) {
            if (WebView.CanGoForward) {
                WebView.GoForward();
            }            
        }

        private void GoButton_Click(object sender, RoutedEventArgs e) {
            WebView.Source = new Uri(AddressBar.Text);
        }
    }
}
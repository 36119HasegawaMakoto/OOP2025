using CustomerApp.Data;
using SQLite;
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
using System.IO;

namespace CustomerApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private byte[] selectedImageBytes;
        private List<Customer> _customer = new List<Customer>();
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
            CustomerList.ItemsSource = _customer;
        }

        private void Save_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameBox.Text,
                Address = AddresBox.Text,
                Phone = PhoneBox.Text,
                Picture = selectedImageBytes
            };
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase();
            CustomerList.ItemsSource = _customer;
        }

        private void Update_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerList.SelectedItem as Customer;
            if (selectedCustomer is null) return;

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();

                var customer = new Customer() {
                    Name = NameBox.Text,
                    Address = AddresBox.Text,
                    Phone = PhoneBox.Text,
                    Picture = selectedImageBytes ?? selectedCustomer.Picture
                };
                connection.Update(customer);

                ReadDatabase();
                CustomerList.ItemsSource = _customer;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            var item = CustomerList.SelectedItem as Customer;
            if (item != null) {
                //データベース接続
                using (var connection = new SQLiteConnection(App.databasePath)) {
                    connection.CreateTable<Customer>();
                    connection.Delete(item);    //データベースから選択されているレコードの削除
                    ReadDatabase();
                    CustomerList.ItemsSource = _customer;
                }
            }
        }
        
        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true) {
                var filePath = openFileDialog.FileName;
                selectedImageBytes = File.ReadAllBytes(filePath);

                // Imageコントロールに表示するためにBitmapImageに変換
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                PicturePreview.Source = bitmap;
            }
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                _customer = connection.Table<Customer>().ToList();
            }
        }
    }
}
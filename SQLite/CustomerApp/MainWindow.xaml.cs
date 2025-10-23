using CustomerApp.Data;
using SQLite;
using System.IO;
using System.Net.Http;
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
using System.Threading.Tasks;

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
        //保存ボタン
        private  void Save_Click(object sender, RoutedEventArgs e) {
            var name = NameBox.Text.Trim();
            var phone = PhoneBox.Text.Trim();
            var address = AddresBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name)) {
                MessageBox.Show("名前入力求");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                //既存データ確認
                var existing = connection.Table<Customer>()
                    .FirstOrDefault(c => c.Name == name);
                if (existing != null) {
                    MessageBox.Show("同名前既存在有");
                    return;
                }

                //登録
                var customer = new Customer() {
                    Name = NameBox.Text,
                    Address = AddresBox.Text,
                    Phone = PhoneBox.Text,
                    Picture = selectedImageBytes
                };
                connection.Insert(customer);
                ReadDatabase();
                CustomerList.ItemsSource = _customer;
                NameBox.Clear();
                PhoneBox.Clear();
                AddresBox.Clear();
                PicturePreview.Source = null;
                selectedImageBytes = null;
                PictureUrl.Clear();
            }
        }
        //更新ボタン
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
                NameBox.Clear();
                PhoneBox.Clear();
                AddresBox.Clear();
                PicturePreview.Source = null;
                selectedImageBytes = null;
                PictureUrl.Clear();
            }
        }
        //削除ボタン
        private void Delete_Click(object sender, RoutedEventArgs e) {
            var item = CustomerList.SelectedItem as Customer;
            if (item != null) {
                var result = MessageBox.Show("ほんとに消すよ！？", "マジで？", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes) {
                    //データベース接続
                    using (var connection = new SQLiteConnection(App.databasePath)) {
                        connection.CreateTable<Customer>();
                        connection.Delete(item);    //データベースから選択されているレコードの削除
                        ReadDatabase();
                        CustomerList.ItemsSource = _customer;
                    }
                }
            }
        }
        //画像洗濯
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
        //読込
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                _customer = connection.Table<Customer>().ToList();
            }
        }
        //リストボックス
        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerList.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameBox.Text = selectedCustomer.Name;
                PhoneBox.Text = selectedCustomer.Phone;
                AddresBox.Text = selectedCustomer.Address;

                PicturePreview.Source = selectedCustomer.PictureImage;
                selectedImageBytes = selectedCustomer.Picture;
            }
        }
        //URLから画像の取得
        private async void PictureUrlButton_Click(object sender, RoutedEventArgs e) {
            var imageUrl = PictureUrl.Text.Trim();
            if (string.IsNullOrEmpty(imageUrl)) {
                MessageBox.Show("画像URL入力求");
            }
            try {
                using (var client = new HttpClient()) {
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);
                    selectedImageBytes = imageBytes;
                    using (var ms = new MemoryStream(imageBytes)) {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = ms;
                        bitmap.EndInit();
                        PicturePreview.Source = bitmap;
                    }                   
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"画像を読み込めませんでした。\n{ex.Message}");
            }
        }
    }
}
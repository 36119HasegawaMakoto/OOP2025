using Sample.Data;
using SQLite;
using System.Collections.ObjectModel;
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

namespace Sample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<Person> _persons = new List<Person>();

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
            PersonListView.ItemsSource = _persons;
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                _persons = connection.Table<Person>().ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var person = new Person() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                connection.Insert(person);
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            ReadDatabase();
            PersonListView.ItemsSource = _persons;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = PersonListView.SelectedItem as Person;
            if (item != null) {
                //データベース接続
                using (var connection = new SQLiteConnection(App.databasePath)) {
                    connection.CreateTable<Person>();
                    connection.Delete(item);    //データベースから選択されているレコードの削除
                    ReadDatabase();
                    PersonListView.ItemsSource = _persons;
                }

            }
        }
        //リストビューのフィルタリング
        private void SerchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _persons.Where(x => x.Name.Contains(SerchTextBox.Text));
            PersonListView.ItemsSource = filterList;
        }

        private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = PersonListView.SelectedItem as Person;
            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
            }
        }

        private void UpdateButtun_Click(object sender, RoutedEventArgs e) {
            var selectedPerson = PersonListView.SelectedItem as Person;
            if (selectedPerson is null) return;

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();

                var person = new Person() {
                    Id = selectedPerson.Id,
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                };
                connection.Update(person);

                ReadDatabase();
                PersonListView.ItemsSource = _persons;
            }
        }
    }
}
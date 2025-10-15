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

namespace Sample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

    public MainWindow() {
        InitializeComponent();
        //ReadDatabase();
        _persons.Add(new Person { Id = 1, Name = "akldsfas", Phone = "aakga" });
        PersonListView.ItemsSource = _persons;
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            //_persons = connection.Table<Person>().ToList();
        }
    }

    private void Savebutton_Click(object sender, RoutedEventArgs e) {
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

       // ReadDatabase();
    }
}

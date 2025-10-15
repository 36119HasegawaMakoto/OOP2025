using System.Configuration;
using System.Data;
using System.Windows;

namespace Sample;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {
    static string databaseName = "Persons.db";
    static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
}


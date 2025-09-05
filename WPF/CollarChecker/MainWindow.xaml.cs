using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollarChecker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MyColor> stockColors = new ObservableCollection<MyColor>();
        public MainWindow()
        {
            InitializeComponent();
            stockList.ItemsSource = stockColors;  // ListBoxにバインド
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte r = (byte)rSlider.Value, g = (byte)gSlider.Value, b = (byte)bSlider.Value;
            // colorAreaの背景色を変更
            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void StockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value, g = (byte)gSlider.Value, b = (byte)bSlider.Value;
            Color color = Color.FromRgb(r, g, b);
            MyColor myColor = new MyColor {
                Color = color
            };
            stockColors.Add(myColor);
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}

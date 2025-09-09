using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace CollarChecker {
    public partial class MainWindow : Window {
        private ObservableCollection<MyColor> stockColors = new ObservableCollection<MyColor>();
        private MyColor[] allColors;
        public MainWindow() {
            InitializeComponent();
            allColors = GetColorList();
            stockList.ItemsSource = stockColors;  //バインド
            colorSelectComboBox.ItemsSource = GetColorList();
            colorSelectComboBox.ItemsSource = allColors;
        }
        //全部の色とってくる
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }
        //スライダー
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (colorArea == null) return;
            byte r = (byte)rSlider.Value, g = (byte)gSlider.Value, b = (byte)bSlider.Value;
            // colorAreaの背景色を変更
            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            //名前さがすよ
            Color searchcolor = Color.FromRgb(r, g, b);
            var match = allColors.FirstOrDefault(c => c.Color == searchcolor);
            if (!match.Equals(default(MyColor))) {
                //コンボボックスに名前を表示
                colorSelectComboBox.SelectedItem = match;
            } else {
                colorSelectComboBox.SelectedItem = null;
            }

        }
        //ストックボタンclick
        private void StockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value, g = (byte)gSlider.Value, b = (byte)bSlider.Value;
            Color color = Color.FromRgb(r, g, b);
            string name = "";
            if (colorSelectComboBox.SelectedItem is MyColor colorname) {
                // 選択されている色の名前を取得
                name = colorname.Name;
            }
            //重複あるかな
            if (!stockColors.Any(c => c.Color == color)) {
                stockColors.Add(new MyColor {
                    Color = color,
                    Name = name
                });
            }         
        }
        //コンボボックス
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedItem is MyColor colorrgb) {
                rSlider.Value = colorrgb.Color.R;
                gSlider.Value = colorrgb.Color.G;
                bSlider.Value = colorrgb.Color.B;
            }
        }
        //削除ボタン
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            if (stockList.SelectedItem != null) {
                var item = (MyColor)stockList.SelectedItem;
                stockColors.Remove(item);
            }
        }
        //反映ボタン
        private void RefrextButton_Click(object sender, RoutedEventArgs e) {
            if (stockList.SelectedItem != null) {
                var item = (MyColor)stockList.SelectedItem;
                rSlider.Value = item.Color.R;
                gSlider.Value = item.Color.G;
                bSlider.Value = item.Color.B;
            }
        }
    }
}

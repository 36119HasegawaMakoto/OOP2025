using SampleUnitConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitComberter {
    class MainWindowViewModel : ViewModel {
        //フィールド
        private double metricValue;
        private double imperialValue;

        //▲でおバレルコマンド
        public ICommand ImperialUnitToMetric { get; private set; }

        //▼で呼ばれる駒野づ
        public ICommand MetricUnitToImperial { get; private set; }

        //上のコンボボックスで線たっくされてう裸体
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のコンボボックスで選択されている値
        public ImperialUnit CurrentImperialUnit { get; set; }

        //プロパティ
        public double MetricValue {
            get => metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }

        }
        public double ImperialValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }

        }
        public MainWindowViewModel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();


            ImperialUnitToMetric = new DelegateCommand(
                () => MetricValue = 
                CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit, ImperialValue));

            MetricUnitToImperial = new DelegateCommand(
                () => MetricValue =
                CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, MetricValue));
        }
    }
}
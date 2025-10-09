using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    class DelegateCommand : ICommand {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        //コンストラクタ（引数一つ）
        public DelegateCommand(Action execute)
            : this(execute, () => true) { }

        //コンストラクタ（引数二つ）
        public DelegateCommand(Action execute, Func<bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter) {
            this.execute();
        }

        public bool CanExecute(object parameter) {
            return this.canExecute();
        }

        public event EventHandler CanExecuteChanged;
    }
}

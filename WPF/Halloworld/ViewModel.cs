using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halloworld {
    class ViewModel : BindableBase
        {
        public ViewModel(){
            ChangeMessageCommand = new DelegateCommand(
                () => GreetingMessage = "Bye-bye world");
            }
        private string _greetigMessage = "Hello World!";
        public string GreetingMessage {
            get=>_greetigMessage;
            set => SetProperty(ref _greetigMessage, value);
                
                
            //    {
            //    if (_greetigMessage != value) {
            //        _greetigMessage = value;
            //        PropertyChanged?.Invoke(
            //            this, new PropertyChangedEventArgs(nameof(GreetingMessage)));
            //    }
            //}
        } 
        public DelegateCommand ChangeMessageCommand { get; }
    }
}

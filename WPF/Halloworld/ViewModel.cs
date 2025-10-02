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
            ChangeMessageCommand = new DelegateCommand<string>(
                (par) => GreetingMessage = par);
            }
        private string _greetigMessage = "Hello World!";
        public string GreetingMessage {
            get=>_greetigMessage;
            set{
                if (SetProperty(ref _greetigMessage, value)) {
                    CanChangeMessage = false;
                }

            }                
                
            //    {
            //    if (_greetigMessage != value) {
            //        _greetigMessage = value;
            //        PropertyChanged?.Invoke(
            //            this, new PropertyChangedEventArgs(nameof(GreetingMessage)));
            //    }
            //}
        }
        private bool _canChangeMessage = true;
        public bool CanChangeMessage {
            get => _canChangeMessage;
            private set => SetProperty(ref _canChangeMessage, value);
        }

        public string NewMessage1 { get; } = "message1dayo-";
        public string NewMessage2 { get; } = "nikomenomessagedayo-";
        public DelegateCommand<string> ChangeMessageCommand { get; }
    }
}

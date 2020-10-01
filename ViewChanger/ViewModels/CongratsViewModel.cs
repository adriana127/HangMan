using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewChanger.Command;

namespace ViewChanger.ViewModels
{
    class CongratsViewModel:BaseViewModel
    {
        public CongratsViewModel()
        {
            Message = Properties.Settings.Default.message;
        }

        private string _message { get; set; }
        public string Message { get { return _message; } set { _message = value; OnPropertyChanged(nameof(Message)); } }

        public ICommand goToPopUpView
        {
            get { return new UpdateViewCommand(() => { MainViewModel.Instance.SelectedViewModel = new PopUpViewMode(); }); }
        }

    }
}

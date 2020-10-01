using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewChanger.Command;
using ViewChanger.Entities;
using ViewChanger.Services;

namespace ViewChanger.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private BaseViewModel activeView = new HomeViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return activeView; }
            set
            {
                activeView = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            Instance = this;
 
        }

        public static MainViewModel Instance { get; private set; }


    }
}

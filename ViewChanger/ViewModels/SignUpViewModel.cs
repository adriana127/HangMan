using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewChanger.Command;
using ViewChanger.Entities;
using ViewChanger.Services;

namespace ViewChanger.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        public ICommand goToHomeView
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    MainViewModel.Instance.SelectedViewModel = new HomeViewModel();
                });
            }
        }

        private bool canExecuteCommand = false;
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }


        private readonly List<string> _images;

        public SignUpViewModel()
        {
            _images = new List<string>();

            System.Collections.Generic.IEnumerable<String> lines = File.ReadLines("..\\..\\" +
                "Images.txt");
            foreach(string line in lines)
            {
                _images.Add(line);
            }
        }
        public string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));

                }
            }
        }
        public List<string> Images
        {
            get { return _images; }
        }
        public ICommand PreviousImage
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    CurrentImage = Images.SkipWhile(x => x != CurrentImage).Skip(1).DefaultIfEmpty(Images[0]).FirstOrDefault();
                    OnPropertyChanged(nameof(PreviousImage));

                });
            }
        }
        public ICommand NextImage
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    if (CurrentImage == Images.ElementAt(Images.Count() - 1))
                        CurrentImage = Images.ElementAt(0);
                   else  CurrentImage = Images.SkipWhile(x => x != CurrentImage).Skip(1).DefaultIfEmpty(Images[Images.Count()-1]).FirstOrDefault();
                    OnPropertyChanged(nameof(NextImage));

                });
            }
        }
        public string _currentImage { get; set; } = @"\images\1.png";
        public string CurrentImage
        {
            get { return _currentImage; }
            set
            {
                if (_currentImage != value)
                {
                    _currentImage = value;
                    OnPropertyChanged(nameof(CurrentImage));
                }
            }
        }
        public ICommand _playerToSave { get; set; }
        public ICommand SavePlayer
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\Players.txt", true))
                    {
                        file.WriteLine( UserName+" "+CurrentImage+" "+"-" + " "+"0" + " "  +"-" + " "+"-" + " " + "6" + " " + "0" + " " + "0"+" "+"-"+" "+"0");
                    }

                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\AllCategories.txt", true))
                    {
                        file.WriteLine(UserName + " " + CurrentImage + " " + "0" + " " + "0");
                    }

                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\Astronomy.txt", true))
                    {
                        file.WriteLine(UserName + " " + CurrentImage + " " + "0" + " " + "0");
                    }

                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\Animals.txt", true))
                    {
                        file.WriteLine(UserName + " " + CurrentImage + " " + "0" + " " + "0");
                    }

                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\Cars.txt", true))
                    {
                        file.WriteLine(UserName + " " + CurrentImage + " " + "0" + " " + "0");
                    }

                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\Movies.txt", true))
                    {
                        file.WriteLine(UserName + " " + CurrentImage + " " + "0" + " " + "0");
                    }

                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("..\\..\\Music.txt", true))
                    {
                        file.WriteLine(UserName + " " + CurrentImage + " " + "0" + " " + "0");
                    }
                    MainViewModel.Instance.SelectedViewModel = new HomeViewModel();
                    OnPropertyChanged(nameof(SavePlayer));

                });
            }
        }
    }
}
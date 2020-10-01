using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewChanger.Command;

namespace ViewChanger.ViewModels
{
    class PopUpViewMode:BaseViewModel
    {

        public PopUpViewMode()
        {
            if (Properties.Settings.Default.category == "-")
                AllowLoadgame = false;
            else
                AllowLoadgame = true;
        }
        public ICommand goHomeCommand
        {
            get
            {
                return new UpdateViewCommand(() => {
                    MainViewModel.Instance.SelectedViewModel = new HomeViewModel();
                });
            }
        }
        public ICommand LoadGame
        {
            get
            {
                return new UpdateViewCommand(()=> {
                    MainViewModel.Instance.SelectedViewModel = new GameViewModel();
                }
                );
            }
        }

        public bool _allowLoadGame { get; set; }
        public bool AllowLoadgame
        {
            set
            {
                _allowLoadGame = value;
                OnPropertyChanged(nameof(AllowLoadgame));
            }
            get
            {
                return _allowLoadGame;
            }
        }

        public ICommand NewGame
        {
            get
            {
                return new UpdateViewCommand(() => {


                    string name = Properties.Settings.Default.playerName;
                    string image = Properties.Settings.Default.imagePath;
                    string wins = Properties.Settings.Default.wins;
                    string losses = Properties.Settings.Default.losses;
                    string time = Properties.Settings.Default.time;

                    string updated_line = name + " " + image+" " + "-" + " " + "0" + " " + "-" + " " + "-" + " " + "6" + " " + wins + " " + losses + " " + "-"+" "+"0";




                    string tempFile = Path.GetTempFileName();

                    string line_to_delete = name + " " + image;
                    using (var sr = new StreamReader("..\\..\\Players.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                            else
                                sw.WriteLine(updated_line);
                        }
                    }

                    File.Delete("..\\..\\Players.txt");
                    File.Move(tempFile, "..\\..\\Players.txt");

                    MainViewModel.Instance.SelectedViewModel = new GameViewModel();

                }
                );
            }
        }
        public ICommand Statitics
        {
            get
            {
                return new UpdateViewCommand(() => {
                    MainViewModel.Instance.SelectedViewModel = new StatiticsViewModel();
                });
            }
        }
    }
}

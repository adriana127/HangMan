using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewChanger.Command;
using ViewChanger.Entities;
using ViewChanger.Services;

namespace ViewChanger.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public ICommand goToGameView
        {
            get
            {
                return new UpdateViewCommand(() =>
                {

                    Properties.Settings.Default.playerName =SelectedPlayer.Name;
                    Properties.Settings.Default.imagePath = SelectedPlayer.ImageId;
                    Properties.Settings.Default.labelContent = SelectedPlayer.Letters;
                    Properties.Settings.Default.typedLetters = SelectedPlayer.TypedLetters;
                    Properties.Settings.Default.wins = SelectedPlayer.Wins;
                    Properties.Settings.Default.losses = SelectedPlayer.Loses;
                    Properties.Settings.Default.time = SelectedPlayer.Time;
                    Properties.Settings.Default.category = SelectedPlayer.Category;
                    Properties.Settings.Default.Save();
                    MainViewModel.Instance.SelectedViewModel = new PopUpViewMode();
                });
            }
        }
        public ICommand goToSignUpView
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    MainViewModel.Instance.SelectedViewModel = new SignUpViewModel();
                });
            }
        }
        public Player Player { get; set; }

        private  ObservableCollection<Player> newPlayer;
        public HomeViewModel()
        {
            newPlayer = new ObservableCollection<Player>();
 
            string player="";
            string imageid = "";
            string lvl = "";
            string secretWord = "";
            string progress = "";
            string letters="";
            string category = "";
            string wins = "";
            string losses = "";
            string typedLetters = "";
            string time = "";


            System.Collections.Generic.IEnumerable<String> lines = File.ReadLines("..\\..\\Players.txt");

            for (int j = 0; j < lines.Count(); j++)

            {
                string[] playerElements = lines.ElementAt(j).Split(' ');
                int i = 1;
                foreach (string word in playerElements)
                {
                    if (i == 1)
                    {
                        player = word;
                    }
                    else if (i == 2)
                    {
                        imageid = word;
                    }
                    else if(i==3)
                    {
                        category = word;
                    }
                    else if (i ==4)
                    {
                        lvl = word;
                    }
                    else if (i == 5)
                    {
                        secretWord = word;
                    }
                    else if (i == 6)
                    {
                        letters = word;
                    }
                    else if (i == 7)
                    {
                        progress = word;
                    }
                    else if (i == 8)
                    {
                        wins = word;
                    }
                    else if (i == 9)
                    {
                        losses = word;
                    }
                    else if (i == 10)
                    {
                        typedLetters = word;
                    }
                    else if (i == 11)
                    {
                        time = word;
                    }
                    i++;
                }
                newPlayer.Add(new Player(player, imageid,category, lvl, secretWord, letters, progress,wins,losses,typedLetters,time));
            }
        }
        public ObservableCollection<Player> Players
        {
            set { newPlayer = value; OnPropertyChanged(nameof(Players)); }
            get { return newPlayer; }
        }
        private Player selectedPlayer { get; set; }
        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (selectedPlayer != value)
                {
                    selectedPlayer = value;
                    OnPropertyChanged(nameof(SelectedPlayer));
                    SelectedPImage = @selectedPlayer.ImageId;
                    EnablePlayButton = true;
                }
            }
        }
        private string _image { get; set; }
        public string SelectedPImage
        {
            get { return @_image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(SelectedPImage));
                }
            }
        }
        public bool direction = false;
        public ICommand NextPlayer
        {
            get
            {
                return new UpdateViewCommand(() =>
                {

                    SelectedPlayer = Players.SkipWhile(x => x != SelectedPlayer).Skip(1).DefaultIfEmpty(Players[0]).FirstOrDefault();
                    OnPropertyChanged(nameof(NextPlayer));
                });
            }
        }
        public ICommand PreviousPlayer
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
              
                    SelectedPlayer = Players.SkipWhile(x => x != SelectedPlayer).Skip(1).DefaultIfEmpty(Players[Players.Count()-1]).FirstOrDefault();
                    OnPropertyChanged(nameof(PreviousPlayer));
                });
            }
        }
        public ICommand DeletePlayer {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    string tempFile = Path.GetTempFileName();
                    string nume = SelectedPlayer.Name;
                    string cale = SelectedPlayer.ImageId;
                    string line_to_delete = nume + " " + cale;
                    using (var sr = new StreamReader("..\\..\\Players.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\Players.txt");
                    File.Move(tempFile, "..\\..\\Players.txt");

                    using (var sr = new StreamReader("..\\..\\AllCategories.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\AllCategories.txt");
                    File.Move(tempFile, "..\\..\\AllCategories.txt");

                    using (var sr = new StreamReader("..\\..\\Animals.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\Animals.txt");
                    File.Move(tempFile, "..\\..\\Animals.txt");

                    using (var sr = new StreamReader("..\\..\\Astronomy.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\Astronomy.txt");
                    File.Move(tempFile, "..\\..\\Astronomy.txt");

                    using (var sr = new StreamReader("..\\..\\Cars.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\Cars.txt");
                    File.Move(tempFile, "..\\..\\Cars.txt");

                    using (var sr = new StreamReader("..\\..\\Music.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\Music.txt");
                    File.Move(tempFile, "..\\..\\Music.txt");

                    using (var sr = new StreamReader("..\\..\\Movies.txt"))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(line_to_delete))
                                sw.WriteLine(line);
                        }
                    }
                    File.Delete("..\\..\\Movies.txt");
                    File.Move(tempFile, "..\\..\\Movies.txt");
                    newPlayer.Remove(SelectedPlayer);
                    OnPropertyChanged(nameof(DeletePlayer));
                });
            }
        }
        public bool _enableButon { get; set; }
        public bool EnablePlayButton
        {
            get { return _enableButon; }
            set
            {
                if (SelectedPlayer == null)
                {
                    _enableButon = false;
                }
                else _enableButon = true;
                OnPropertyChanged(nameof(EnablePlayButton));
            }
        }
    }
}

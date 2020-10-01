using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewChanger.Command;
using ViewChanger.Entities;

namespace ViewChanger.ViewModels
{
    class StatiticsViewModel:BaseViewModel
    {
        public ICommand goHomeCommand
        {
            get
            {
                return new UpdateViewCommand(() => {
                    MainViewModel.Instance.SelectedViewModel = new PopUpViewMode();
                });
            }
        }
        public PlayerStatitics Player { get; set; }

        private  ObservableCollection<PlayerStatitics> newPlayer;
        public StatiticsViewModel()
        {
            newPlayer = new ObservableCollection<PlayerStatitics>();

            string player = "";
            string imageid = "";
            string wins = "";
            string losses = "";


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
                    else if (i == 8)
                    {
                        wins = word;
                    }
                    else if (i ==9)
                    {
                        losses = word;
                    }

                    i++;
                    Console.WriteLine(word + "\t");
                }
                newPlayer.Add(new PlayerStatitics(player, imageid, wins, losses));

            }

        }
        public ObservableCollection<PlayerStatitics> Players
        {
            get 
            { return newPlayer; }
            set { 
                newPlayer = value;
                OnPropertyChanged("Players"); }
        }

        ICommand onButtonClickCommand;
        public ICommand CategorySelected
        {
            get
            {
                return onButtonClickCommand ??
          (onButtonClickCommand = new RelayCommand(DoSmth));
            }
        }

        private void DoSmth(object obj)
        {
            Players = new ObservableCollection<PlayerStatitics>();
            string player = "";
            string imageid = "";
            string wins = "";
            string losses = "";
            System.Collections.Generic.IEnumerable<String> lines = File.ReadLines("..\\..\\Players.txt");

            if (obj.ToString()=="All-categories")
            {
               lines = File.ReadLines("..\\..\\AllCategories.txt");

            }
            if (obj.ToString() == "Animals")
            {
                lines = File.ReadLines("..\\..\\Animals.txt");

            }
            if (obj.ToString() == "Astronomy")
            {
                lines = File.ReadLines("..\\..\\Astronomy.txt");

            }
            if (obj.ToString() == "Cars")
            {
                lines = File.ReadLines("..\\..\\Cars.txt");

            }
            if (obj.ToString() == "Movies")
            {
                lines = File.ReadLines("..\\..\\Movies.txt");

            }
            if (obj.ToString() == "Music")
            {
                lines = File.ReadLines("..\\..\\Music.txt");

            }

            for (int j = 0; j < lines.Count(); j++)

            {
                string[] playerElements = lines.ElementAt(j).Split(' ');
                int i = 1;
                foreach (string word in playerElements)
                {
                    if (i == 1)
                    {
                        Console.WriteLine("Player:");
                        player = word;
                    }
                    else if (i == 2)
                    {
                        imageid = word;
                    }
                    else if (i == 3)
                    {
                        wins = word;
                    }
                    else if (i == 4)
                    {
                        losses = word;
                    }
                    i++;
                }
                Players.Add(new PlayerStatitics(player, imageid, wins, losses));

            }
        }

        }
}

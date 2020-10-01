using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ViewChanger.Command;
using ViewChanger.Entities;

namespace ViewChanger.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        public ICommand goToHomeView
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    isTicking = false;
                    MainViewModel.Instance.SelectedViewModel = new HomeViewModel();
                });
            }
        }
        public ICommand Statitics
        {
            get
            {
                return new UpdateViewCommand(() =>
                {

                    MainViewModel.Instance.SelectedViewModel = new StatiticsViewModel();
                });
            }
        }
        public Player _currentPlayer;
        public List<string> _wordsToGuess;
        public string labelContent { get; set; } = "";
        public GameViewModel()
        {
            _categoryWords = new Categories();
            string playerName = Properties.Settings.Default.playerName;
            string image = Properties.Settings.Default.imagePath;
            System.Collections.Generic.IEnumerable<String> lines = File.ReadLines("..\\..\\Players.txt");
            foreach (string line in lines)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    _currentPlayer = new Player(playerName, image, playerElements.ElementAt(2), playerElements.ElementAt(3), playerElements.ElementAt(4), playerElements.ElementAt(5), playerElements.ElementAt(6), playerElements.ElementAt(7), playerElements.ElementAt(8), playerElements.ElementAt(9),playerElements.ElementAt(10));
                    break;
                }
            }
            LettersGuessed = _currentPlayer.Letters;
            TypedLetters = _currentPlayer.TypedLetters;
            Levels = _currentPlayer.Lvl;
            Progress = _currentPlayer.Progress;
            Wins = _currentPlayer.Wins;
            Losses = _currentPlayer.Loses;
            TimeSpent = _currentPlayer.Time;
            if (Levels == "0" && _currentPlayer.SecretWord == "-")
            {
                SelectedCategory = "All-categories";
            }
            else
            {
                SelectedCategory = _currentPlayer.Category;

                SecretWord = _currentPlayer.SecretWord;
            }

            _wordsToGuess = new List<string>();
            _wordsToGuess = CategoryWords.WordsGenerated(SelectedCategory, "easy");

            if (Levels == "0" && _currentPlayer.SecretWord == "-")
                SecretWord = _wordsToGuess.ElementAt(0);
            Text = SelectedCategory;
            for (int i = 0; i <= SecretWord.Count(); i++)

                labelContent = labelContent + "_ ";

            if (LettersGuessed != "-")
            {
                var aStringBuilder = new StringBuilder(LabelContent);
                for (int j = 0; j < LettersGuessed.Count(); j++)
                    for (int i = 0; i < SecretWord.Count(); i++)
                    {
                        if (SecretWord.ElementAt(i) == LettersGuessed.ElementAt(j))
                        {
                            aStringBuilder.Remove(i * 2+2, 1);
                            aStringBuilder.Insert(i * 2+2, LettersGuessed.ElementAt(j));
                        }
                    }
                LabelContent = aStringBuilder.ToString();
            }

            System.Collections.Generic.IEnumerable<String> hangs = File.ReadLines("..\\..\\HangMan.txt");
            _hangImages = new List<string>();
            foreach (string hang in hangs)
            {
                _hangImages.Add(hang);
            }
            HangMan = _hangImages.ElementAt(Int32.Parse(Progress));
            TimerStart();

            if (TypedLetters != "-")
            {
                for (int i = 0; i < TypedLetters.Count(); i++)
                {
                    if (TypedLetters.ElementAt(i) == 'q')
                        DisableButtonQ = false;
                    if (TypedLetters.ElementAt(i) == 'w')
                        DisableButtonW = false;
                    if (TypedLetters.ElementAt(i) == 'e')
                        DisableButtonE = false;
                    if (TypedLetters.ElementAt(i) == 'r')
                        DisableButtonR = false;
                    if (TypedLetters.ElementAt(i) == 't')
                        DisableButtonT = false;
                    if (TypedLetters.ElementAt(i) == 'y')
                        DisableButtonY = false;
                    if (TypedLetters.ElementAt(i) == 'u')
                        DisableButtonU = false;
                    if (TypedLetters.ElementAt(i) == 'i')
                        DisableButtonI = false;
                    if (TypedLetters.ElementAt(i) == 'o')
                        DisableButtonO = false;
                    if (TypedLetters.ElementAt(i) == 'p')
                        DisableButtonP = false;
                    if (TypedLetters.ElementAt(i) == 's')
                        DisableButtonS = false;
                    if (TypedLetters.ElementAt(i) == 'd')
                        DisableButtonD = false;
                    if (TypedLetters.ElementAt(i) == 'f')
                        DisableButtonF = false;
                    if (TypedLetters.ElementAt(i) == 'g')
                        DisableButtonG = false;
                    if (TypedLetters.ElementAt(i) == 'h')
                        DisableButtonH = false;
                    if (TypedLetters.ElementAt(i) == 'j')
                        DisableButtonJ = false;
                    if (TypedLetters.ElementAt(i) == 'k')
                        DisableButtonK = false;
                    if (TypedLetters.ElementAt(i) == 'l')
                        DisableButtonL = false;
                    if (TypedLetters.ElementAt(i) == 'z')
                        DisableButtonZ = false;
                    if (TypedLetters.ElementAt(i) == 'x')
                        DisableButtonX = false;
                    if (TypedLetters.ElementAt(i) == 'a')
                        DisableButtonA = false;
                    if (TypedLetters.ElementAt(i) == 'c')
                        DisableButtonC = false;
                    if (TypedLetters.ElementAt(i) == 'v')
                        DisableButtonV = false;
                    if (TypedLetters.ElementAt(i) == 'b')
                        DisableButtonB = false;
                    if (TypedLetters.ElementAt(i) == 'n')
                        DisableButtonN = false;
                    if (TypedLetters.ElementAt(i) == 'm')
                        DisableButtonM = false;
                }
            }
            isTicking = true;



            if (Progress == "5")
            { X1 = "X";}
            if (Progress == "4")
            { X1 = "X"; X2 = "X"; }

            if (Progress == "3")
            { X1 = "X"; X2 = "X"; X3 = "X"; }

            if (Progress == "2")
            { X1 = "X"; X2 = "X"; X3 = "X"; X4 = "X";}

            if (Progress == "1")
            { X1 = "X"; X2 = "X"; X3 = "X"; X4 = "X"; X5 = "X"; }

            if (Progress == "0")
            { X1 = "X"; X2 = "X"; X3 = "X"; X4 = "X"; X5 = "X"; X6 = "X"; }

            Name = _currentPlayer.Name;
            Image = _currentPlayer.ImageId;


            // citirea statisticilor din fisiere


            System.Collections.Generic.IEnumerable<String> linesAllCategories = File.ReadLines("..\\..\\AllCategories.txt");
            foreach (string line in linesAllCategories)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    AllCategoriesWins = playerElements.ElementAt(2);
                    AllCategoriesLosses = playerElements.ElementAt(3);
                    break;
                }
            }

            System.Collections.Generic.IEnumerable<String> linesAnimlas = File.ReadLines("..\\..\\Animals.txt");
            foreach (string line in linesAnimlas)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    AnimlasWins = playerElements.ElementAt(2);
                    AnimlasLosses = playerElements.ElementAt(3);
                    break;
                }
            }

            System.Collections.Generic.IEnumerable<String> linesAstronomy = File.ReadLines("..\\..\\Astronomy.txt");
            foreach (string line in linesAstronomy)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    AstronomyWins = playerElements.ElementAt(2);
                    AstronomyLosses= playerElements.ElementAt(3);
                    break;
                }
            }

            System.Collections.Generic.IEnumerable<String> linesCars = File.ReadLines("..\\..\\Cars.txt");
            foreach (string line in linesCars)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    CarssWins = playerElements.ElementAt(2);
                    CarssLosses = playerElements.ElementAt(3);
                    break;
                }
            }

            System.Collections.Generic.IEnumerable<String> linesMovies = File.ReadLines("..\\..\\Movies.txt");
            foreach (string line in linesMovies)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    MoviesWins = playerElements.ElementAt(2);
                    MoviesLosses = playerElements.ElementAt(3);
                    break;
                }
            }

            System.Collections.Generic.IEnumerable<String> linesMusic = File.ReadLines("..\\..\\Music.txt");
            foreach (string line in linesMusic)
            {
                if (line.Contains(playerName + " " + image))
                {
                    string[] playerElements = line.Split(' ');
                    MusicWins = playerElements.ElementAt(2);
                    MusicLosses = playerElements.ElementAt(3);
                    break;
                }
            }
            if (TypedLetters == "-")
            {
                count = 0;
            }
            else
                count = LettersGuessed.Count();
            increment = Int32.Parse(TimeSpent);
        }
        public string _name { get; set; }
        public string Name { get { return _name; } set { _name = value;OnPropertyChanged("Name"); } }
        public string _image { get; set; }
        public string Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }
        public string _selectedCategory { get; set; }
        public string SelectedCategory
        {
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
            get
            {
                return _selectedCategory;
            }
        }

        public string _lvls { get; set; }
        public string Levels
        {
            set
            {
                _lvls = value;
                OnPropertyChanged(nameof(Levels));
            }
            get
            {
                return _lvls;
            }
        }
        public string _timeSpent { get; set; }
        public string TimeSpent
        {
            set
            {
                _timeSpent = value;
                OnPropertyChanged(nameof(TimeSpent));
            }
            get
            {
                return _timeSpent;
            }
        }
        public string _typedLetters { get; set; }
        public string TypedLetters
        {
            set
            {
                _typedLetters = value;
                OnPropertyChanged(nameof(TypedLetters));
            }
            get
            {
                return _typedLetters;
            }
        }

        public string _lettersGuessed;
        public string LettersGuessed
        {
            get { return _lettersGuessed; }
            set
            {
                _lettersGuessed = value;
                OnPropertyChanged(nameof(LettersGuessed));
            }
        }

        public string _secretWord { get; set; }
        public string SecretWord
        {
            get { return _secretWord; }
            set
            {
                _secretWord = value;
                OnPropertyChanged(nameof(SecretWord));
            }
        }

        public string _progress { get; set; } // aici cate "vieti" mai are
        public string Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string _wins { get; set; }
        public string Wins
        {
            get { return _wins; }
            set
            {
                _wins = value;
                OnPropertyChanged(nameof(Wins));
            }
        }
        public string _loses { get; set; }
        public string Losses
        {
            get { return _loses; }
            set
            {
                _loses = value;
                OnPropertyChanged(nameof(Losses));
            }
        }
        public void UpdatePlayerInformation()
        {
            _currentPlayer.Category = SelectedCategory;

            _currentPlayer.Lvl = Levels;
            _currentPlayer.Letters = LettersGuessed;
            _currentPlayer.SecretWord = SecretWord;
            _currentPlayer.Progress = Progress;
            _currentPlayer.Wins = Wins;
            _currentPlayer.Loses = Losses;
            _currentPlayer.Time = Time;
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + SelectedCategory + " " + Levels +
                     " " + SecretWord + " " + LettersGuessed + " " + Progress + " " + Wins + " " + Losses + " " + TypedLetters+" "+Time;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
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

        }
        private string _allCategoriesWins { get; set; }
        private string _astronomyWins { get; set; }
        private string _animlasWins { get; set; }
        private string _carssWins { get; set; }
        private string _moviesWins { get; set; }
        private string _musicWins { get; set; }

        private string _allCategoriesLosses { get; set; }
        private string _astronomyLosses { get; set; }
        private string _animlasLosses { get; set; }
        private string _carssLosses { get; set; }
        private string _moviesLosses { get; set; }
        private string _musicLosses { get; set; }

        public void UpdateAllCategoriesStatistics()
        {
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + AllCategoriesWins + " " + AllCategoriesLosses ;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
            using (var sr = new StreamReader("..\\..\\AllCategories.txt"))
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

            File.Delete("..\\..\\AllCategories.txt");
            File.Move(tempFile, "..\\..\\AllCategories.txt");
        }
        public void UpdateAstronomyStatistics()
        {
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + AstronomyWins + " " + AstronomyLosses;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
            using (var sr = new StreamReader("..\\..\\Astronomy.txt"))
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

            File.Delete("..\\..\\Astronomy.txt");
            File.Move(tempFile, "..\\..\\Astronomy.txt");
        }
        public void UpdateAnimalsStatistics()
        {
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + AnimlasWins + " " + AnimlasLosses;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
            using (var sr = new StreamReader("..\\..\\Animals.txt"))
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

            File.Delete("..\\..\\Animals.txt");
            File.Move(tempFile, "..\\..\\Animals.txt");
        }
        public void UpdateCarsStatistics()
        {
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + CarssWins + " " + CarssLosses;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
            using (var sr = new StreamReader("..\\..\\Cars.txt"))
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

            File.Delete("..\\..\\Cars.txt");
            File.Move(tempFile, "..\\..\\Cars.txt");
        }
        public void UpdateMoviesStatistics()
        {
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + MoviesWins + " " + MoviesLosses;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
            using (var sr = new StreamReader("..\\..\\Movies.txt"))
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

            File.Delete("..\\..\\Movies.txt");
            File.Move(tempFile, "..\\..\\Movies.txt");
        }
        public void UpdateMusicStatistics()
        {
            string updated_line = _currentPlayer.Name + " " + _currentPlayer.ImageId + " " + MusicWins + " " + MusicLosses;
            string tempFile = Path.GetTempFileName();
            string line_to_delete = _currentPlayer.Name + " " + _currentPlayer.ImageId;
            using (var sr = new StreamReader("..\\..\\Music.txt"))
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

            File.Delete("..\\..\\Music.txt");
            File.Move(tempFile, "..\\..\\Music.txt");
        }
        public void HideWord()
        {
            for (int i = 0; i <= SecretWord.Count(); i++)

                LabelContent = LabelContent + "_ ";
        }
        public void ResestGame()
        {
            LettersGuessed = "-";
            count = 0;
            WordsToGuess = new List<string>();
            WordsToGuess = CategoryWords.WordsGenerated(SelectedCategory, "easy");
            SecretWord = WordsToGuess.ElementAt(Int32.Parse(Levels));
            Progress = "6";
            LabelContent = "";
            Text = SelectedCategory;
            TypedLetters = "-";
            TimeSpent = "0";
            DisableButtonQ = true;
            DisableButtonW = true;
            DisableButtonE = true;
            DisableButtonR = true;
            DisableButtonT = true;
            DisableButtonY = true;
            DisableButtonU = true;
            DisableButtonI = true;
            DisableButtonO = true;
            DisableButtonP = true;
            DisableButtonS = true;
            DisableButtonD = true;
            DisableButtonF = true;
            DisableButtonG = true;
            DisableButtonH = true;
            DisableButtonJ = true;
            DisableButtonK = true;
            DisableButtonL = true;
            DisableButtonZ = true;
            DisableButtonX = true;
            DisableButtonA = true;
            DisableButtonC = true;
            DisableButtonV = true;
            DisableButtonB = true;
            DisableButtonN = true;
            DisableButtonM = true;
            X1 = "";
            X2 = "";
            X3 = "";
            X4 = "";
            X5 = "";
            X6 = "";


        }

        public ICommand NewGame
        {
            get
            {
                return new UpdateViewCommand(() =>
                    {
                    SelectedCategory = "All-categories";

                    ResestGame();
                    increment = Int32.Parse(TimeSpent);
                        Levels = "0";
                        UpdatePlayerInformation();
                        OnPropertyChanged(nameof(NewGame));
                        HideWord();
                    });
            }
        }
        public ICommand SaveGame
        {
            get
            {
                return new UpdateViewCommand(() =>
                {
                    UpdatePlayerInformation();
                });
            }
        }
        public string LabelContent
        {
            set
            {
                labelContent = value;
                OnPropertyChanged(nameof(LabelContent));
            }
            get
            {
                return labelContent;
            }
        }

        public List<string> WordsToGuess { get { return _wordsToGuess; } set { _wordsToGuess = value; } }
        public Player SelectedPlayer
        {
            get { return _currentPlayer; }
        }
        public string SelectedPImage
        {
            get { return @SelectedPlayer.ImageId; }
        }
        public Categories _categoryWords { get; set; }
        public Categories CategoryWords
        {
            get { return _categoryWords; }
            set { _categoryWords = value; }

        }

        public List<string> _hangImages;
        public string _hangMan { get; set; }
        public string HangMan
        {
            get { return _hangMan; }
            set
            {
                _hangMan = value;
                OnPropertyChanged(nameof(HangMan));
            }
        }
        ICommand setCategoryCommand;
        public ICommand SetCategory
        {
            get
            {
                return setCategoryCommand ??
          (setCategoryCommand = new RelayCommand(PrepareNewCategoryChanges));
            }
        }
        private void PrepareNewCategoryChanges(object obj)
        {
            WordsToGuess = CategoryWords.WordsGenerated(obj.ToString(), "easy");
            Levels = "0";
            SelectedCategory = CategoryWords.Category;
            ResestGame();
            HideWord();
            increment = 0;
            isTicking = true;
            UpdatePlayerInformation();
        }
        ICommand onButtonClickCommand;
        public ICommand OnButtonClickCommand
        {
            get
            {
                return onButtonClickCommand ??
          (onButtonClickCommand = new RelayCommand(DoSmth));
            }
        }
        public int count = 0;

        private void TimerStart()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += TickIncrease;
            dt.Start();
        }
        public int increment ;
        public string _time { get; set; }
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }
        public bool isTicking;
        private void TickIncrease(object sender, EventArgs e)
        {
            if (isTicking)
            {
                if (increment < 30)
                {
                    increment++;

                    Time = increment.ToString();
                }
                else
                {
                    increment = 0;
                    MessageBox.Show("Joc Pierdut!");
                    Losses = (Int32.Parse(Losses) + 1).ToString();
                    LabelContent = SecretWord;
                    Levels = "0";
                    UpdatePlayerInformation();
                    isTicking = false;
                }
            }
        }

        public string _x1 { get; set; }
        public string _x2 { get; set; }
        public string _x3 { get; set; }
        public string _x4 { get; set; }
        public string _x5 { get; set; }
        public string _x6 { get; set; }

        public string X1 { get { return _x1; } set { _x1 = value; OnPropertyChanged("X1"); } }
        public string X2 { get { return _x2; } set { _x2 = value; OnPropertyChanged("X2"); } }
        public string X3 { get { return _x3; } set { _x3 = value; OnPropertyChanged("X3"); } }
        public string X4 { get { return _x4; } set { _x4 = value; OnPropertyChanged("X4"); } }
        public string X5 { get { return _x5; } set { _x5 = value; OnPropertyChanged("X5"); } }
        public string X6 { get { return _x6; } set { _x6 = value; OnPropertyChanged("X6"); } }


        private void DoSmth(object obj)
        {
            if (TypedLetters.Contains(char.Parse(obj.ToString())) != true)
            {
                if (obj.ToString() == "q")
                    DisableButtonQ = false;
                if (obj.ToString() == "w")
                    DisableButtonW = false;
                if (obj.ToString() == "e")
                    DisableButtonE = false;
                if (obj.ToString() == "r")
                    DisableButtonR = false;
                if (obj.ToString() == "t")
                    DisableButtonT = false;
                if (obj.ToString() == "y")
                    DisableButtonY = false;
                if (obj.ToString() == "u")
                    DisableButtonU = false;
                if (obj.ToString() == "i")
                    DisableButtonI = false;
                if (obj.ToString() == "o")
                    DisableButtonO = false;
                if (obj.ToString() == "p")
                    DisableButtonP = false;
                if (obj.ToString() == "s")
                    DisableButtonS = false;
                if (obj.ToString() == "d")
                    DisableButtonD = false;
                if (obj.ToString() == "f")
                    DisableButtonF = false;
                if (obj.ToString() == "g")
                    DisableButtonG = false;
                if (obj.ToString() == "h")
                    DisableButtonH = false;
                if (obj.ToString() == "j")
                    DisableButtonJ = false;
                if (obj.ToString() == "k")
                    DisableButtonK = false;
                if (obj.ToString() == "l")
                    DisableButtonL = false;
                if (obj.ToString() == "z")
                    DisableButtonZ = false;
                if (obj.ToString() == "x")
                    DisableButtonX = false;
                if (obj.ToString() == "a")
                    DisableButtonA = false;
                if (obj.ToString() == "c")
                    DisableButtonC = false;
                if (obj.ToString() == "v")
                    DisableButtonV = false;
                if (obj.ToString() == "b")
                    DisableButtonB = false;
                if (obj.ToString() == "n")
                    DisableButtonN = false;
                if (obj.ToString() == "m")
                    DisableButtonM = false;
                if (TypedLetters == "-")
                    TypedLetters = obj.ToString();
                else TypedLetters = TypedLetters + obj.ToString();
                bool ok = false;
                var aStringBuilder = new StringBuilder(LabelContent);
                for (int i = 0; i < SecretWord.Count(); i++)
                {
                    if (SecretWord.ElementAt(i).ToString() == obj.ToString())
                    {
                        aStringBuilder.Remove(i * 2+2, 1);
                        aStringBuilder.Insert(i * 2+2, char.Parse(obj.ToString()));
                        ok = true;
                        count++;
                    }
                }
                LabelContent = aStringBuilder.ToString();

                if (count == SecretWord.Count())
                {

                    if (Levels == "4")
                    {
                        MessageBox.Show("Joc Castigat!");
                        Wins = (Int32.Parse(Wins) + 1).ToString();
                        SecretWord = WordsToGuess.ElementAt(Int32.Parse(Levels));
                        if (SelectedCategory == "All-categories") { AllCategoriesWins = (Int32.Parse(AllCategoriesWins) + 1).ToString();UpdateAllCategoriesStatistics(); }
                        if (SelectedCategory == "Animals") { AnimlasWins = (Int32.Parse(AnimlasWins) + 1).ToString(); UpdateAnimalsStatistics(); }
                        if (SelectedCategory == "Astronomy") { AstronomyWins = (Int32.Parse(AstronomyWins) + 1).ToString(); UpdateAstronomyStatistics(); }
                        if (SelectedCategory == "Music") { MusicWins = (Int32.Parse(MusicWins) + 1).ToString(); UpdateMusicStatistics(); }
                        if (SelectedCategory == "Movies") { MoviesWins = (Int32.Parse(MoviesWins) + 1).ToString(); UpdateMoviesStatistics(); }
                        if (SelectedCategory == "Cars") { CarssWins = (Int32.Parse(CarssWins) + 1).ToString(); UpdateCarsStatistics(); }
                        isTicking = false;
                        // ResestGame();
                        SelectedCategory = "-";
                        Properties.Settings.Default.category = SelectedPlayer.Category;
                        Properties.Settings.Default.message = "Congrats, " + Name + "!";
                        Properties.Settings.Default.Save();
                        Levels = "0";
                        MainViewModel.Instance.SelectedViewModel = new CongratsViewModel();

                        UpdatePlayerInformation();

                    }
                    else
                    {
                        Levels = (Int32.Parse(Levels) + 1).ToString();
                        MessageBox.Show("Cuvant Ghicit!");
                        ResestGame();
                        SecretWord = WordsToGuess.ElementAt(Int32.Parse(Levels));
                        HideWord();
                        increment = Int32.Parse(TimeSpent);

                    }
                }
                else
                {
                    if (ok == false)
                    {
                        MessageBox.Show("Wrong letter");
                        Progress = (Int32.Parse(Progress) - 1).ToString();
                        if (Progress == "0")
                        {
                            MessageBox.Show("Joc Pierdut!");
                            Losses = (Int32.Parse(Losses) + 1).ToString();
                            LabelContent = SecretWord;
                            Levels = "0";
                            isTicking = false;
                            if (SelectedCategory == "All-categories") { AllCategoriesLosses = (Int32.Parse(AllCategoriesLosses) + 1).ToString(); UpdateAllCategoriesStatistics(); }
                            if (SelectedCategory == "Animals") { AnimlasLosses = (Int32.Parse(AnimlasLosses) + 1).ToString(); UpdateAnimalsStatistics(); }
                            if (SelectedCategory == "Astronomy") { AstronomyLosses = (Int32.Parse(AstronomyLosses) + 1).ToString(); UpdateAstronomyStatistics(); }
                            if (SelectedCategory == "Music") { MusicLosses = (Int32.Parse(MusicLosses) + 1).ToString(); UpdateMusicStatistics(); }
                            if (SelectedCategory == "Movies") { MoviesLosses = (Int32.Parse(MoviesLosses) + 1).ToString(); UpdateMoviesStatistics(); }
                            if (SelectedCategory == "Cars") { CarssLosses = (Int32.Parse(CarssLosses) + 1).ToString(); UpdateCarsStatistics(); }
                            SelectedCategory = "-";
                            Properties.Settings.Default.category = SelectedPlayer.Category;
                            Properties.Settings.Default.message = "You lost, " + Name + "!";
                            Properties.Settings.Default.Save();
                            UpdatePlayerInformation();

                            MainViewModel.Instance.SelectedViewModel = new CongratsViewModel();
                        }
                    }
                    if (ok == true)
                    {
                        if (LettersGuessed == "-")
                            LettersGuessed = obj.ToString();
                        else LettersGuessed = LettersGuessed + obj.ToString();
                    }
                }
                if (Progress == "5")
                    X1 = "X";
                if (Progress == "4")
                    X2 = "X";
                if (Progress == "3")
                    X3 = "X";
                if (Progress == "2")
                    X4 = "X";
                if (Progress == "1")
                    X5 = "X";
                if (Progress == "0")
                    X6 = "X";
                HangMan = _hangImages.ElementAt(Int32.Parse(Progress));
            }

        }
        public string _text { get; set; } = "";
        public string Text { get { return _text; } set { _text = value; OnPropertyChanged("Text"); } }
        public bool _disableButtonQ { get; set; } = true;
        public bool DisableButtonQ
        {
            get { return _disableButtonQ; }
            set
            {
                _disableButtonQ = value;
                OnPropertyChanged(nameof(DisableButtonQ));
            }
        }
        public bool _disableButtonW { get; set; } = true;
        public bool DisableButtonW
        {
            get { return _disableButtonW; }
            set
            {
                _disableButtonW = value;
                OnPropertyChanged(nameof(DisableButtonW));
            }
        }
        public bool _disableButtonE { get; set; } = true;
        public bool DisableButtonE
        {
            get { return _disableButtonE; }
            set
            {
                _disableButtonE = value;
                OnPropertyChanged(nameof(DisableButtonE));
            }
        }

        public bool _disableButtonR { get; set; } = true;
        public bool DisableButtonR
        {
            get { return _disableButtonR; }
            set
            {
                _disableButtonR = value;
                OnPropertyChanged(nameof(DisableButtonR));
            }
        }

        public bool _disableButtonT { get; set; } = true;
        public bool DisableButtonT
        {
            get { return _disableButtonT; }
            set
            {
                _disableButtonT = value;
                OnPropertyChanged(nameof(DisableButtonT));
            }
        }
        public bool _disableButtonY { get; set; } = true;
        public bool DisableButtonY
        {
            get { return _disableButtonY; }
            set
            {
                _disableButtonY = value;
                OnPropertyChanged(nameof(DisableButtonY));
            }
        }

        public bool _disableButtonU { get; set; } = true;
        public bool DisableButtonU
        {
            get { return _disableButtonU; }
            set
            {
                _disableButtonU = value;
                OnPropertyChanged(nameof(DisableButtonU));
            }
        }

        public bool _disableButtonI { get; set; } = true;
        public bool DisableButtonI
        {
            get { return _disableButtonI; }
            set
            {
                _disableButtonI = value;
                OnPropertyChanged(nameof(DisableButtonI));
            }
        }

        public bool _disableButtonO { get; set; } = true;
        public bool DisableButtonO
        {
            get { return _disableButtonO; }
            set
            {
                _disableButtonO = value;
                OnPropertyChanged(nameof(DisableButtonO));
            }
        }

        public bool _disableButtonP { get; set; } = true;
        public bool DisableButtonP
        {
            get { return _disableButtonP; }
            set
            {
                _disableButtonP = value;
                OnPropertyChanged(nameof(DisableButtonP));
            }
        }
        public bool _disableButtonL { get; set; } = true;
        public bool DisableButtonL
        {
            get { return _disableButtonL; }
            set
            {
                _disableButtonL = value;
                OnPropertyChanged(nameof(DisableButtonL));
            }
        }
        public bool _disableButtonK { get; set; } = true;
        public bool DisableButtonK
        {
            get { return _disableButtonK; }
            set
            {
                _disableButtonK = value;
                OnPropertyChanged(nameof(DisableButtonK));
            }
        }
        public bool _disableButtonJ { get; set; } = true;
        public bool DisableButtonJ
        {
            get { return _disableButtonJ; }
            set
            {
                _disableButtonJ = value;
                OnPropertyChanged(nameof(DisableButtonJ));
            }
        }
        public bool _disableButtonH { get; set; } = true;
        public bool DisableButtonH
        {
            get { return _disableButtonH; }
            set
            {
                _disableButtonH = value;
                OnPropertyChanged(nameof(DisableButtonH));
            }
        }
        public bool _disableButtonG { get; set; } = true;
        public bool DisableButtonG
        {
            get { return _disableButtonG; }
            set
            {
                _disableButtonG = value;
                OnPropertyChanged(nameof(DisableButtonG));
            }
        }
        public bool _disableButtonF { get; set; } = true;
        public bool DisableButtonF
        {
            get { return _disableButtonF; }
            set
            {
                _disableButtonF = value;
                OnPropertyChanged(nameof(DisableButtonF));
            }
        }
        public bool _disableButtonD { get; set; } = true;
        public bool DisableButtonD
        {
            get { return _disableButtonD; }
            set
            {
                _disableButtonD = value;
                OnPropertyChanged(nameof(DisableButtonD));
            }
        }
        public bool _disableButtonS { get; set; } = true;
        public bool DisableButtonS
        {
            get { return _disableButtonS; }
            set
            {
                _disableButtonS = value;
                OnPropertyChanged(nameof(DisableButtonS));
            }
        }
        public bool _disableButtonA { get; set; } = true;
        public bool DisableButtonA
        {
            get { return _disableButtonA; }
            set
            {
                _disableButtonA = value;
                OnPropertyChanged(nameof(DisableButtonA));
            }
        }
        public bool _disableButtonX { get; set; } = true;
        public bool DisableButtonX
        {
            get { return _disableButtonX; }
            set
            {
                _disableButtonX = value;
                OnPropertyChanged(nameof(DisableButtonX));
            }
        }
        public bool _disableButtonC { get; set; } = true;
        public bool DisableButtonC
        {
            get { return _disableButtonC; }
            set
            {
                _disableButtonC = value;
                OnPropertyChanged(nameof(DisableButtonC));
            }
        }
        public bool _disableButtonZ { get; set; } = true;
        public bool DisableButtonZ
        {
            get { return _disableButtonZ; }
            set
            {
                _disableButtonZ = value;
                OnPropertyChanged(nameof(DisableButtonZ));
            }
        }
        public bool _disableButtonV { get; set; } = true;
        public bool DisableButtonV
        {
            get { return _disableButtonV; }
            set
            {
                _disableButtonV = value;
                OnPropertyChanged(nameof(DisableButtonV));
            }
        }
        public bool _disableButtonB { get; set; } = true;
        public bool DisableButtonB
        {
            get { return _disableButtonB; }
            set
            {
                _disableButtonB = value;
                OnPropertyChanged(nameof(DisableButtonB));
            }
        }
        public bool _disableButtonN { get; set; } = true;
        public bool DisableButtonN
        {
            get { return _disableButtonN; }
            set
            {
                _disableButtonN = value;
                OnPropertyChanged(nameof(DisableButtonN));
            }
        }
        public bool _disableButtonM { get; set; } = true;
        public bool DisableButtonM
        {
            get { return _disableButtonM; }
            set
            {
                _disableButtonM = value;
                OnPropertyChanged(nameof(DisableButtonM));
            }
        }

        public string AllCategoriesWins { get => _allCategoriesWins; set => _allCategoriesWins = value; }
        public string AstronomyWins { get => _astronomyWins; set => _astronomyWins = value; }
        public string AnimlasWins { get => _animlasWins; set => _animlasWins = value; }
        public string CarssWins { get => _carssWins; set => _carssWins = value; }
        public string MoviesWins { get => _moviesWins; set => _moviesWins = value; }
        public string MusicWins { get => _musicWins; set => _musicWins = value; }
        public string AllCategoriesLosses { get => _allCategoriesLosses; set => _allCategoriesLosses = value; }
        public string AstronomyLosses { get => _astronomyLosses; set => _astronomyLosses = value; }
        public string AnimlasLosses { get => _animlasLosses; set => _animlasLosses = value; }
        public string CarssLosses { get => _carssLosses; set => _carssLosses = value; }
        public string MoviesLosses { get => _moviesLosses; set => _moviesLosses = value; }
        public string MusicLosses { get => _musicLosses; set => _musicLosses = value; }
    }
}
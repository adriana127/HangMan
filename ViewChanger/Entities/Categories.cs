using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewChanger.Services;

namespace ViewChanger.Entities
{
    class Categories : INotifyPropertyChanged
    {
        private string _category;
        private string _lvl;
        private List<string> _words;

       public Categories() { }



        public List<string> WordsGenerated(string category,string lvl)
        {
            _words = new List<string>();
            UInt16 a=0;
            if (lvl == "Easy")
                a = 0;
            else if (lvl == "Medium")
                a = 1;
            else if (lvl == "Hard")
                a = 2;
            WordsGenerator aux = new WordsGenerator();
            Category = category;
            if (_category == "Movies")
                _words.AddRange(WordsGenerator.Instance.MoviesWords());
            else if (_category == "Cars")
                _words.AddRange(WordsGenerator.Instance.CarsWords());
            else if (_category == "Animals")
                _words.AddRange(WordsGenerator.Instance.AnimalsWords());
            else if (_category == "Astronomy")
                _words.AddRange(WordsGenerator.Instance.AstronomyWords());
            else if (_category == "Music")
                _words.AddRange(WordsGenerator.Instance.MusicWords());
            else if (_category == "All-categories")
                _words.AddRange(WordsGenerator.Instance.AllWords());

            Random rng = new Random();
            int n = _words.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
               string value = _words[k];
                _words[k] = _words[n];
                _words[n] = value;
            }

            return _words;
        }

        public string Category { get => _category; set { _category = value; OnPropertyChanged("Category"); } }
        public string Lvl { get => _lvl; set => _lvl = value; }
        public List<string> Words { get => _words; set => _words = value; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

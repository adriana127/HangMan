using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Entities
{
    public class Player : INotifyPropertyChanged
    {
        private string _name;
        private string _imageId;
        private string _category;
        private string _lvl;
        private string _secretWord;
        private string _letters;
        private string _progress; // aici cate "vieti" mai are
        private string _wins;
        private string _loses;
        private string _typedLetters;
        private string _time;


        public Player() { }

        public Player(string name, string imageId, string category, string lvl, string secretWord, string letters, string progress, string wins, string loses, string typedLetters,string time)
        {
            _name = name;
            _imageId = imageId;
            _category = category;
            _lvl = lvl;
            _secretWord = secretWord;
            _letters = letters;
            _progress = progress;
            _wins = wins;
            _loses = loses;
            _typedLetters = typedLetters;
            _time = time;
        }

        public string Name { get => _name; set => _name = value; }
        public string ImageId { get => _imageId; set => _imageId = value; }
        public string Category { get => _category; set => _category = value; }
        public string Lvl { get => _lvl; set => _lvl = value; }
        public string SecretWord { get => _secretWord; set => _secretWord = value; }
        public string Letters { get => _letters; set => _letters = value; }
        public string Progress { get => _progress; set => _progress = value; }
        public string Wins { get => _wins; set => _wins = value; }
        public string Loses { get => _loses; set => _loses = value; }
        public string TypedLetters { get => _typedLetters; set => _typedLetters = value; }
        public string Time { get => _time; set => _time = value; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

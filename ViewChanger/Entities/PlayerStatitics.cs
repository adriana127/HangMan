using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Entities
{
    class PlayerStatitics : INotifyPropertyChanged
    {
        private string _name;
        private string _imageId;
        private string _wins;
        private string _loses;


        public PlayerStatitics() { }

        public PlayerStatitics(string name, string imageId, string wins, string loses)
        {
            _name = name;
            _imageId = imageId;
            _wins = wins;
            _loses = loses;
        }

        public string Name { get => _name; set => _name = value; }
        public string ImageId { get => _imageId; set => _imageId = value; }
        public string Wins { get => _wins; set => _wins = value; }
        public string Loses { get => _loses; set => _loses = value; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

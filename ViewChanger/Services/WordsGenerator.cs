using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewChanger.Services
{
    class WordsGenerator: INotifyPropertyChanged
    {
        public WordsGenerator()
        {
            Instance = this;
        }

        public static WordsGenerator Instance { get; private set; }
        public List<string> MoviesWords() // se genereaza mape care vor avea 3 indecsi: 0- easy lvl, 1- medium lvl, 3- hard lvl
        {

            Dictionary<int, List<string>> astronomyWords = new Dictionary<int, List<string>>();

            //movies
            //lvl easy
            List<string> _tempList = new List<string>();
            _tempList.AddRange(new List<string>() {"up", "casablanca", "hannibal", "joker","goodfellas","interstellar","gladiator","psycho","whiplash","memento", "breaveheart", "titanic", "avatar", "twilight", "hachiko", "chocolat", "lincoln", "argo", "casino", "troy", "flight", "leon", "shine", "elizabeth", "babel", "defiance", "stalingrad", "gettysburg", "taken", "jumanji", "nebraska", "warrior", "sideways", "prisoners", "invictus", "amour", "madagascar", "shrek", "ratatouille", "brave" });

            return _tempList;

        }

        public List<string> MusicWords() // se genereaza mape care vor avea 3 indecsi: 0- easy lvl, 1- medium lvl, 3- hard lvl
        {

            Dictionary<int, List<string>> astronomyWords = new Dictionary<int, List<string>>();

            //movies
            //lvl easy
            List<string> _tempList = new List<string>();
            _tempList.AddRange(new List<string>() { "acordeon", "bas", "chitara", "acustic", "flaut", "nai", "mandolina", "uculele", "clarinet", "conga", "harpa", "armonica", "lira", "orga", "pian", "contrabas", "toba", "tamburica", "vioara", "violina", "saxofon" });


            return _tempList;

        }
        public List<string> AnimalsWords() // se genereaza mape care vor avea 3 indecsi: 0- easy lvl, 1- medium lvl, 3- hard lvl
        {

            Dictionary<int, List<string>> astronomyWords = new Dictionary<int, List<string>>();

            //movies
            //lvl easy
            List<string> _tempList = new List<string>();
            _tempList.AddRange(new List<string>() { "aligator","antilopa","arici","babuin","balena","barza","bibilica","broasca","bufnita","bursuc","caine","cal","camelon","camila","cangur","capra","caracatita","cartita","cerb","cimpanzeu","cocos","coiot","corb","delfin","dihor","elang","elefant","emu","fazan","flamingo","fluture","foca","furnica","furnicar","gaina","gasca","gorila","hamster","iepure","jaguar","hipopotam","lama","lebada","lemur","leopard","leu","lup","liliac","magar","morsa","maimuta","mangusta","nevastuica","oposum","ornitorinc","papagal","paun","pelican","pinguing","pescarus","porc","porumbel","prepelita" });

            return _tempList;

        }

        public List<string> CarsWords() // se genereaza mape care vor avea 3 indecsi: 0- easy lvl, 1- medium lvl, 3- hard lvl
        {

            Dictionary<int, List<string>> astronomyWords = new Dictionary<int, List<string>>();

            //movies
            //lvl easy
            List<string> _tempList = new List<string>();
            _tempList.AddRange(new List<string>() { "abarth","audi","austin","bentley","bmw","bugatti","buick","cadillac","carver","chevrolet","citroen","corvette","dacia","daewoo","daimler","dodge","honda","hummer","hyundai","jagua","jeep","kia","lada","lamorghini","lexus","linlon","marcos","maserati","mini","mazda","mitsubishi","morris","nissan","opel","rover","princess","renault","porche","toyota","subaru","skoda"});

            return _tempList;

        }


        public List<string> AstronomyWords() // se genereaza mape care vor avea 3 indecsi: 0- easy lvl, 1- medium lvl, 3- hard lvl
        {
            Dictionary<int, List<string>> astronomyWords = new Dictionary<int, List<string>>();

            //movies
            //lvl easy
            List<string> _tempList = new List<string>();
            _tempList.AddRange(new List<string>() { "galaxie", "planeta", "stea", "nebuloasa", "gravitatie", "quasar", "asteroid", "meteor", "neptun", "jupiter", "consetalie", "hubble", "radiatie", "lumina", "satelit", "pulsar", "electromagnetism", "luna", "exoplaneta", "eclipsa", "aurora", "hipernova", "eclipsa", "eliptic", "electron", "vid", "frecventa", "gamma", "ionizare", "ionosfera", "izotop", "jupiter", "kepler", "leptopn" });


            return _tempList;

        }

        public List<string> AllWords() 
        {

            Random rnd = new Random();
            Dictionary<int, List<string>> aux_dic = new Dictionary<int, List<string>>();
            List<string> aux_list = new List<string>();

             int j = 0;
                while(j<5)
                {
                    int NrLista = rnd.Next(0, 5);
                    int k = rnd.Next(0, 3);

                        if (NrLista == 0 && !aux_list.Contains(MoviesWords().ElementAt(k))) { aux_list.Add(MoviesWords().ElementAt(k)); j++; }
                        else if (NrLista == 1 && !aux_list.Contains(MusicWords().ElementAt(k))) { aux_list.Add(MusicWords().ElementAt(k)); j++; }
                        else if (NrLista == 2 && !aux_list.Contains(AnimalsWords().ElementAt(k))) { aux_list.Add(AnimalsWords().ElementAt(k)); j++; }
                        else if (NrLista == 3 && !aux_list.Contains(CarsWords().ElementAt(k))) { aux_list.Add(CarsWords().ElementAt(k)); j++; }
                        else if (NrLista == 4 && !aux_list.Contains(AstronomyWords().ElementAt(k))) { aux_list.Add(AstronomyWords().ElementAt(k)); j++; }
                }
            return aux_list;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

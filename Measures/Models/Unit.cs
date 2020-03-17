using GalaSoft.MvvmLight;

namespace Measures.Models
{
    public class Unit : ObservableObject
    {
        public Unit(string symbol, string nameEN, string factor, string seed, string nameCN, string group = "")
        {
            this.Symbol = symbol;
            this.NameEN = nameEN;
            this.Factor = factor;
            this.Seed = seed;
            this.NameCN = nameCN;
            this.Group = group;
        }

        public string Symbol { get; set; }

        public string NameCN { get; set; }

        public string NameEN { get; set; }

        public string Factor { get; set; }

        public string Seed { get; set; }

        public string Group { get; set; }

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.RaisePropertyChanged("Value");
            }
        }
    }
}

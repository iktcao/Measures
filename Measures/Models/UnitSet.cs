using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;

namespace Measures.Models
{
    public class UnitSet : ObservableObject
    {
        public UnitSet()
        {

        }

        public string NameCN { get; set; }
        public string NameEN { get; set; }
        public string SIUnit { get; set; }

        // 属性：大气压
        private string _atm = "101.325";
        public string ATM
        {
            get { return _atm; }
            set
            {
                _atm = value;
                OnValueChanged(this.Units[0], new EventArgs());
                this.RaisePropertyChanged("ATM");
            }
        }

        // 属性：流体密度
        private string _rho = "1000";
        public string Rho
        {
            get { return _rho; }
            set
            {
                _rho = value;
                this.RaisePropertyChanged("Rho");
                OnValueChanged(this.Units[0], new EventArgs());
            }
        }


        private ObservableCollection<Unit> _units;
        public ObservableCollection<Unit> Units
        {
            get { return _units; }
            set
            {
                _units = value;
                this.RaisePropertyChanged("Units");
            }
        }

        // 添加事件处理器
        public void AddHandler()
        {
            foreach (var item in Units)
            {
                item.PropertyChanged += OnValueChanged;
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            var currentUnit = sender as Unit;
            // 当输入为空时，清空所有单位的值
            if (currentUnit.Value == "")
            {
                foreach (var item in Units)
                {
                    if (item.Symbol != currentUnit.Symbol)
                    {
                        item.PropertyChanged -= OnValueChanged;
                        item.Value = "";
                        item.PropertyChanged += OnValueChanged;
                    }
                }
            }
            else
            {
                double dblValueInput;
                // 当输入的为数字时，计算其它单位的值
                if (double.TryParse(currentUnit.Value, out dblValueInput))
                {
                    double dblSeed;
                    double dblFactor;
                    if (this.NameEN == "Pressure" || this.NameEN == "Viscosity")
                    {
                        dblSeed = EvalNum(currentUnit.Seed);
                        dblFactor = EvalNum(currentUnit.Factor);
                    }
                    else
                    {
                        dblSeed = double.Parse(currentUnit.Seed);
                        dblFactor = double.Parse(currentUnit.Factor);
                    }

                    double dblValueSI = (dblValueInput + dblSeed) * dblFactor;

                    foreach (var item in Units)
                    {
                        if (item.Symbol != currentUnit.Symbol)
                        {
                            item.PropertyChanged -= OnValueChanged;
                            if (this.NameEN == "Pressure" || this.NameEN == "Viscosity")
                            {
                                dblSeed = EvalNum(item.Seed);
                                dblFactor = EvalNum(item.Factor);
                            }
                            else
                            {
                                dblSeed = double.Parse(item.Seed);
                                dblFactor = double.Parse(item.Factor);
                            }
                            item.Value = (dblValueSI / dblFactor - dblSeed).ToString();
                            item.PropertyChanged += OnValueChanged;
                        }
                    }
                }
            }
        }

        private double EvalNum(string str)
        {
            if (str.Contains("atm"))
            {
                if (str == "atm")
                    return double.Parse(this.ATM);
                else
                {
                    if (str.Substring(3, 1) == "*")
                        return double.Parse(this.ATM) * double.Parse(str.Replace("atm*", ""));
                    else
                        return double.Parse(this.ATM) / double.Parse(str.Replace("atm/", ""));
                }
            }
            else if (str.Contains("rho"))
            {
                return double.Parse(str.Replace("/rho", "")) / double.Parse(this.Rho);
            }
            else
                return double.Parse(str);
        }
    }
}

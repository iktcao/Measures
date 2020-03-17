using GalaSoft.MvvmLight;
using Measures.Models;
using System.Collections.ObjectModel;

namespace Measures.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region 构造函数
        public MainViewModel()
        {
            InitUnitSets();
        }


        #endregion

        #region 属性
        private UnitSet _currentUnitSet;
        public UnitSet CurrentUnitSet
        {
            get { return _currentUnitSet; }
            set
            {
                _currentUnitSet = value;
                this.RaisePropertyChanged("CurrentUnitSet");
            }
        }

        private ObservableCollection<UnitSet> _unitSets;
        public ObservableCollection<UnitSet> UnitSets
        {
            get { return _unitSets; }
            set
            {
                _unitSets = value;
                this.RaisePropertyChanged("UnitSets");
            }
        }

        private string _atm = "101.325";
        public string ATM
        {
            get
            {
                foreach (var item in this.UnitSets)
                {
                    if (item.NameEN == "Pressure")
                        _atm = item.ATM;
                }
                return _atm;
            }
            set
            {
                foreach (var item in this.UnitSets)
                {
                    if (item.NameEN == "Pressure")
                        item.ATM = value;
                }
                _atm = value;
                this.RaisePropertyChanged("ATM");
            }
        }

        private string _rho = "101.325";
        public string Rho
        {
            get
            {
                foreach (var item in this.UnitSets)
                {
                    if (item.NameEN == "Viscosity")
                        _rho = item.Rho;
                }
                return _rho;
            }
            set
            {
                foreach (var item in this.UnitSets)
                {
                    if (item.NameEN == "Viscosity")
                        item.Rho = value;
                }
                _rho = value;
                this.RaisePropertyChanged("Rho");
            }
        }
        #endregion

        #region 方法
        private void InitUnitSets()
        {
            UOM uom = new UOM();
            _unitSets = uom.UnitSets;
        }
        #endregion        
    }
}
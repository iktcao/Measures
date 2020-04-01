using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Measures.Models
{
    public class UOM : ObservableObject
    {
        public UOM()
        {
            InitUOM();
        }

        // 属性-单位类别列表
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


        public UnitSet pressure = new UnitSet()
        {
            NameCN = "压力",
            NameEN = "Pressure",
            SIUnit = "Pa",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("Pa", "pascal absolute", "1.0", "0.0", "帕斯卡(Pa)", "绝压"),
                new Unit("PaG", "pascal gauge", "1.0", "atm*1000", "帕斯卡(PaG)", "表压"),
                new Unit("kPa", "kilopascal absolute", "1000", "0.0", "千帕(kPa)", "绝压"),
                new Unit("kPaG", "kilopascal gauge", "1000", "atm", "千帕(kPaG)", "表压"),
                new Unit("bar", "bar absolute", "100000", "0.0", "巴(bar)", "绝压"),
                new Unit("barG", "bar gauge", "100000", "atm/100", "巴(barG)", "表压"),
                new Unit("kgf__cm2", "Kgf/cm2 absolute", "98066.52", "0.0", "公斤力/平方厘米(kgf/cm²)", "绝压"),
                new Unit("kgf__cm2G", "Kgf/cm2 gauge", "98066.52", "atm/98.06652", "公斤力/平方厘米(kgf/cm²G)", "表压"),
                new Unit("MPa", "megapascal absolute", "1000000", "0.0", "兆帕(MPa)", "绝压"),
                new Unit("MPaG", "megapascal gauge", "1000000", "atm/1000", "兆帕(MPaG)", "表压"),
                new Unit("atm", "standard atmosphere abosulte", "atm*1000", "0.0", "大气压(atm)", "绝压"),
                new Unit("atmG", "standard atmosphere gauge", "atm*1000", "atm", "大气压(atmG)", "表压"),
                new Unit("mbar", "millibar absolute", "100", "0.0", "毫巴(mbar)", "绝压"),
                new Unit("mbarG", "millibar gauge", "100", "atm/0.1", "毫巴(mbarG)", "表压"),
                new Unit("mmHg", "millimeters of Hg (0.0C) absolute", "133.322", "0.0", "毫米汞柱(mmHg)", "绝压"),
                new Unit("mmHgG", "millimeters of Hg (0.0C) gauge", "133.322", "atm/0.133322", "毫米汞柱(mmHgG)", "表压"),
                new Unit("inHg", "inches of Hg (0.0C) absolute", "3386.387", "0.0", "英寸汞柱(inHg)", "绝压"),
                new Unit("inHgG", "inches of Hg (0.0C) gauge", "3386.387", "atm/3.386387", "英寸汞柱(inHgG)", "表压"),
                new Unit("inH2O", "inches of H2O (4.0C) absolute", "249.082", "0.0", "英寸水柱(inH2O)", "绝压"),
                new Unit("inH2OG", "inches of H2O (4.0C) gauge", "249.082", "atm/0.249082", "英寸水柱(inH2OG)", "表压"),
                new Unit("mH2O", "meters of H2O (4.0C) absolute", "9806.652", "0.0", "米水柱(mH2O)", "绝压"),
                new Unit("mH2OG", "meters of H2O (4.0C) gauge", "9806.652", "atm/9.806652", "米水柱(mH2OG)", "表压"),
                new Unit("psi", "pounds/square inch absolute", "6894.757", "0.0", "磅力/平方英寸(psi)", "绝压"),
                new Unit("psiG", "pounds/square inch gauge", "6894.757", "atm/6.894757", "磅力/平方英寸(psiG)", "表压"),
                new Unit("psf", "pounds/square foot absolute", "47.88025898", "0.0", "磅力/平方英尺(psf)", "绝压"),
                new Unit("psfG", "pounds/square foot gauge", "47.88025898", "atm/0.04788025898", "磅力/平方英尺(psfG)", "表压"),
                new Unit("Torr", "torr", "133.322", "0.0", "托(Torr)", "绝压"),
            }
        };

        public UnitSet temperature = new UnitSet()
        {
            NameCN = "温度",
            NameEN = "Temperature",
            SIUnit = "K",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("K", "Kelvin", "1", "0.0", "开氏度(K)"),
                new Unit("F", "Fahrenheit", "0.555555555555555", "459.67", "华氏度(℉)"),
                new Unit("C", "Celsius", "1", "273.15", "摄氏度(℃)"),
                new Unit("R", "Rankine", "0.555555555555555", "0.0", "兰氏度(°R)"),
            }
        };

        public UnitSet mass = new UnitSet()
        {
            NameCN = "质量",
            NameEN = "Mass",
            SIUnit = "kg",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("kg", "kilogram", "1.0", "0.0", "千克(kg)"),
                new Unit("g", "gram", "0.00100", "0.0", "克(g)"),
                new Unit("mg", "milligram", "0.000001", "0.0", "毫克(mg)"),
                new Unit("ug", "microgram", "0.000000001", "0.0", "微克(μg)"),
                new Unit("ton", "metric ton or tonne", "1000.0", "0.0", "吨(t)"),
                new Unit("kton", "kilotons", "1.0E+6", "0.0", "千吨(kt)"),
                new Unit("Mton", "megatons", "1.0E+9", "0.0", "百万吨(MMT)"),
                new Unit("MMton", "gigatons", "1.0E+10", "0.0", "千万吨(10-MMT)"),
                new Unit("lb", "pound", "0.45359237", "0.0", "磅(lb)"),
                new Unit("klb", "kilopounds", "453.59237", "0.0", "千磅(klb)"),
                new Unit("ston", "short ton or US tons", "907.18", "0.0", "短吨(st)"),
                new Unit("lton", "long ton or UK tons", "1016.0", "0.0", "长吨(lt)"),
                new Unit("oz", "ounce", "0.028350", "0.0", "盎司(oz)"),
                new Unit("ct", "carat", "0.0002", "0.0", "克拉(ct)"),
            }
        };

        public UnitSet length = new UnitSet()
        {
            NameCN = "长度",
            NameEN = "Length",
            SIUnit = "m",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("m", "meter", "1.0", "0.0", "米(m)"),
                new Unit("km", "kilometer", "1000.0", "0.0", "千米(km)"),
                new Unit("dm", "decimeter", "0.1", "0.0", "分米(dm)"),
                new Unit("cm", "centimeter", "0.01", "0.0", "厘米(cm)"),
                new Unit("mm", "millimeter", "0.001", "0.0", "毫米(mm)"),
                new Unit("um", "micrometer", "1.0E-6", "0.0", "微米(μm)"),
                new Unit("nm", "nanometer", "1.0E-9", "0.0", "纳米(nm)"),
                new Unit("ft", "feet", "0.3048", "0.0", "英尺(ft)"),
                new Unit("in", "inch", "0.0254", "0.0", "英寸(in)"),
                new Unit("yd", "yard", "0.91440", "0.0", "码(yd)"),
                new Unit("mi", "UK mile", "1.6093e+3", "0.0", "英里(mile)"),
                new Unit("nmi", "nautical mile", "1852.0", "0.0", "海里(nmi)"),
            }
        };

        public UnitSet viscosity = new UnitSet()
        {
            NameCN = "粘度",
            NameEN = "Viscosity",
            SIUnit = "Pa_s",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("Pa_s", "pascal second", "1.0", "0.0", "帕·秒(Pa·s)", "动力粘度（DynamicViscosity）"),
                new Unit("mPa_s", "milli pascal second", "0.001", "0.0", "毫帕·秒(mPa·s)", "动力粘度（DynamicViscosity）"),
                new Unit("cP", "centipoise", "0.001", "0.0", "厘泊(cP)", "动力粘度（DynamicViscosity）"),
                new Unit("P", "poise", "0.1", "0.0", "泊(P)", "动力粘度（DynamicViscosity）"),
                new Unit("lb__ft_s", "lb/ft-sec", "1.4882", "0.0", "磅/(英尺·秒) (lb/ft·s)", "动力粘度（DynamicViscosity）"),
                new Unit("kgf_s__m2", "kgf-sec/m2", "9.80665", "0.0", "千克力·秒/平方米(kgf·s/m²)", "动力粘度（DynamicViscosity）"),
                new Unit("lbf_s__ft2", "lbf-sec/ft2", "47.88", "0.0", "磅力·秒/平方英尺(lbf·s/ft²)", "动力粘度（DynamicViscosity）"),
                new Unit("mN_s__m2", "mN s/m2", "0.001", "0.0", "毫牛·秒/平方米(mN·s/m²)", "动力粘度（DynamicViscosity）"),
                new Unit("cst", "centistokes", "1.0*rho", "0.0", "厘斯(cSt)", "运动粘度（Kinematic Viscosity）"),
                new Unit("st", "stokes", "100.0*rho", "0.0", "斯(St)", "运动粘度（Kinematic Viscosity）"),
                new Unit("m2__s", "square meter per second", "1.0E+6*rho", "0.0", "平方米/秒(m²/s)", "运动粘度（Kinematic Viscosity）"),
                new Unit("cm2__s", "square centimeter per second", "1.0E+2*rho", "0.0", "平方厘米/秒(cm²/s)", "运动粘度（Kinematic Viscosity）"),
                new Unit("mm2__s", "square millimeter per second", "1.0*rho", "0.0", "平方毫米/秒(mm²/s)", "运动粘度（Kinematic Viscosity）"),
                new Unit("in2__s", "square inch per second", "645.16*rho", "0.0", "平方英尺/秒(in²/s)", "运动粘度（Kinematic Viscosity）"),
            }
        };

        public UnitSet energy = new UnitSet()
        {
            NameCN = "能量",
            NameEN = "Energy",
            SIUnit = "J",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("J", "joule", "1.0", "0.0", "焦耳(J)"),
                new Unit("kJ", "kilojoule", "1000.0", "0.0", "千焦(kJ)"),
                new Unit("MJ", "megajoule", "1.0E+6", "0.0", "兆焦(MJ)"),
                new Unit("cal", "calorie", "4.184", "0.0", "卡(cal)"),
                new Unit("kcal", "kilocalorie", "4184", "0.0", "千卡(kcal)"),
                new Unit("Mcal", "megacalorie", "4.184E+6", "0.0", "兆卡(Mcal)"),
                new Unit("Btu", "British thermal unit", "1055.0", "0.0", "英热单位(Btu)"),
                new Unit("hph", "horsepower hour", "2684519.5392", "0.0", "马力·时(hp·h)"),
                new Unit("kWh", "kilowatt hour", "3600000.0", "0.0", "千瓦·时(kW·h)"),
                new Unit("kgm", "kilogram-force meter", "9.80665", "0.0", "公斤力·米(kgf·m)"),
                new Unit("gcm", "gram-force centimeter", "0.000098067", "0.0", "克力·厘米(gf·cm)"),
            }
        };

        public UnitSet work = new UnitSet()
        {
            NameCN = "功率",
            NameEN = "Work",
            SIUnit = "W",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("W", "watt", "1.0", "0.0", "瓦(W)"),
                new Unit("kW", "kilowatt", "1000.0", "0.0", "千瓦(kW)"),
                new Unit("MW", "megaWatts", "1000000.0", "0.0", "兆瓦(MW)"),
                new Unit("kcal__s", "kilocalorie per second", "4184", "0.0", "千卡/秒(kcal/s)"),
                new Unit("kcal__h", "kilocalorie/hour", "1.1627782", "0.0", "千卡/时(kcal/h)"),
                new Unit("Btu__s", "btu per second", "1055.0", "0.0", "英热单位/秒(Btu/s)"),
                new Unit("Btu__h", "btu per hour", "0.2930556", "0.0", "英热单位/时(Btu/h)"),
                new Unit("hp", "horse power", "735.499", "0.0", "马力(hp)"),
                new Unit("kgm__s", "kilogram meter per second", "9.80665", "0.0", "公斤·米/秒(kg·m/s)"),
                new Unit("Nm__s", "newton meter per second", "1.0", "0.0", "顿·米/秒(N·m/s)"),
                new Unit("ftlb__s", "feet pound per second", "1.3557484", "0.0", "英尺·磅/秒(ft·lb/s)"),
            }
        };

        public UnitSet thermalConductivity = new UnitSet()
        {
            NameCN = "热导率",
            NameEN = "ThermalConductivity",
            SIUnit = "W__m_K",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("W__m_K", "watt/m-K", "1.0", "0.0", "W/(m·K)"),
                new Unit("W__m_C", "watt/m-C", "1.0", "0.0", "W/(m·℃)"),
                new Unit("kcal__hr_m_C", "kilocalorie/hr-m-C", "1.1627782", "0.0", "kcal/(h·m·℃)"),
                new Unit("Btu__hr_ft_F", "btu/hr-ft-F", "1.730643", "0.0", "Btu/(h·ft·°F)"),
                new Unit("cal__s_cm_C", "calorie/s-cm-C", "418.4", "0.0", "cal/(s·cm·℃)"),
                new Unit("Btu_in__hr_ft2_F", "btu-in/hr-ft2-F", "0.1441314", "0.0", "Btu·in/(h·ft²·°F)"),
            }
        };

        public UnitSet heatCapacity = new UnitSet()
        {
            NameCN = "热容",
            NameEN = "HeatCapacity",
            SIUnit = "J__kg_C",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("J__kg_C", "joule/kg-C", "1.0", "0.0", "J/(kg·℃)"),
                new Unit("Btu__lb_F", "btu/lb-F", "4184.0", "0.0", "Btu/(lb·°F)"),
                new Unit("kcal__kg_C", "kcal/kg-C", "4184.0", "0.0", "kcal/(kg·℃)"),
                new Unit("kJ__kg_C", "kilojoule/kg-C", "1000.0", "0.0", "kJ/(kg·℃)"),
                new Unit("cal__g_C", "cal/g-C", "4184.0", "0.0", "cal/(g·℃)"),
                new Unit("J__kg_K", "joule/kg-K", "1.0", "0.0", "J/(kg·K)"),
            }
        };

        public UnitSet surfaceTension = new UnitSet()
        {
            NameCN = "表面张力",
            NameEN = "SurfaceTension",
            SIUnit = "newton/meter",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("N__m", "newton/meter", "1.0", "0.0", "牛/米(N/m)"),
                new Unit("mN__m", "milli-newton/meter", "1.0e-3", "0.0", "毫牛/米(mN/m)"),
                new Unit("dyne__cm", "dyne/centimeter", "1.0e-3", "0.0", "达因/厘米(dyn/cm)"),
                new Unit("lbf__in", "lbf/in", "1.7513e+2", "0.0", "磅力/英寸(lbf/in)"),
                new Unit("kgf__m", "kgf/m", "9.8067", "0.0", "千克力/米(kgf/m)"),
                new Unit("pdl__in", "poundal/in", "5.443108", "0.0", "磅达/英寸(pdl/in)"),
            }
        };

        public UnitSet time = new UnitSet()
        {
            NameCN = "时间",
            NameEN = "Time",
            SIUnit = "s",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("s", "second", "1.0", "0.0", "秒(s)"),
                new Unit("ms", "millisecond", "1.0E-3", "0.0", "毫秒(ms)"),
                new Unit("min", "minute", "60", "0.0", "分(min)"),
                new Unit("hr", "hour", "3600", "0.0", "时(h)"),
                new Unit("day", "day", "86400", "0.0", "天(d)"),
                new Unit("wk", "week", "6.0480E+5", "0.0", "周(week)"),
                new Unit("mon", "month", "2.5514E+6", "0.0", "月(mon)"),
                new Unit("yr", "year", "3.1557E+7", "0.0", "年(yr)"),
            }
        };        

        public UnitSet area = new UnitSet()
        {
            NameCN = "面积",
            NameEN = "Area",
            SIUnit = "m2",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("m2", "square meter", "1.0", "0.0", "平方米(m²)"),
                new Unit("km2", "square kilometer", "1.0e+6", "0.0", "平方公里(km²)"),
                new Unit("dm2", "square decimeter", "1.0e-2", "0.0", "平方分米(dm²)"),
                new Unit("cm2", "square centimeter", "1.0e-4", "0.0", "平方厘米(cm²)"),
                new Unit("mm2", "square millimeter", "1.0e-6", "0.0", "平方毫米(mm²)"),
                new Unit("ft2", "square feet", "9.2903e-2", "0.0", "平方英尺(ft²)"),
                new Unit("in2", "square inch", "6.4516e-4", "0.0", "平方英寸(in²)"),
                new Unit("yd2", "square yard", "8.3613e-1", "0.0", "平方码(yd²)"),
                new Unit("mi2", "square mile", "2.59e+6", "0.0", "平方英里(mile²)"),
            }
        };

        public UnitSet volume = new UnitSet()
        {
            NameCN = "体积",
            NameEN = "Volume",
            SIUnit = "m3",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("m3", "cubic meter", "1.0", "0.0", "立方米(m³)"),
                new Unit("L", "liter", "1.0e-3", "0.0", "升(L)"),
                new Unit("dm3", "cubic decimeter", "1.0e-3", "0.0", "立方分米(dm³)"),
                new Unit("mL", "milliliter", "1.0e-6", "0.0", "毫升(mL)"),
                new Unit("cm3", "cubic centimeter", "1.0e-6", "0.0", "立方厘米(cm³)"),
                new Unit("bbl", "barrel", "1.5899e-1", "0.0", "桶(bbl)"),
                new Unit("ft3", "cubic foot", "2.8317e-2", "0.0", "立方英尺(ft³)"),
                new Unit("in3", "cubic inch", "1.6387e-5", "0.0", "立方英寸(in³)"),
                new Unit("gal", "US gallon", "3.7854e-3", "0.0", "美制加仑(us gal)"),
                new Unit("pt", "US pint", "4.7318e-4", "0.0", "美制品脱(us pt)"),
                new Unit("oz", "US ounce", "2.9574e-5", "0.0", "美制液体盎司(oz)"),
                new Unit("igal", "UK gallon", "4.5461e-3", "0.0", "英制加仑(uk gal)"),
                new Unit("ipt", "UK pint", "5.6826e-4", "0.0", "英制品脱(uk pt)"),
                new Unit("ioz", "UK ounce", "2.8413e-5", "0.0", "英制液体盎司(oz)"),
            }
        };

        public UnitSet density = new UnitSet()
        {
            NameCN = "密度",
            NameEN = "Density",
            SIUnit = "kg__m3",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("kg__m3", "kilogram/cubic meter", "1.0", "0.0", "千克/立方米(kg/m³)"),
                new Unit("g__cm3", "gram/cubic centimeter", "1.0E+3", "0.0", "克/立方厘米(g/cm³)"),
                new Unit("sp", "specific gravity", "999.972", "0.0", "比重"),
                new Unit("lb__ft3", "pounds/cubic foot", "16.01845115", "0.0", "磅/立方英尺(lb/ft³)"),
                new Unit("lb__gal", "pounds/gallon", "119.826", "0.0", "磅/美加仑(lb/gal³)"),
                new Unit("lb__in3", "pounds/cubic inch", "27679.883", "0.0", "磅/立方英寸(lb/in³)"),
                new Unit("lb__barrel", "pounds/barrel", "2.853", "0.0", "磅/桶(lb/barrel)"),
            }
        };

        public UnitSet force = new UnitSet()
        {
            NameCN = "力",
            NameEN = "Force",
            SIUnit = "N",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("N", "newton", "1.0", "0.0", "牛顿(N)"),
                new Unit("kN", "kilonewton", "1000.0", "0.0", "千牛(kN)"),
                new Unit("gf", "gram force", "9.80665E-3", "0.0", "克力(gf)"),
                new Unit("kgf", "kilogram force", "9.80665", "0.0", "公斤力(kgf)"),
                new Unit("lbf", "pound force", "4.448222", "0.0", "磅力(lbf)"),
                new Unit("klbf", "kilopounds force", "4.448222E+3", "0.0", "千磅力(klbf)"),
                new Unit("dyn", "kilocalorie per second", "1.0E-5", "0.0", "达因(dyn)"),
            }
        };

        public UnitSet angle = new UnitSet()
        {
            NameCN = "角度",
            NameEN = "Angle",
            SIUnit = "arcsec",
            Units = new ObservableCollection<Unit>()
            {
                new Unit("arcsec", "second of arc", "1.0", "0.0", "秒('')"),
                new Unit("arcmin", "minute of arc", "60.0", "0.0", "分(')"),
                new Unit("deg", "degree", "3600.0", "0.0", "度(°)"),
                new Unit("rad", "radian", "206264.808", "0.0", "弧度(rad)"),
            }
        };

        // 初始化方法
        private void InitUOM()
        {
            _unitSets = new ObservableCollection<UnitSet>();
            var props = this.GetType().GetFields();
            foreach (FieldInfo propertyInfo in props)
            {
                object propVal = propertyInfo.GetValue(this);
                string propName = propertyInfo.Name;
                if (propVal.GetType() == typeof(UnitSet))
                {
                    var obj = propVal as UnitSet;
                    obj.AddHandler();
                    this._unitSets.Add(obj);
                }
            }
        }
    }
}
